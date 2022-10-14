using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using FilmProjesi.DataAccesLayer;
using FilmProjesi.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmProjesi.Manager
{
    public class FilmManager : CommonManager<Film>, IFilmManager
    {
        public FilmManager(DbContext dbContext) : base(new FilmRepository(dbContext))
        {
        }
    }
}
