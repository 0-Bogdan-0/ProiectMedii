using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Models;

namespace ProiectMedii.Data
{
    public class ProiectMediiContext : DbContext
    {
        public ProiectMediiContext (DbContextOptions<ProiectMediiContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectMedii.Models.Clasa_model> Clasa_model { get; set; } = default!;
        public DbSet<ProiectMedii.Models.Brand> Brand { get; set; } = default!;
        public DbSet<Agent> Agent { get; set; } = default!;
        public DbSet<ProiectMedii.Models.Categorie> Categorie { get; set; } = default!;
    }
}
