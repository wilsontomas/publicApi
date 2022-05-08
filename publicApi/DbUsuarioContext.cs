using Microsoft.EntityFrameworkCore;
using publicApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using publicApi.Dal.modelBuilder;
namespace publicApi.Dal
{
    public class DbUsuarioContext : DbContext
    {
        public DbUsuarioContext(DbContextOptions<DbUsuarioContext> options)
           : base(options)
        {
            
        }

      
        public virtual DbSet<usuario> Usuarios { get; set; }
         public virtual DbSet<Tareas> Tareas { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder opBuilder)
        {
            opBuilder.UseSqlServer("Data Source=DESKTOP-18URBP1;Initial Catalog=db_usuario;Integrated Security=True");
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.MapUsuario();
            modelBuilder.MapTareas();
            modelBuilder.MapUsuarioType();

        }
    }
}
