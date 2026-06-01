using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoWheels.Models;

namespace ProjetoWheels.Data.Configurations;

public class BicicletaConfiguration : IEntityTypeConfiguration<Bicicleta>
{
    public void Configure(EntityTypeBuilder<Bicicleta> builder)
    {
        builder.HasData(
            new Bicicleta
            {
                Id = 1,
                Marca = "Caloi",
                Tipo = "Elite Carbon",
                Tamanho = "26",
                ValorDiaria = 15,
                Status = StatusBicicleta.Disponivel
            }
        );
    }
}