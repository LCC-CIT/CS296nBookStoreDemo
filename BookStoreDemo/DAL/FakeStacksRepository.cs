using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.DAL
{
    public class FakeStacksRepository : IStacksRepository
    {
        public Models.Stack AddStack(Models.Stack stack)
        {
            throw new NotImplementedException();
        }

        public int DeleteStackById(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Models.Stack> GetAllStacks()
        {
            throw new NotImplementedException();
        }

        public Models.Stack GetStackById(int? id)
        {
            throw new NotImplementedException();
        }

        public int UpdateStack(Models.Stack stack)
        {
            throw new NotImplementedException();
        }
    }
}