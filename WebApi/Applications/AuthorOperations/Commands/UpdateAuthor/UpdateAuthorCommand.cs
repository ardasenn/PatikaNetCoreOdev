using AutoMapper;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Applications.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly IAppDbContext dbContext;
        private readonly IMapper mapper;
        public int Id { get; set; }
        public UpdateAuthorCommandModel Model { get; set; }
        public UpdateAuthorCommand(IAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void Handle()
        {
            var author = dbContext.Authors.SingleOrDefault(a => a.AuthorId == Id);
            if (author == null) throw new InvalidOperationException("Böyle bir kullanıcı yok");
            //author = mapper.Map<Author>(Model);   Bu yapı benim authoreuma bakmıyor değerleri siliyor yada yeni bir instance alıyor bilmiyorum ama bu durumda bu kullanılamaz.
            author=mapper.Map<UpdateAuthorCommandModel,Author>(Model,author);
            dbContext.Authors.Update(author);
            dbContext.SaveChanges();
        }
    }
    public class UpdateAuthorCommandModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
