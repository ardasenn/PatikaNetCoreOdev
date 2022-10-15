using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Applications.AuthorOperations.Queries.GetAuthorDetails
{
    public class GetAuthorDetailQuery
    {
        private readonly IAppDbContext dbContext;
        private readonly IMapper mapper;

        public int Id { get; set; }
        public GetAuthorDetailQuery(IAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public GetAuthorDetailQueryModel Handle()
        {
            var author = dbContext.Authors.Include(a=>a.Books).SingleOrDefault(a => a.AuthorId == Id);
            if (author == null) throw new InvalidOperationException("Böyle bir Yazar henüz mevcut değil");
            return mapper.Map<GetAuthorDetailQueryModel>(author);
        }

    }

    public class GetAuthorDetailQueryModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
