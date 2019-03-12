using Microsoft.EntityFrameworkCore;
using MyLogbook.Entities;
using System;
using System.Collections.Generic;

namespace MyLogbook.AppContext
{
    public class AppDbContext: DbContext
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Thing> Things { get; set; }
        public DbSet<ThingsGroup> ThingsGroups { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Faculty>().HasMany(f => f.Groups).WithOne();
            builder.Entity<Group>().HasOne(b => b.Faculty).WithMany(z => z.Groups).HasForeignKey(b => b.id_Faculty);
            builder.Entity<Student>().HasOne(z => z.Group).WithMany(x => x.Students).HasForeignKey(z => z.id_Group);
            builder.Entity<Assessment>().HasOne(z => z.Student).WithMany(x => x.Assessments)
                .HasForeignKey(z => z.id_Student);
            builder.Entity<Assessment>().HasOne(z => z.Thing).WithMany(x => x.Assessments)
                .HasForeignKey(z => z.id_Thing);
            builder.Entity<Teacher>().HasMany(z => z.Things).WithOne();
            builder.Entity<Thing>().HasOne(z => z.Teacher).WithMany(x => x.Things).HasForeignKey(z => z.id_Teacher);
            builder.Entity<ThingsGroup>().HasKey(z => new { z.id_Group, z.id_Thing });
            builder.Entity<ThingsGroup>().HasOne(z => z.Group).WithMany(x => x.ThingsGroups)
                .HasForeignKey(z => z.id_Group);
            builder.Entity<ThingsGroup>().HasOne(z => z.Thing).WithMany(x => x.ThingsGroups)
                .HasForeignKey(z => z.id_Thing);
            base.OnModelCreating(builder);
            builder.Entity<Faculty>().HasData(
                new Faculty
                {
                    Id = Guid.NewGuid(),
                    Name = "Programming",

                },
                new Faculty
                {
                    Id = Guid.NewGuid(),
                    Name = "System administration and security",

                },
                new Faculty
                {
                    Id = Guid.NewGuid(),
                    Name = "Disign",

                },
                new Faculty
                {
                    Id = Guid.NewGuid(),
                    Name = "Base",

                });
        }
    }
}
