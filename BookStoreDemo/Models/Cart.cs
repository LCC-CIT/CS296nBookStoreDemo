using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public Book BookToBuy { get; set; }
        public AppUser Customer { get; set; }
    }
}