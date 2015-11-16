namespace sqlTest.Migrations {
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<sqlTest.Models.DataContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(sqlTest.Models.DataContext context) {
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
            context.Movies.AddOrUpdate(
                m => m.Title,
                new Movie { Title = "Star Wars", Director = "George Lucas", Description = "A great space battle that happend a long long time ago, in a galaxy far far away." },
                new Movie { Title = "Star Trek", Director = "JJ Abrams", Description = "Aliens in the future don't like what happened in the past. Also Kirk" },
                new Movie { Title = "Avatar", Director = "James Cameron", Description = "Space pocahontas" },
                new Movie { Title = "Spaceballs", Director = "Mel Gibson", Description = "A goofy space quest for more money." }
                );
        }
    }
}
