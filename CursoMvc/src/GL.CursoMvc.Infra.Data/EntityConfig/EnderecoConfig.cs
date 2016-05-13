using System.Data.Entity.ModelConfiguration;
using GL.CursoMvc.Domain.Entities;

namespace GL.CursoMvc.Infra.Data.EntityConfig
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e => e.EnderecoId);

            Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(100);

            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.CEP)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8);

            Property(e => e.Complemento)
                .HasMaxLength(100);

            /*Como existe um relacionamento das classes Endereco - Cliente, devemos usar o 'HasRequired'.
             Ou seja, existe um Cliente requirido para tal Endereco, onde o meu Cliente tem uma coleção de 
             Endereços e tudo isso se dá devido a chave estrangeira 'ClienteId' contida na classe Endereco*/
            HasRequired(e => e.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.ClienteId);

            ToTable("Enderecos");

        }
    }
}