using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectMedii1.Models
{
    public class Experience
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime EventDateTime { get; set; }

        [Required]
        public int Duration { get; set; }

        [ForeignKey("Member")]
        public int? MemberID { get; set; } // Cheia externă pentru membru
        public Member? Member { get; set; } // Proprietatea de navigație

        [Required]
        public string Description { get; set; }
    }
}
