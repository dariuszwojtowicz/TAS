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
                new Browarnia() { Id = 3, Name = "Okocim" });

            context.Users.AddOrUpdate(x => x.Id,
                new User() { Id = 1, Name = "Dariusz", Login = "daro", Password = "qwerty", Mail = "darospeed1992@gmail.com", Age = 22 },
                new User() { Id = 2, Name = "Maciej", Login = "maciej", Password = "qwerty", Mail = "m@gmail.com", Age = 22},
                new User() { Id = 3, Name = "Patryk", Login = "patryk", Password = "qwerty", Mail = "p@gmail.com", Age = 22});

            context.Rates.AddOrUpdate(x => x.Id, 
                new Rate() { Id = 1, PiwoId = 1, UserId = 1, Value = 7 }, 
                new Rate() { Id = 2, PiwoId = 2, UserId = 2, Value = 8 }, 
                new Rate() { Id = 3, PiwoId = 4, UserId = 3, Value = 5 });

            context.Comments.AddOrUpdate(x => x.Id,
                new Comment() { Id = 1, PiwoId = 1, UserId = 1, Text = "Sch³odzone jest nawet spoko." },
                new Comment() { Id = 2, PiwoId = 2, UserId = 2, Text = "Dzieñ bez zimnego lecha jest dniem straconym." },
                new Comment() { Id = 3, PiwoId = 4, UserId = 3, Text = "To zdecydowanie babskie piwo." });


            context.Piwoes.AddOrUpdate(x => x.Id,
                new Piwo()
                {
                    Id = 1,
                    Name = "Bosman",
                    Power = 5.6,
                    BrowarniaId = 2,
                    Price = 2.00,
                    Genre = "Lager",
                    Img = string.Empty
                },
                new Piwo()
                {
                    Id = 2,
                    Name = "Lech",
                    Power = 5.2,
                    BrowarniaId = 1,
                    Price = 3.00,
                    Genre = "Lager",
                    Img = string.Empty
                },
                new Piwo()
                {
                    Id = 3,
                    Name = "Okocim",
                    Power = 5.8,
                    BrowarniaId = 3,
                    Price = 2.80,
                    Genre = "Lager",
                    Img = string.Empty
                },
                new Piwo()
                {
                    Id = 4,
                    Name = "Karmi Black",
                    Power = 2.0,
                    BrowarniaId = 3,
                    Price = 3.30,
                    Genre = "Dark lager",
                    Img = string.Empty });
        }
    }
}
