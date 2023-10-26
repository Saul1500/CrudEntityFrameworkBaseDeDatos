using Guia_Entity_Framework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ContextDB : DbContext
{
    public DbSet<Student> Estudiantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-POJ0MVA\\SQLEXPRESS;Database=PrograII;Trusted_Connection=True;");
    
    }
}
