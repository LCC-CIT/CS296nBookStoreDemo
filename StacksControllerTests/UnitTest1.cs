using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStore.DAL;
using BookStore.Models;
using System.Collections.Generic;
using BookStore.Controllers;
using System.Web.Mvc;


namespace StacksControllerTests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void IndexTest()
        {
            // arrange
            var stacks = new List<Stack>() {
                new Stack() {StackID = 1, Location = "Fiction"},
                new Stack() {StackID = 2, Location = "SciFi"},
                new Stack() {StackID = 3, Location = "Fantasy"}
            };

            var repo = new FakeStacksRepository(stacks);
            var target = new StacksController(repo);

            // act

            var result = (ViewResult)target.Index();

            // assert
            var model = (List<Stack>)result.Model;
            Assert.AreEqual(model[0].StackID, 1);
            Assert.AreEqual(model[1].StackID, 2);
            Assert.AreEqual(model[2].StackID, 3);
            Assert.AreEqual(model.Count, 3);
        }

        [TestMethod]
        public void DetailsTest()
        {
            // arrange
            // TODO: Make this DRY
            var stacks = new List<Stack>() {
                new Stack() {StackID = 1, Location = "Fiction"},
                new Stack() {StackID = 2, Location = "SciFi"},
                new Stack() {StackID = 3, Location = "Fantasy"}
            };

            var repo = new FakeStacksRepository(stacks);
            var target = new StacksController(repo);

            // act
            var result = (ViewResult)target.Details(2);

            // assert
            var model = (Stack)result.Model;
            Assert.AreEqual(stacks[1].StackID, model.StackID);
            Assert.AreEqual(stacks[1].Location, model.Location);

        }
    }
}
