using Application.BorrowedBooks.Command.Borrowed;
using Application.BorrowedBooks.Command.Returned;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BorrowBookController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Create(BorrowedBookCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost("returnBook")]
        public async Task<ActionResult<string>> returnBook(ReturnedBookCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
