using Microsoft.EntityFrameworkCore;
using publicApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace publicApi.Dal.modelBuilder
{
    public static class tareasModelBuilder
    {
        public static void MapTareas(this ModelBuilder modelBuilder) 
        {

            modelBuilder.Entity<Tareas>(entity =>
            {
                entity.HasKey(x => x.id);
                entity.Property(x => x.id).HasColumnName("id");

                entity.Property(x => x.name).HasColumnName("name")
                .HasMaxLength(500);

                entity.Property(x => x.message).HasColumnName("message")
               .HasMaxLength(3000);

                entity.Property(x => x.usuarioId).HasColumnName("usuarioId")
                .IsRequired();

                entity.HasOne(x => x.usuario)
                        .WithMany(x => x.tareas)
                        .HasForeignKey(x => x.usuarioId);
            });
        }
    }
}
