using Application.Books.Command.CreateBook;
using Application.Books.Command.UpdateBook;
using Application.Books.Queries.GetBook;
using Application.Books.Queries.GetBooksWithPagination;
using Application.Common.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Book>> Create(CreateBookCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, UpdateBookCommand command)
        {
            if (id != command.Id.ToString())
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<PaginatedList<BookBriefDto>>> GetAll([FromQuery] GetBooksWithPaginationQuery query)
        {

            var res = await Mediator.Send(query);

            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var res = await Mediator.Send(new GetBookQueryCommand(id));

            return Ok(res);
        }

    }
}
