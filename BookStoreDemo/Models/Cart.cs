using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Cart
    {
        private List<Book> books = new List<Book>();
        private AppUser customer = new AppUser();

        public int CartID { get; set; }
        public List<Book> Books {get { return books;}}
        public AppUser Customer { 
            get { return customer; }
            set { customer = value; }
        }
    }
}