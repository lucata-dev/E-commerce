namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Ecommerce.Data;
    using Ecommerce.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            try
            {
                context.Categories.AddOrUpdate(new Category[]
                {
                    new Category{ Id = 1, Name = "Ropa masculina"},
                    new Category{ Id = 2, Name = "Ropa femenina" },
                    new Category{ Id = 3, Name = "Jugutes" },
                    new Category{ Id = 4, Name = "Videojuegos" },
                    new Category{ Id = 5, Name = "Deportes" }
                });

                context.States.AddOrUpdate(new State[]
                {
                    new State{ Name = "Pedido", Id = 1 },
                    new State{ Name = "Cancelado", Id = 2 },
                    new State{ Name = "Procesand", Id = 3 },
                    new State{ Name = "Entregado", Id = 4 }
                });

                
                //context.ApplicationRoles.AddOrUpdate(new ApplicationRole { Id = Guid.NewGuid().ToString(),  Name = "Admin" });
                //context.ApplicationRoles.AddOrUpdate(new ApplicationRole { Id = Guid.NewGuid().ToString(), Name = "Customer" });
            }
            catch(Exception)
            {

            }
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
