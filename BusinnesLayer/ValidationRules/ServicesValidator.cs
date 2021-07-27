using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.ValidationRules
{
    public class ServicesValidator : AbstractValidator<Service>
    {
        public ServicesValidator()
        {
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");

            RuleFor(x => x.Value).MinimumLength(20).WithMessage("En az 20 karakter girişi yapınız");
            RuleFor(x => x.Value).MaximumLength(600).WithMessage("En fazla 600 karakter girişi yapınız");

        }
    }
}
