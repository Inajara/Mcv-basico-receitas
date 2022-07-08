using System;
using System.Collections.Generic;
using System.Text;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesafioMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Categoria>Categorias{get; set;}
        public DbSet<Medida>Medidas{get; set;}
        public DbSet<Ingrediente>Ingredientes{get; set;}
        public DbSet<Receita>Receitas{get; set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
