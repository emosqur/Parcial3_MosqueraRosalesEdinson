using System.ComponentModel.DataAnnotations;

namespace ConcertDB.DAL.Entities
{
    public class Tickets:Entity
    {
        public DateTime? UseDate { get; set; }

        public Boolean IsUsed { get; set;}

        [Display(Name ="Entrada")]
        [Required]
        [MaxLength(50, ErrorMessage ="El campo{0} debe tener maximo{1} caracteres.")]
        public String EntranceGate { get; set; }


    }
}
