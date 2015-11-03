using DAL.Entities;
using DAL.Initializer;
using System.Data.Entity;

namespace DAL.Context
{
    public class BackendContext : DbContext
    {
        public BackendContext() : base("TestDB")
        {
            Database.SetInitializer(new DBInitializer()); 
        }

        public DbSet<PostContent> Posts { get; set; }
    }
}