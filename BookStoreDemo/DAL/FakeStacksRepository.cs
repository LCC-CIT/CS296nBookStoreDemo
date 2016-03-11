using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.DAL
{
    public class FakeStacksRepository : IStacksRepository
    {
        private List<Stack> stacks;
        private int maxId = 0;

        public FakeStacksRepository()
        {
            stacks = new List<Stack>();
        }

        public FakeStacksRepository(List<Stack> s)
        {
            stacks = s;
        }

        public Stack AddStack(Stack stack)
        {
            stack.StackID = ++maxId;
            stacks.Add(stack);
            return stack;
        }

        public Stack DeleteStackById(int id)
        {
            Stack stack = GetStackById(id);
            stacks.Remove(stack);
            return stack;
        }

        public void Dispose()
        {
            // nothing to do;
        }

        public List<Models.Stack> GetAllStacks()
        {
            return stacks;
        }

        public Models.Stack GetStackById(int? id)
        {
            return stacks.Find(s => s.StackID == id);
        }

        public int UpdateStack(Stack stack)
        {
            int stackUpdated = 0;
            if(DeleteStackById(stack.StackID) != null)
            {
                stacks.Add(stack);
                stackUpdated = 1;
            }

            return stackUpdated;
        }
    }
}