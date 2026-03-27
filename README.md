<div align="center">

# 🎵 BepopApp Server

**Modern Müzik Platformu ve Akıllı Öneri Motoru Backend Servisi**

[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Python](https://img.shields.io/badge/Python-3776AB?style=for-the-badge&logo=python&logoColor=white)](https://www.python.org/)
[![FastAPI](https://img.shields.io/badge/FastAPI-009688?style=for-the-badge&logo=fastapi&logoColor=white)](https://fastapi.tiangolo.com/)
[![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white)](https://www.mysql.com/)
[![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)](https://www.docker.com/)
[![n8n](https://img.shields.io/badge/n8n-FF6D5A?style=for-the-badge&logo=n8n&logoColor=white)](https://n8n.io/)

[Mimarisi](#-mimari-ve-teknoloji-yığını) • [Kurulum](#-kurulum-ve-kullanım) • [Özellikler](#-temel-özellikler) • [İletişim](#-iletişim)

</div>

## 📖 Proje Hakkında

**BepopApp Server**, kullanıcıların müzik dinleyebildiği, sanatçı ve albümleri keşfedebildiği bir platformun arka uç (backend) sistemidir. Salt bir CRUD uygulamasının ötesine geçerek, **Makine Öğrenmesi (Machine Learning)** destekli bir mikroservis ile kullanıcılara kişiselleştirilmiş müzik önerileri sunar. 

Proje, endüstri standartlarında kurumsal bir yapı hedeflenerek **Katmanlı Mimari (N-Tier Architecture)** prensipleriyle inşa edilmiştir.

## 🚀 Temel Özellikler

- **Gelişmiş Kimlik Yönetimi:** ASP.NET Core Identity ve JWT (JSON Web Token) tabanlı güvenli doğrulama.
- **Akıllı Öneri Motoru:** Python, FastAPI ve `scikit-learn` (Matrix Factorization) kullanılarak geliştirilmiş, Dockerize edilmiş bağımsız müzik öneri mikroservisi.
- **Temiz Kod (Clean Code) & AOP:** Controller'ları if-else bloklarından arındırmak için özel yazılmış `ValidationFilter` middleware'i ve DTO'lar üzerinde `FluentValidation` entegrasyonu.
- **Gelişmiş Veri Erişimi:** Generic Repository ve Unit of Work (UoW) tasarım desenleri ile asenkron veritabanı işlemleri.
- **Otomasyon (Workflow):** **n8n** ve **Gemini API** entegrasyonu ile haftalık kişiselleştirilmiş öneri bültenlerinin dinamik olarak oluşturulup kullanıcılara e-posta ile iletilmesi.

## 🏗 Mimari ve Teknoloji Yığını

Proje, bileşenler arası bağımlılığı en aza indirmek (loose coupling) amacıyla 4 ana katmandan oluşmaktadır:

```text
📦 BepopAppServer
 ┣ 📂 BepopAppServer.Entity    # Core Modeller, Base Entity ve Interface'ler
 ┣ 📂 BepopAppServer.DAL       # Data Access (EF Core), Repository, UoW, Migrations
 ┣ 📂 BepopAppServer.Business  # İş Kuralları, DTO'lar, Validation Kuralları, Servisler
 ┗ 📂 BepopAppServer.API       # Controller'lar, Middlewares, AppSettings (Entry Point)
 ┣ 📂 [Python Microservice]    # ML Tabanlı Recommendation Servisi (FastAPI)
