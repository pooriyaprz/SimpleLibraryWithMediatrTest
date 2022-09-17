using Application.Books.Command.CreateBook;
using Application.BorrowedBooks.Command.Borrowed;
using Application.Common.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrraryApplicationTest.BorrowedBooks.Command
{
    using static Testing;

    public class BorrowedBooksTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldRequireMinimumFields()
        {
            BorrowedBookCommand? command = new BorrowedBookCommand();

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<FluentValidation.ValidationException>();
        }
        [Test]
        public async Task ShouldBorrowedBook()
        {
            var userId = await RunAsDefaultUserAsync();
            var newBook = new CreateBookCommand()
            {

                Name = "New Book",
                AuthorName = "New Author",
                Count = 3,
                ReleaseDate = System.DateTime.UtcNow
            };
            var command = await SendAsync(newBook);

            var entity = new BorrowedBookCommand()
            {

                BookId = command.Id,
                UserId = userId

            };
            var res = await SendAsync(entity);



            var item = await FindAsync<Domain.Entities.BorrowedBooks>(new Guid(res));

            item.Should().NotBeNull();


        }
        [Test]
        public async Task ShouldNotBorrowedBook()
        {
            var userId = await RunAsDefaultUserAsync();
            var newBook = new CreateBookCommand()
            {

                Name = "New Book",
                AuthorName = "New Author",
                Count = 1,
                ReleaseDate = System.DateTime.UtcNow
            };
            var command = await SendAsync(newBook);

            var entityOne = new BorrowedBookCommand()
            {

                BookId = command.Id,
                UserId = userId

            };
            var resOne = await SendAsync(entityOne);

            var entityTwo = new BorrowedBookCommand()
            {

                BookId = command.Id,
                UserId = userId

            };
          

            await FluentActions.Invoking(() =>
                SendAsync(entityTwo)).Should().ThrowAsync<OverLimitException>();


        }

    }
}
