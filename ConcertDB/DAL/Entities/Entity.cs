using System.ComponentModel.DataAnnotations;

namespace ConcertDB.DAL.Entities
{
    public class Entity
    {
        [Required]
      public  Guid Id { get; set; }

        [Display(Name = "Fecha de creacion")]
      public DateTime? CreatedDate { get; set; }

        [Display(Name = "Fecha de Modificacion")]
        public DateTime? ModifiedDate { get; set;}
                    

    }
}
