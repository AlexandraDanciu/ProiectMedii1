using System.ComponentModel.DataAnnotations;

namespace ProiectMedii1.Models
{
    public class Rental
    {
        public int ID { get; set; }

        public int? MemberID { get; set; }
        public Member? Member { get; set; }

        public int? EquipmentID { get; set; }
        public Equipment? Equipment { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime RentalDate { get; set; }

    }
}
