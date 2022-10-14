using EF.Core.Repository.Interface.Repository;
using FilmProjesi.DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmProjesi.Repository
{
    public interface IFilmRepository:ICommonRepository<Film>
    {
    }
}
