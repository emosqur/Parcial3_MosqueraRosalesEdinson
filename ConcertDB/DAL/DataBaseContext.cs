using ConcertDB.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConcertDB.DAL
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
             
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tickets>().HasIndex(c => c.Name).IsUnique();

        }
       



        public DbSet<Tickets> Ticketss{ get; set; }


    }
}
