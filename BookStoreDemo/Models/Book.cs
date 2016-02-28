using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public int StackID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal? Price { get; set; }
        public string ISBN { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}