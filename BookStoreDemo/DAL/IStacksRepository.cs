using System;
namespace BookStore.DAL
{
    public interface IStacksRepository
    {
        BookStore.Models.Stack AddStack(BookStore.Models.Stack stack);
        int DeleteStackById(int id);
        void Dispose();
        System.Collections.Generic.List<BookStore.Models.Stack> GetAllStacks();
        BookStore.Models.Stack GetStackById(int? id);
        int UpdateStack(BookStore.Models.Stack stack);
    }
}
