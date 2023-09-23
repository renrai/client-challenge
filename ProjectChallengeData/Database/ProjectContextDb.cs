using Microsoft.EntityFrameworkCore;
using ProjectChallengeData.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChallengeData.Database
{
    public class ProjectContextDb : DbContext
    {
        public ProjectContextDb(DbContextOptions<ProjectContextDb> options) : base(options)
        {

        }

        public DbSet<ClientEntity> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientEntity>(build =>
            {
                build.ToTable("Clients");
                build.HasKey(entry => entry.Id);
                build.Property(entry => entry.Name).HasMaxLength(100);
            });
        }
    }
}
