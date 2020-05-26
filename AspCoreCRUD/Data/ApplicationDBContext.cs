using System;
using AspCoreCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AspCoreCRUD.Data
{
    public class ApplicationDBContext : DbContext
    {
        //constructor
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Empleados> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().HasData(
                   new Rol { id = 1, Nombre = "Administrador" },
                   new Rol { id = 2, Nombre = "Vendedor" }
            );
        }
        public DbSet<Rol> Rol { get; set; }
    }
}
