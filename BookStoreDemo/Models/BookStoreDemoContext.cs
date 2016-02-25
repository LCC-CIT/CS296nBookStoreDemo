using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class BookStoreDemoContext : IdentityDbContext<AppUser>
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    

        public BookStoreDemoContext() : base("name=BookStoreDemoContext")
        {
        }
        

        public DbSet<Stack> Stacks { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Models.Cart> Carts { get; set; }
    
    }
}
