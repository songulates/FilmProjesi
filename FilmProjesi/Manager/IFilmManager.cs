using EF.Core.Repository.Interface.Manager;
using FilmProjesi.DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmProjesi.Manager
{
    public interface IFilmManager:ICommonManager<Film>
    {
    }
}
