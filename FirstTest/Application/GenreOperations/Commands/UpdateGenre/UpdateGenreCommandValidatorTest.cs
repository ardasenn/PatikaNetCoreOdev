using AutoMapper;
using FirstTest.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Applications.GenreOperations.Commands.UpdateGenre;
using WebApi.DbOperations;
using Xunit;

namespace FirstTest.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidatorTest : IClassFixture<CommonTextFixture>
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;
        public UpdateGenreCommandValidatorTest(CommonTextFixture textFixture)
        {
            db = textFixture.Context;
            mapper = textFixture.Mapper;
        }
        [Theory]
        [InlineData(" ",0)]
        [InlineData("lkjsdfhnas", 0)]
        //[InlineData("", 1)]//bu case model kısmında çözülmüştü
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name,int genreId)
        {
            UpdateGenreCommand cmd = new(db, genreId) { Model=new UpdateGenreModel() { Name=name,IsActive=true}};
            UpdateGenreCommandValidator val = new();
            var result=val.Validate(cmd);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
