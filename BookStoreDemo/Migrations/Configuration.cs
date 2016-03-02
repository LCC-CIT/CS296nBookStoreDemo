namespace BookStore.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BookStore.Models.BookStoreDemoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BookStore.Models.BookStoreDemoContext";
        }

        protected override void Seed(BookStore.Models.BookStoreDemoContext context)
        {
            // Create Book and Stack entities
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

            // Add a user
            UserManager<AppUser> userManager = new UserManager<AppUser>(
              new UserStore<AppUser>(new BookStoreDemoContext()));

            var user = new AppUser{UserName = "birdb@lanecc.edu", NickName = "Brian" };
            var result = userManager.Create(user, "password");

            // Add a role
            context.Roles.Add(new IdentityRole() { Name = "Admin" });
            context.SaveChanges();

            // Add role to user
            userManager.AddToRole(user.Id, "Admin");

        }
    }
}
