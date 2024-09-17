namespace DAL.Contexts
{
    public interface IDbContext : IDisposable
    {
       
        System.Data.Entity.Database Database { get; }
    }
}
