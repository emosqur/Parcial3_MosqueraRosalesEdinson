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
            modelBuilder.Entity<Tickec>().HasIndex(c => c.TicketID).IsUnique();

        }
       



        public DbSet<Tickec> Tickets{ get; set; }


    }
}
