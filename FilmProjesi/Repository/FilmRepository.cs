using EF.Core.Repository.Repository;
using FilmProjesi.DataAccesLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmProjesi.Repository
{
    public class FilmRepository : CommonRepository<Film>, IFilmRepository
    {
        public FilmRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
