using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStore.Controllers;
using BookStore.Models;
using System.Linq;

namespace BooStoreTests
{
    [TestClass]
    public class BooksControllerTests
    {
        [TestMethod]
        public void SearchTest()
        {
            // arrange
            var target = new BooksController();
            const string BOOK_TITLE = "Grapes of Wrath";
            /*
            // act
            var view = (ViewResult)target.Search(BOOK_TITLE);

            // assert
            var viewModels = (List<BookViewModel>)view.Model;
            Assert.AreEqual(AUTHOR1_NAME, viewModels[0].Author.Name);
            Assert.AreEqual(BOOK1_TITLE, viewModels[0].Title);
            Assert.AreEqual(AUTHOR1_NAME, viewModels[1].Author.Name);
            Assert.AreEqual(BOOK2_TITLE, viewModels[1].Title);
            */
        }

        [TestMethod]
        public void CreateTest()
        {
            // arrange
            var target = new BooksController();

            const string AUTHOR = "Lois Lowry";
            const string TITLE = "The Giver";
            const string ISBN = "0-553-57133-8 ";
            const decimal PRICE = 12.95m;
            var bookVM = new BookViewModel() { Author = AUTHOR, Title = TITLE, ISBN = ISBN, Price = PRICE };

            const int STACK_ID = 1;

            // act
            target.Create(bookVM, STACK_ID);

            // assert
            var context = new BookStoreDemoContext();
            var book = (from b in context.Books where b.ISBN.Equals(ISBN) select b).FirstOrDefault();
            Assert.AreEqual(book.Title, TITLE);
        }
    }
}
