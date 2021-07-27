using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");
            
            RuleFor(x => x.Value).MinimumLength(25).WithMessage("En az 25 karakter girişi yapınız");
        }
    }
}
