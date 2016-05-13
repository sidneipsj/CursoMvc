using System.Data.Entity.Migrations;
using GL.CursoMvc.Infra.Data.Context;

namespace GL.CursoMvc.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CursoMvcContext>
    {
        public Configuration()
        {
            //Estamos trocando para 'true' para que possa realizar as atualizações do 'Migrations'
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CursoMvcContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}