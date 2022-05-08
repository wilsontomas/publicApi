using Microsoft.EntityFrameworkCore;
using publicApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace publicApi.Dal.modelBuilder
{
    public static class usuarioTypeModelBuilder
    {
        public static void MapUsuarioType(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<usuarioType>(entity =>
            {
                entity.HasKey(x => x.id);
                entity.Property(x => x.id).HasColumnName("id");

                entity.Property(x => x.name).HasColumnName("name")
                .HasMaxLength(500);

                entity.HasData(
                    new usuarioType
                    {
                        id = 1,
                        name = "Usuario normal"
                    },
                      new usuarioType
                      {
                         id = 2,
                        name = "Usuario admin"
                    });

            });
        }
    }
}
