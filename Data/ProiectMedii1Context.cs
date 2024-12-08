using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectMedii1.Models;

namespace ProiectMedii1.Data
{
    public class ProiectMedii1Context : DbContext
    {
        public ProiectMedii1Context (DbContextOptions<ProiectMedii1Context> options)
            : base(options)
        {
        }

        public DbSet<ProiectMedii1.Models.Equipment> Equipment { get; set; } = default!;
        public DbSet<ProiectMedii1.Models.Category> Category { get; set; } = default!;
        public DbSet<ProiectMedii1.Models.Member> Member { get; set; } = default!;
        public DbSet<ProiectMedii1.Models.Rental> Rental { get; set; } = default!;
    }
}
