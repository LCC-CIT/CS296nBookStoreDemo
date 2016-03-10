using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStore.DAL
{
    public class StacksRepository : IDisposable, IStacksRepository
    {
        BookStoreDemoContext db = new BookStoreDemoContext();

        public List<Stack> GetAllStacks()
        {
            return db.Stacks.ToList();
        }

        public Stack GetStackById(int? id)
        {
            return db.Stacks.Find(id);
        }

        public Stack AddStack(Stack stack)
        {
            Stack dbStack = db.Stacks.Add(stack);
            db.SaveChanges();
            return dbStack;
        }

        public int UpdateStackById(Stack stack)
        {
            db.Entry(stack).State = EntityState.Modified;
            return db.SaveChanges();  // returns the number of objects saved
        }

        public Stack DeleteStackById(int id)
        {
            Stack stack = GetStackById(id);
            db.Stacks.Remove(stack);
            db.SaveChanges();
            return stack;
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}