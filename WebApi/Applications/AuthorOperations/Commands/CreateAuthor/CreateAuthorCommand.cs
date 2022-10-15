using AutoMapper;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Applications.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly IAppDbContext dbContext;
        private readonly IMapper mapper;
        public CreateAuthorCommandModel Model { get; set; }
        public CreateAuthorCommand(IAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void Handle()
        {
            var author = dbContext.Authors.SingleOrDefault(a => a.FirstName == Model.FirstName && a.LastName == Model.LastName);
            if (author == null)
            {
                author = new Author();
                author = mapper.Map<Author>(Model);
                dbContext.Authors.Add(author);
                dbContext.SaveChanges();
            }
            else throw new InvalidOperationException("Böyle bir yazar zaten mevcut");
        }
    }
    public class CreateAuthorCommandModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
