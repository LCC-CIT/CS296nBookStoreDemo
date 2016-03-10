using System.Collections.Generic;
using BookStore.Models;

namespace BookStore.DAL
{
    public interface IStacksRepository
    {
        Stack AddStack(Stack stack);
        Stack DeleteStackById(int id);
        List<Stack> GetAllStacks();
        Stack GetStackById(int? id);
        int UpdateStackById(Stack stack);
        void Dispose();
    }
}