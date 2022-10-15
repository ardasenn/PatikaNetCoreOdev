using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace FirstTest.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this AppDbContext context)
        {
            context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Finction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }
                );

        }
    }
}
