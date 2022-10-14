using FilmProjesi.DataAccesLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmProjesi.Fluentfilm
{
    public class FilmFluentValidator : AbstractValidator<Film>
    {
        public FilmFluentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Boş Bırakmayınız");
            RuleFor(x => x.Genre).NotEmpty().WithMessage("Boş Bırakmayınız");
            RuleFor(x => x.Director).NotEmpty().WithMessage("Boş Bırakmayınız");
            RuleFor(x => x.Year).NotEmpty().GreaterThan(1900).LessThan(2100).WithMessage("Girdiğiniz Tarih 1900 den büyük ve 2100'den küçük olmalı");
        }
    }
    
}
