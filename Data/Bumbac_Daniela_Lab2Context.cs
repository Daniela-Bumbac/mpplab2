using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bumbac_Daniela_Lab2.Models;

namespace Bumbac_Daniela_Lab2.Data
{
    public class Bumbac_Daniela_Lab2Context : DbContext
    {
        public Bumbac_Daniela_Lab2Context (DbContextOptions<Bumbac_Daniela_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Bumbac_Daniela_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Bumbac_Daniela_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Bumbac_Daniela_Lab2.Models.Author>? Author { get; set; }

        public DbSet<Bumbac_Daniela_Lab2.Models.Category>? Category { get; set; }
    }
}
