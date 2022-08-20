using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Applications.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly AppDbContext dbContext;
        public int Id { get; set; } 
        public DeleteAuthorCommand(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Handle()
        {
            var author = dbContext.Authors.SingleOrDefault(a => a.AuthorId == Id);
            if (author == null) throw new System.Exception("Böyle bir kullanıcı zaten yok");

            dbContext.Authors.Remove(author);
            dbContext.SaveChanges();
        }
    } 
}
