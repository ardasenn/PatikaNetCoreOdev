using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstTest.TestSetup;
using FluentAssertions;
using WebApi.Applications.GenreOperations.Commands.CreateGenre;
using WebApi.DbOperations;
using Xunit;

namespace FirstTest.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidatorTest :IClassFixture<CommonTextFixture>
    {
        private readonly AppDbContext db;
        
        public CreateGenreCommandValidatorTest(CommonTextFixture textFixture)
        {
            db = textFixture.Context;
        }
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("asd")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnError(string name)
        {
            CreateGenreCommand cmd =new CreateGenreCommand(db);
            CreateGenreModel model = new();
            model.Name = name;
            cmd.Model = model;
            CreateGenreCommandValidator val = new();
            var result=val.Validate(cmd);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
