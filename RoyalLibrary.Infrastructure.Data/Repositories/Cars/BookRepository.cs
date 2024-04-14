using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Text;
using Dapper;
using RoyalLibrary.Domain.Entities.Book;
using RoyalLibrary.Domain.QueriesResults;
using RoyalLibrary.Domain.Repositories.Interface;
using RoyalLibrary.Domain.Repositories.Interface.Book;


namespace RoyalLibrary.Infrastructure.Data.Repositories.Cars
{
    public class BookRepository : IBookRepository
    {
        protected DbConnection _conn { get; }
        
        public BookRepository(IContext context)
        {
            _conn = context.Connection;
        }

        public IEnumerable<ListBookQueryResult> Get(BookFilter filter, string orderBy, int top, int skip, bool allRegisters, out int total)
        {
            var query = new StringBuilder();
            dynamic param = new ExpandoObject();

            param.Title = filter.Title;
            param.Author = filter.Author;      

            param.top = top > 0 ? top : 10;
            param.skip = skip >= 0 ? skip : 0;

            query.AppendLine(@"SELECT [book_id] AS ID,
                                      [title], 
                                      [first_name] AS FirstName,
                                      [last_name] AS LastName,
                                      [total_copies] AS TotalCopies,
                                      [copies_in_use] AS CopiesInUse,
                                      [type], 
                                      [isbn],
                                      [category] FROM BOOKS where 1 = 1");

            if (!string.IsNullOrWhiteSpace(filter.Author))
                query.AppendLine("AND (first_name like '%' + @Author + '%' OR last_name like '%' + @Author + '%')");

            if (!string.IsNullOrWhiteSpace(filter.Title))
                query.AppendLine("AND Title like '%' + @Title + '%'");

            var queryCount = query.ToString();
            total = _conn.Query(queryCount, (object)param).ToList().Count;

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                var s = orderBy.Split(' ');
                var field = s[0];
                query.AppendLine($"ORDER BY [{field}] {(s.Length > 1 ? s[1] : string.Empty)}");
            }
            else
                query.AppendLine("ORDER BY Title");

            if (!allRegisters)
            {
                query.AppendLine(" OFFSET @skip ROWS");
                query.AppendLine(" FETCH NEXT @top ROWS ONLY");
            }
      
            return  _conn.Query<ListBookQueryResult>(query.ToString() , (object)param);    
        }
    }
}
