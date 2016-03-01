namespace BookStore.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookStore.Models.BookStoreDemoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BookStore.Models.BookStoreDemoContext";
        }

        protected override void Seed(BookStore.Models.BookStoreDemoContext context)
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

            Book mobyDick =
                new Book { Title = "Moby Dick", Author = "Herman Melville", Price = 11.99m };
            Book readyPlayerOne =
                new Book { Title = "Ready Player One", Author = "Ernest Cline", Price = 14.00m };
            Stack stack1 = new Stack { Location = "A1", Books = { mobyDick, readyPlayerOne } };
            Book grapesOfWrath =
                new Book { Title = "The Grapes of Wrath", Author = "John Steinbeck", Price = 12.49m };
            Book incorrigibleChildren =
                new Book { Title = "The Incorrigible Children of Ashton Place", Author = "Maryrose Wood", Price = 10.89m };
            Stack stack2 = new Stack { Location = "A2", Books = { grapesOfWrath, incorrigibleChildren } };

            context.Books.AddOrUpdate(b => b.Title, mobyDick, readyPlayerOne, grapesOfWrath, incorrigibleChildren);
            context.Stacks.AddOrUpdate(s => s.Location, stack1, stack2);
         }
    }
}
