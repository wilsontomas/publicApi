using Microsoft.EntityFrameworkCore;
using publicApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace publicApi.Dal.modelBuilder
{
    public static class usuarioModelBuilder
    {
        public static void MapUsuario(this ModelBuilder modelBuilder) {

           

            modelBuilder.Entity<usuario>(entity =>
            {
                entity.HasKey(x => x.id);
                entity.Property(x => x.id).HasColumnName("id");

                entity.Property(x => x.firstName).HasColumnName("firstName")
                .HasMaxLength(500).IsRequired();

                entity.Property(x => x.lastName).HasColumnName("lastName")
                .HasMaxLength(500).IsRequired();

                entity.Property(x => x.userName).HasColumnName("userName")
               .HasMaxLength(500).IsRequired();

                entity.Property(x => x.passwordHash).HasColumnName("passwordHash")
               .HasMaxLength(500);

                entity.Property(x => x.passwordSalt).HasColumnName("passwordSalt")
                .HasMaxLength(500);

                entity.Property(x => x.usuarioType).HasColumnName("usuarioType")
                .IsRequired();

                entity.HasOne(x => x.usuarioType)
                        .WithMany(x => x.usuarios)
                        .HasForeignKey(x => x.typeId);

                
            });
        }
    }
}
