namespace BepopAppServer.DAL.UOF
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
