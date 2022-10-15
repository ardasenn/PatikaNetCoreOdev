using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Applications.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IAppDbContext dbContext;
        private readonly IMapper mapper;

        public GetAuthorsQuery(IAppDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public List<GetAuthorsQueryModel> Handle()
        {
            var authorsList = dbContext.Authors.Include(a => a.Books).OrderBy(a => a.AuthorId);
            List<GetAuthorsQueryModel> model= mapper.Map<List<GetAuthorsQueryModel>>(authorsList);
            return model;

        }
    }
    public class GetAuthorsQueryModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
