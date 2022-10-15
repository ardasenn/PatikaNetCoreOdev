using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DbOperations;

namespace FirstTest.TestSetup
{
    public class CommonTextFixture
    {
        public AppDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTextFixture()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "BookStoretestDB").Options;
            Context = new AppDbContext(options);//belirttiğimiz ayarlardaki contexti oluşturduk
            Context.Database.EnsureCreated();//oluştugundan emin olmak için bunu yazdık

            Context.AddBooks();
            Context.AddGenres();
            Context.SaveChanges();
            //mapper configürasyonların web apide çektik aşağıda
            Mapper = new MapperConfiguration(cfg => {cfg.AddProfile<MappingProfile>();}).CreateMapper();

        }
    }
}
