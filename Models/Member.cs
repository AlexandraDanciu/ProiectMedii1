using System.ComponentModel.DataAnnotations;

namespace ProiectMedii1.Models
{
    public class Member
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string? FirstName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string? LastName { get; set; }
        [StringLength(70)]
        public string Email { get; set; }
        [RegularExpression(@"^0[0-9]{3}[-. ]?[0-9]{3}[-. ]?[0-9]{3}$", ErrorMessage = "Telefonul trebuie sa inceapa cu '0' si sa fie de forma '0722-123-123', '0722.123.123' sau '0722 123 123'.")]
        public string? Phone { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Rental>? Rentals { get; set; }

    }
}
