using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Validators
{
    public class ShortLinkCreateRequestValidator : AbstractValidator<ShortLinkCreateRequest>
    {
        public ShortLinkCreateRequestValidator()
        {
            RuleFor(r => r).NotNull();
            RuleFor(r => r.Url).NotEmpty();

            RuleFor(r => r.Url).Must(l => Uri.TryCreate(l, UriKind.Absolute, out Uri _)).WithMessage("Text is not a valid URL");
        }
    }
}