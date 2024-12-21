using System.ComponentModel.DataAnnotations;

namespace ProiectMedii1.Models
{
    public class Member
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 2)]
        public string? FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 2)]
        public string? LastName { get; set; }

        [StringLength(70)]
        public string Email { get; set; }

        [RegularExpression(@"^0[0-9]{3}[-. ]?[0-9]{3}[-. ]?[0-9]{3}$", ErrorMessage = "The phone number must start with '0' and follow a similar structure: '0722-123-123', '0722.123.123' or '0722 123 123'.")]
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
