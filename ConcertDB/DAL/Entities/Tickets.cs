namespace ConcertDB.DAL.Entities
{
    public class Tickets:Entity
    {
        public DateTime? UseDate { get; set; }

        public Boolean IsUsed { get; set;}

        public String EntranceGate { get; set; }


    }
}
