using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.ValidationRules
{
    public class SettingsValidator : AbstractValidator<Settings>
    {
        public SettingsValidator()
        {
            RuleFor(x => x.Address).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(x => x.Address).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız");

            RuleFor(x => x.Phone).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(x => x.Phone).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");

            RuleFor(x => x.Email).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(x => x.Email).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");

            RuleFor(x => x.DirectorName).MinimumLength(10).WithMessage("En az 10 karakter girişi yapınız");
            RuleFor(x => x.DirectorName).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");

            RuleFor(x => x.Map).MinimumLength(10).WithMessage("En az 10 karakter girişi yapınız");
            RuleFor(x => x.Map).MaximumLength(500).WithMessage("En fazla 500 karakter girişi yapınız");

            RuleFor(x => x.Facebook).MinimumLength(10).WithMessage("En az 10 karakter girişi yapınız");
            RuleFor(x => x.Facebook).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");

            RuleFor(x => x.Twitter).MinimumLength(10).WithMessage("En az 10 karakter girişi yapınız");
            RuleFor(x => x.Twitter).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");

            RuleFor(x => x.Instagram).MinimumLength(10).WithMessage("En az 10 karakter girişi yapınız");
            RuleFor(x => x.Instagram).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");

            RuleFor(x => x.Linkedin).MinimumLength(10).WithMessage("En az 10 karakter girişi yapınız");
            RuleFor(x => x.Linkedin).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");

            RuleFor(x => x.Youtube).MinimumLength(10).WithMessage("En az 10 karakter girişi yapınız");
            RuleFor(x => x.Youtube).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapınız");
        }
    }
}
