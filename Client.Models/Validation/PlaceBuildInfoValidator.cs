using Client.Models.Place;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.Validation
{
    public class PlaceBuildInfoValidator : AbstractValidator<PlaceBuildInfo>
    {
        private const string  plainTextSpecChars = @"|\'""~№_<>(){}[]!?.,;:@#$%^&+-*/=";
        public PlaceBuildInfoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull();
            RuleFor(x => x.Name)
                .Length(3, 50)
                .When(x => x.Name != null)
                .WithMessage(@"Name must be 3..50 symbols length");
            RuleFor(x => x.Name)
                .Must(x=>x.All(c=>char.IsLetterOrDigit(c) || plainTextSpecChars.Contains(c)))
                .When(x => x.Name != null)
                .WithMessage(@"Name must contain only letters\digits\space\spec symbols: "+ plainTextSpecChars);
            RuleFor(x => x.Address)
                .NotNull();
            RuleFor(x => x.Address)
                .Length(5, 150)
                .When(x => x.Address != null)
                .WithMessage(@"Address must be 5..150 symbols length");
            RuleFor(x => x.Name)
                .Must(x => x.All(c => char.IsLetterOrDigit(c) || plainTextSpecChars.Contains(c)))
                .When(x => x.Address != null)
                .WithMessage(@"Address must contain only letters\digits\space\spec symbols: " + plainTextSpecChars);
            RuleFor(x => x.Description)
                .NotNull();
            RuleFor(x => x.Description)
                .Length(10, 500)
                .When(x => x.Description != null)
                .WithMessage(@"Description must be 10..500 symbols length");
            RuleFor(x => x.Description)
                .Must(x => x.All(c => char.IsLetterOrDigit(c) || plainTextSpecChars.Contains(c)))
                .When(x => x.Description != null)
                .WithMessage(@"Description must contain only letters\digits\space\spec symbols: " + plainTextSpecChars);
            RuleFor(x => x.Price)
                .InclusiveBetween(0, 99999)
                .WithMessage(@"Price must be in range 0..99999");
        }
    }
}
