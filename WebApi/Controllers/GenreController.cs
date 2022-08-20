using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.GenreOperations.Commands.CreateGenre;
using WebApi.Applications.GenreOperations.Commands.DeleteGenre;
using WebApi.Applications.GenreOperations.Commands.UpdateGenre;
using WebApi.Applications.GenreOperations.Queries.GetGenreDetail;
using WebApi.Applications.GenreOperations.Queries.GetGenres;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public GenreController(AppDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetGenre()
        {
            GetGenresQuery query = new GetGenresQuery(dbContext, mapper);
            var obj = query.Handle();
            return Ok(obj);
        }
        [HttpGet("id")]
        public IActionResult GetGenreDetail(int id)
        {
            GenGenreDetailQuery query= new GenGenreDetailQuery(dbContext, mapper);
            query.GenreId=id;

            GenGenreDetailQueryValidator validator= new GenGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);//validasyon kontrolü yapar

            var result=query.Handle();
           return Ok(result);
        }
        [HttpPost]
        public IActionResult AddGenre(CreateGenreModel newGenre)
        {
            CreateGenreCommand cmd = new CreateGenreCommand(dbContext);
            cmd.Model = newGenre;
            CreateGenreCommandValidator validator= new CreateGenreCommandValidator();
            validator.ValidateAndThrow(cmd); // validasyon kontrol

            cmd.Handle();
           return  Ok();
        }
        [HttpPut("id")]
        public IActionResult UpdateGenre(UpdateGenreModel updateGenre,int id)
        {
            UpdateGenreCommand cmd= new UpdateGenreCommand(dbContext,id);
            cmd.GenreId = id;
            cmd.Model = updateGenre;
            UpdateGenreCommandValidator validator= new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(cmd);

            cmd.Handle();
            return Ok();
        }
        [HttpDelete("id")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand cmd = new DeleteGenreCommand(dbContext);
            cmd.GenreId = id;
            DeleteGenreCommandValidator validator= new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(cmd);

            cmd.Handle();
            return Ok();
        }
    }
}
