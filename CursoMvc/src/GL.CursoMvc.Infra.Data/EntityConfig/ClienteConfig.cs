using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using GL.CursoMvc.Domain.Entities;

namespace GL.CursoMvc.Infra.Data.EntityConfig
{
    /*Esse método aqui iremos configurar alguns detalhes da nossa tabela inerente a classe: Cliente.
     Como por ex.: se olharmos o script da tabela gerada pelo migrations, iremos ver que os campos: CEP e CPF
     estão com tamanho não de acordo com o tipo do campo. Assim que iremos configurar agora esses detalhes */
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.ClienteId);
            //HasKey(c => new {c.ClienteId, c.CPF}); //aqui definimos uma chave composta

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);
                //.HasColumnName("CLI_Nome");

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true })); //aqui esta dizendo que esse campo é indexado e que não pode obter outro CPF com o mesmo número

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            ToTable("Clientes"); //Definir o nome da tabela

        }
    }
}