using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChallengeDisney.PreAcel.Entities;

namespace ChallengeDisney.PreAcel.Context
{
    public class WordDisneyContext : DbContext
    {
        public WordDisneyContext(DbContextOptions
            options) : base(options)
        {



        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Gender> Genders { get; set; } = null!;
        public DbSet<Character> Charactersers { get; set; } = null!;
        public DbSet<MovieOrSerie> MovieOrSeries { get; set; } = null!;
    }
}
