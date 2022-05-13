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

                entity.Property(x => x.typeId).HasColumnName("typeId")
                .IsRequired();

                entity.HasOne(x => x.usuarioTypes)
                        .WithMany(x => x.usuarios)
                        .HasForeignKey(x => x.typeId);

                entity.HasData(new usuario
                {
                    id = 1,
                    firstName = "Wilson",
                    lastName = "Tomas",
                    userName = "wilsonpumm",
                    passwordHash = "GR3+HkbgU2DRg0zczdHTu4ytxd19QL785MhQm0UKoVe2q6Gq5p74XKOi6xY1hDqL7fRVFliiaayQG8X9mpixt1huXWPVb+cfVWMLvlLCpxet3CRYpCspVoL46GNeIDC7QrB1CcWv9g22DWNaKdo7k+RFEdrEX8tjz4TJbHa+qk9uhGNR6lEvvZAYk9/M2HxSL9TvFWN2qQX9ehFdrSGMeUeM1It/5PyTx6RyXLk5jRKlol9R12IFxyLOeXvf+vavvhSSX4dOxbPc7o3w43AKvWvsl/gg/MLxJ5zBkcQzjSOjd17TuXotCpS3vSCpxJ62gJzH3qB+JWGKM+tZVLDFpw==",
                    passwordSalt = "9/Ei/UNGaIJLaGrEu4q7X6hdxF07aQJkVtValltl5nqc38BB7Cy+n+Qx/Z3T//YIS94=",
                    typeId = 2,
                    email = "wilsonpumm@gmail.com"
                });
                
            });
        }
    }
}
