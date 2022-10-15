using AutoMapper;
using FirstTest.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BookOperaitons.GetById;
using WebApi.DbOperations;
using Xunit;

namespace FirstTest.Application.BookOperations.Queries.GetById
{
    public class GetBookDetailQueryValidatorTest : IClassFixture<CommonTextFixture>
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;
        public GetBookDetailQueryValidatorTest(CommonTextFixture textFixture)
        {
            dbContext = textFixture.Context;
            mapper = textFixture.Mapper;
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            GetBookDetailQuery query = new(dbContext, mapper);
            query.BookId = id;
            GetBookDetailQueryValidator val = new();
            var result = val.Validate(query);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        public void WhenValidInputsAreGiven_Validator_ShouldBeReturnNull(int id)
        {
            GetBookDetailQuery query = new(dbContext, mapper);
            query.BookId = id;
            GetBookDetailQueryValidator val = new();
            var result = val.Validate(query);
            result.Errors.Count.Should().Be(0);
        }
    }
}
