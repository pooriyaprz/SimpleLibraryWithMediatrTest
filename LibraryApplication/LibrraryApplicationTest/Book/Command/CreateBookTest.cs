using Application.Books.Command.CreateBook;
using Application.Common.Exceptions;

using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace LibrraryApplicationTest.Book.Command
{
    using static Testing;

    public class CreateBookTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldRequireMinimumFields()
        {
            CreateBookCommand? command = new CreateBookCommand();

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<FluentValidation.ValidationException>();
        }
        [Test]
        public async Task ShouldCreateBook()
        {
 
            var newBook = new CreateBookCommand()
            {
                
                Name = "New Book",
                AuthorName = "New Author",
                Count = 3,
                ReleaseDate = System.DateTime.UtcNow
            };
          var command= await SendAsync(newBook);



            var item = await FindAsync<Domain.Entities.Book>(command.Id);

            item.Should().NotBeNull();

            item.Name.Should().Be(newBook.Name);
            item.AuthorName.Should().Be(newBook.AuthorName);
            item.Count.Should().Be(newBook.Count);
            item.ReleaseDate.Should().Be(newBook.ReleaseDate);
        }

    }
}