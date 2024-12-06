using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProiectMedii1.Models
{
    public class Equipment
    {
        public int ID { get; set; }
        [Display(Name = "Equipment Name")]
        public string Name { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }
        public int Piecies { get; set; }
        public string Availability {  get; set; }

    }
}
