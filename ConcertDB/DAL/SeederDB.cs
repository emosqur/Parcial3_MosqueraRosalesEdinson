using ConcertDB.DAL.Entities;

namespace ConcertDB.DAL
{
    public class SeederDb
    {
        private readonly DataBaseContext _context;
        public SeederDb(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            PopulateTickets(); 
            await _context.SaveChangesAsync();
        }

        private void PopulateTickets()
        {
            if (!_context.Tickets.Any())
            {
                for (int i = 1; i <= 1000; i++)
                {
                    _context.Tickets.Add(new Entities.Tickec
                    {
                        TicketID = i, UseDate = null,IsUsed = false,EntranceGate = null,CreateDate = DateTime.Now,
                    }
                    );
                }

            }
        }
    }
}
