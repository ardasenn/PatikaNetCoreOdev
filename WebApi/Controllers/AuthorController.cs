using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.AuthorOperations.Commands.CreateAuthor;
using WebApi.Applications.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Applications.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Applications.AuthorOperations.Queries.GetAuthorDetails;
using WebApi.Applications.AuthorOperations.Queries.GetAuthors;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAppDbContext dbContext;
        private readonly IMapper mapper;

        public AuthorController(IAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(dbContext, mapper);
            var result=query.Handle();
            return Ok(result);
        }
        [HttpGet("id")]
        public IActionResult GetAuthorDetail(int id)
        {
            GetAuthorDetailQuery query=new GetAuthorDetailQuery(dbContext, mapper);
            query.Id = id;
            GetAuthorDetailQueryValidator val = new GetAuthorDetailQueryValidator();

            val.ValidateAndThrow(query); // validasyonlar okey mi ?

            var result= query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAuthor(CreateAuthorCommandModel model)
        {
            CreateAuthorCommand cmd= new CreateAuthorCommand(dbContext, mapper);
            cmd.Model=model;

            CreateAuthorCommandValidator val= new CreateAuthorCommandValidator();
            val.ValidateAndThrow(cmd);
            cmd.Handle();

            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateAuthor(UpdateAuthorCommandModel model,int id)
        {
            UpdateAuthorCommand cmd = new UpdateAuthorCommand(dbContext, mapper);
            cmd.Id = id;
            cmd.Model=model;
            UpdateAuthorCommandValidator val = new UpdateAuthorCommandValidator();
            val.ValidateAndThrow(cmd);

            cmd.Handle();

            return Ok();
        }
        [HttpDelete("id")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand cmd= new DeleteAuthorCommand(dbContext);
            cmd.Id = id;
            DeleteAuthorCommandValidator val= new DeleteAuthorCommandValidator();
            val.ValidateAndThrow(cmd);

            cmd.Handle();
            return Ok();
        }
    }
}
