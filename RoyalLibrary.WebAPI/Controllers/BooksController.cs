using Microsoft.AspNetCore.Mvc;
using RoyalLibrary.Domain.Commands.Books;
using RoyalLibrary.Domain.Entities.Book;
using RoyalLibrary.Domain.Handlers;
using RoyalLibrary.Domain.QueriesResults;
using RoyalLibrary.Domain.Repositories.Interface.Books;
using RoyalLibrary.WebAPI.Controllers.Util;
using System.Collections.Generic;


namespace RoyalLibrary.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]    
    [ApiController]        
    public class BooksController : ControllerBase
    {

        private readonly IBookRepository _repository;
        private readonly BookHandler _handler;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public BooksController(IBookRepository repository, BookHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        /// <summary>
        /// Return a list of books filtered with pagination
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="sorting"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet]        
        public ActionResult<IEnumerable<ListBookQueryResult>> Get([FromQuery] BookFilter filter = null, [FromQuery] Sorting sorting = null, [FromQuery] Pagination pagination = null)
        {
            var result = _repository.Get(filter, sorting.OrderBy, pagination.Top, pagination.Skip, pagination.AllRegisters, out int total);

            Response.Headers.Add("X-content-range", total.ToString());
            Response.Headers.Add("Access-Control-Expose-Headers", "X-content-range,content-range");

            return Ok(result);
        }

        /// <summary>
        /// Add a new Book to the library
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] CreateBookCommand cmd)
        {
            var result = _handler.Handle(cmd);
            return Ok(result);
        }
    }
}
