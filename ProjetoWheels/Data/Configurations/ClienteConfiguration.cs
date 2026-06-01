using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoWheels.Models;

namespace ProjetoWheels.Data.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasData(
            new Cliente
            {
                Id = 1,
                Nome = "Felipe Lourenço",
                CPF = "12345678900",
                Email = "felipe@gmail.com",
                Telefone = "21999999999"
            }
        );
    }
}