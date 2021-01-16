using System.Data.Entity;
using Demo.Domain.Interface;

namespace Demo.DAL.SeekWork
{
    public class EFContext : IDbContext
    {
        public EFContext()
        {
            DbContext = new DemoContext();
        }

        public DbContext DbContext { get; }
    }
}