using System.ComponentModel.DataAnnotations;

namespace ConcertDB.DAL.Entities
{
    public class Entity
    {
        [Key]
        [Required]
        public  Guid Id { get; set; }
        [Display(Name = "Fecha de  Creación")]
        public  DateTime? CreateDate { get; set; }

        [Display(Name = "Fecha de modificacion")]
        public  DateTime? ModifiedDate { get; set; }
    }
}
