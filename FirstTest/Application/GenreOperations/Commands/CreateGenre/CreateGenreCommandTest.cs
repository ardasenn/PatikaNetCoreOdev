using AutoMapper;
using FirstTest.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Applications.GenreOperations.Commands.CreateGenre;
using WebApi.DbOperations;
using Xunit;

namespace FirstTest.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandTest : IClassFixture<CommonTextFixture>
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;
        public CreateGenreCommandTest(CommonTextFixture textFixture)
        {
            db = textFixture.Context;
            mapper = textFixture.Mapper;
        }
        [Theory]
        [InlineData("Romance")]
        [InlineData("Science Finction")]
        public void WhenExistGenresAreGiven_InvalidOperation_ShouldBeReturnErrors(string name)
        {
            CreateGenreModel model = new() { Name=name};
            CreateGenreCommand cmd = new(db) { Model=model};
            FluentActions.Invoking(() => cmd.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü zaten mevcut");
        }
    }
}
