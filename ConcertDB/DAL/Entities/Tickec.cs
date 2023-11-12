using System.ComponentModel.DataAnnotations;

namespace ConcertDB.DAL.Entities
{
    public class Tickec : Entity
    {
        [Display(Name = "Ingrese numerode Boleto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
         public int TicketID { get; set; }

        [Display(Name = " Fecha de uso de la boleta")]
        public DateTime? UseDate { get; set; }


        [Display(Name = "Boleta Activo o Inactiva")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool IsUsed { get; set; }

        public Entrance? EntranceGate { get; set; }
        public enum Entrance
        {
            Oriental,
            Occidental,
            Norte,
            Sur
        }

    }
}
