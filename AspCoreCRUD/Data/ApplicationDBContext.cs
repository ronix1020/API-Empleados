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
    }
}
