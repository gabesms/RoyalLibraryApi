using RoyalLibrary.Domain.Entities.Book;
using RoyalLibrary.Domain.QueriesResults;
using System.Collections.Generic;

namespace RoyalLibrary.Domain.Repositories.Interface.Book
{
    public interface IBookRepository
    {
        IEnumerable<ListBookQueryResult> Get(BookFilter filter, string orderBy, int top, int skip, bool AllRegisters, out int total); 
    }
}
