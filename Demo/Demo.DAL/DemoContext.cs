using System.Data.Entity;
using Demo.DAL.ORMModel;


namespace Demo.DAL
{
    public class DemoContext : DbContext
    {
        public DemoContext()
            :base("mssql")
        {
            
        } 
        
        
        public DbSet<Member> Members { get; set; }
        
        public DbSet<Product>Products { get; set; }
    }
}