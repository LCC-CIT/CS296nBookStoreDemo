
using System;
using System.Collections.Generic;
using BookStore.Models;

namespace BookStore.DAL
{
    public class FakeStacksRepository : IStacksRepository
    {
        private List<Stack> stacks;
        private int lastStackId = 0;

        public FakeStacksRepository()
        {
            stacks = new List<Stack>();
        }

        // Use this to initialize the fake repo with test data
        public FakeStacksRepository(List<Stack> s)
        {
            stacks = s;
        }


        public Stack AddStack(Stack stack)
        {
           stacks.Add(stack);
            stack.StackID = lastStackId++;
            return stack;
        }

        public Stack DeleteStackById(int id)
        {
            Stack stack = GetStackById(id);
            stacks.Remove(stack);
            return stack;
        }

        public List<Stack> GetAllStacks()
        {
            return stacks;
        }

        public Stack GetStackById(int? id)
        {
            int i = id ?? 0;
            return stacks.Find(s => s.StackID == i);
        }

        public int UpdateStackById(Stack stack)
        {
            int stacksUpdated = 0;
            if (DeleteStackById(stack.StackID) != null)
            {
                stacks.Add(stack);
                stacksUpdated = 1;
            }
            return stacksUpdated;
        }

        public void Dispose()
        {
            // Noting to do;
        }
    }
}