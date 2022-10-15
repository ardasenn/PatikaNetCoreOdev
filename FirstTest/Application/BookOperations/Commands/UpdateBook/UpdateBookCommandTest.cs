using AutoMapper;
using FirstTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using Xunit;

namespace FirstTest.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandTest : IClassFixture<CommonTextFixture>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public UpdateBookCommandTest(CommonTextFixture textFixture)
        {
            context = textFixture.Context;
            mapper= textFixture.Mapper;
        }
        
    }
}
