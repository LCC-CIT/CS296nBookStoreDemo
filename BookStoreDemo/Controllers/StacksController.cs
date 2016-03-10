using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.DAL;

namespace BookStore.Controllers
{
    public class StacksController : Controller
    {
       // private BookStoreDemoContext db = new BookStoreDemoContext();
        private StacksRepository repo = new StacksRepository();

        // GET: /Stacks/
        public ActionResult Index()
        {
            return View(repo.GetAllStacks());
        }

        // GET: /Stacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stack stack = repo.GetStackById(id);
            if (stack == null)
            {
                return HttpNotFound();
            }
            return View(stack);
        }

        // GET: /Stacks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Stacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="StackID,Location")] Stack stack)
        {
            if (ModelState.IsValid)
            {
                repo.AddStack(stack);
                return RedirectToAction("Index");
            }

            return View(stack);
        }

        // GET: /Stacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stack stack = repo.GetStackById(id);
            if (stack == null)
            {
                return HttpNotFound();
            }
            return View(stack);
        }

        // POST: /Stacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="StackID,Location")] Stack stack)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateStack(stack);
                return RedirectToAction("Index");
            }
            return View(stack);
        }

        // GET: /Stacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stack stack = repo.GetStackById(id);
            if (stack == null)
            {
                return HttpNotFound();
            }
            return View(stack);
        }

        // POST: /Stacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.DeleteStackById(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
