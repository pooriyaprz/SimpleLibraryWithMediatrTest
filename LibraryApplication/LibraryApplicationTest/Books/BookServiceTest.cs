using Application.Books.Command.CreateBook;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Persistance.DataBase;
using LibraryApplicationTest.DummyDataBase;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Xunit;

namespace LibraryApplicationTest.Books
{
    using static Testing;
    public class BookServiceTest
    {

        [Fact]
        private async Task CreateBookAsync()
        {
            CreateBookCommand? command = new CreateBookCommand();

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }
    }
}
