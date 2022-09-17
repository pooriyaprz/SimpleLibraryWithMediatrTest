using Application.Books.Command.CreateBook;
using Application.Books.Command.UpdateBook;
using Application.Common.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrraryApplicationTest.Book.Command
{
    using static Testing;

    public class UpdateBookTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldRequireValidTodoItemId()
        {
            var command = new UpdateBookCommand { Id = Guid.NewGuid(), Name = "New Name", AuthorName = "New AuthorName", ReleaseDate = DateTime.Now, Count = 2 };
            await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateTodoItem()
        {
            var userId = await RunAsDefaultUserAsync();

            var book = await SendAsync(new CreateBookCommand
            {  Name = "New Name", AuthorName = "New AuthorName", ReleaseDate = DateTime.Now, Count = 2 });

      

            var command = new UpdateBookCommand
            {
                Id = book.Id,
                Name = "New Name",
                AuthorName = "New AuthorName",
                ReleaseDate = DateTime.Now,
                Count = 3
            };

            await SendAsync(command);

            var item = await FindAsync<Domain.Entities.Book>(command.Id);

            item.Should().NotBeNull();

            item.Name.Should().Be(command.Name);
            item.AuthorName.Should().Be(command.AuthorName);
            item.Count.Should().Be(command.Count);
            item.ReleaseDate.Should().Be(command.ReleaseDate);
        }
    }

}
