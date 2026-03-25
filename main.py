from fastapi import FastAPI
import pandas as pd
from sklearn.decomposition import TruncatedSVD
import pyodbc

app = FastAPI()

# Global deðiþkenler (Uygulama belleðinde tutulacak)
predictions_df = pd.DataFrame()
popular_songs = []

# Kendi SQL Server baðlantý bilgilerini buraya gir
DB_CONN_STR = (
    "DRIVER={ODBC Driver 17 for SQL Server};"
    "SERVER=localhost;" 
    "DATABASE=BepopAppDb;"
    "Trusted_Connection=yes;"
)

@app.on_event("startup")
def train_model():
    global predictions_df, popular_songs
    print("Veriler çekiliyor ve scikit-learn modeli eðitiliyor...")

    conn = pyodbc.connect(DB_CONN_STR)
    query = """
    SELECT AppUserId as UserId, SongId, COUNT(*) as PlayCount
    FROM UserSongHistories
    GROUP BY AppUserId, SongId
    """
    df = pd.read_sql(query, conn)
    conn.close()

    if len(df) < 10:
        print("Sistemde yeterli dinleme geçmiþi yok.")
        return

    # 1. Yeni kullanýcýlar için en çok dinlenen þarkýlarý hesapla (Yedek Plan)
    popular_songs = df.groupby('SongId')['PlayCount'].sum().sort_values(ascending=False).index.tolist()

    # 2. Kullanýcý-Þarký Matrisi Oluþtur (Satýrlar: Kullanýcýlar, Sütunlar: Þarkýlar)
    # Dinlenmeyen þarkýlar NaN olur, onlarý 0 ile dolduruyoruz.
    user_item_matrix = df.pivot(index='UserId', columns='SongId', values='PlayCount').fillna(0)

    # Veri setimiz çok küçükse SVD hata vermesin diye bileþen sayýsýný dinamik ayarlýyoruz
    n_components = min(10, len(user_item_matrix.columns) - 1)
    if n_components < 1:
        n_components = 1

    # 3. SVD (Matrix Factorization) Algoritmasýný Kur ve Eðit
    svd = TruncatedSVD(n_components=n_components, random_state=42)
    
    # Matrisi sýkýþtýr ve geri aç (Bu iþlem, 0 olan boþluklarý tahminlerle doldurur)
    matrix_reduced = svd.fit_transform(user_item_matrix)
    predicted_matrix = svd.inverse_transform(matrix_reduced)

    # 4. Tahminleri tekrar okunabilir bir DataFrame'e çevir
    predictions_df = pd.DataFrame(
        predicted_matrix, 
        index=user_item_matrix.index, 
        columns=user_item_matrix.columns
    )
    print("Model eðitimi baþarýyla tamamlandý!")

@app.get("/recommend/{user_id}")
def get_recommendations(user_id: str, top_n: int = 10):
    global predictions_df, popular_songs
    
    # Eðer model henüz eðitilmediyse veya sistemde veri yoksa boþ dön
    if predictions_df.empty and not popular_songs:
        return {"userId": user_id, "recommendedSongIds": [], "message": "Sistemde yeterli veri yok."}

    # Kullanýcý veritabanýnda hiç yoksa (Yepyeni kullanýcý), popüler þarkýlarý öner
    if user_id not in predictions_df.index:
        return {
            "userId": user_id, 
            "recommendedSongIds": popular_songs[:top_n], 
            "message": "Yeni kullanýcý - Popüler þarkýlar önerildi"
        }

    # Kullanýcýnýn daha önce dinlediði þarkýlarý bul
    conn = pyodbc.connect(DB_CONN_STR)
    listened_query = f"SELECT DISTINCT SongId FROM UserSongHistories WHERE AppUserId = '{user_id}'"
    listened_songs = pd.read_sql(listened_query, conn)['SongId'].tolist()
    conn.close()

    # Kullanýcýnýn tüm þarkýlar için model tarafýndan tahmin edilen skorlarýný al
    user_scores = predictions_df.loc[user_id]

    # Daha önce dinlediði þarkýlarý öneri havuzundan çýkar
    user_scores = user_scores.drop(labels=listened_songs, errors='ignore')

    # En yüksek skora sahip þarkýlarý büyükten küçüðe sýrala ve ilk N tanesini al
    top_songs = user_scores.sort_values(ascending=False).head(top_n)

    # Sonuçlarý integer listesi olarak JSON'a uygun hale getir
    recommended_ids = [int(song_id) for song_id in top_songs.index]

    return {
        "userId": user_id, 
        "recommendedSongIds": recommended_ids,
        "message": "Kiþiselleþtirilmiþ öneriler getirildi"
    }