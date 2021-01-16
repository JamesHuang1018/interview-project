using System.Data.Entity;

namespace Demo.Domain.Interface
{
    public interface IDbContext
    {
        DbContext DbContext { get; }
    }
}