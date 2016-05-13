using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using GL.CursoMvc.Domain.Entities;
using GL.CursoMvc.Infra.Data.EntityConfig;

namespace GL.CursoMvc.Infra.Data.Context
{
    public class CursoMvcContext : DbContext 
    {
        public CursoMvcContext()
            : base("DefaultConnection")
        {
            //Default
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        //Esse método serve para que toda vez que for criar um novo modelo na base de dados
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Aqui estamos usando o 'PluralizingTableNameConvention' para evitar que o Migrations coloque o nome da tabela no plural
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Aqui estamos dizendo que, em um relacionamento de 1 para 1 e n para n não haverá um 'on cascade delete'
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            /*Aqui estamos configurando que, toda vez que uma determinada propriedade tiver um nome e mais o ID
             definiremos como uma chave primária*/
            modelBuilder.Properties()
                .Where(p=> p.Name == p.ReflectedType.Name + "Id")
                .Configure(p=> p.IsKey());

            /*Aqui estamos configurando que, todas as vezes que uma determinada propertie for do tipo
             'string' que deverá ser do tipo 'varchar' e para que a coluna tenha no máximo 150 caracteres*/
            modelBuilder.Properties<string>()
                .Configure(p=> p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p=> p.HasMaxLength(100));

            /*Aqui estamos adicionando as configurações realizadas da classe: 'ClienteConfig' na nossa
             classe de Context*/
            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());

            base.OnModelCreating(modelBuilder);
        }

        /* Esse método aqui é do tipo Generico e vai realizar a modificação da 'DataCadastro' vai funcionar da maneira
         * como o código abaixo */
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry=> 
                entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}