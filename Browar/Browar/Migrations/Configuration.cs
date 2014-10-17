namespace Browar.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Browar.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Browar.Models.BrowarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Browar.Models.BrowarContext context)
        {
            context.Browarnias.AddOrUpdate(x => x.Id,
                new Browarnia() { Id = 1, Name = "Lech" },
                new Browarnia() { Id = 2, Name = "Bosman" },
                new Browarnia() { Id = 3, Name = "Okocim" }
                );

            context.Piwoes.AddOrUpdate(x => x.Id,
                new Piwo()
                {
                    Id = 1,
                    Name = "Bosman",
                    Power = 5.6,
                    BrowarniaId = 2,
                    Price = 2.00,
                    Genre = "Lager"
                },
                new Piwo()
                {
                    Id = 2,
                    Name = "Lech",
                    Power = 5.2,
                    BrowarniaId = 1,
                    Price = 3.00,
                    Genre = "Lager"
                },
                new Piwo()
                {
                    Id = 3,
                    Name = "Okocim",
                    Power = 5.8,
                    BrowarniaId = 3,
                    Price = 2.80,
                    Genre = "Lager"
                },
                new Piwo()
                {
                    Id = 4,
                    Name = "Karmi Black",
                    Power = 2.0,
                    BrowarniaId = 3,
                    Price = 3.30,
                    Genre = "Dark lager"
                }
                );
        }
    }
}
