using Client.Models.Place;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.Validation
{
    public class PlaceFilterInfoValidator : AbstractValidator<PlaceFilterInfo>
    {
        public PlaceFilterInfoValidator()
        {
            RuleFor(x => x.OwnerId)
                .Must(x => Guid.TryParse(x, out var guid))
                .When(x => x.OwnerId != null)
                .WithMessage("OwnerId must be valid guid");

            RuleFor(x => x.PriceMin)
                .Must(x => x >= 0)
                .When(x => x.PriceMin != null)
                .WithMessage("Price must be non negative");

            RuleFor(x => x.PriceMax)
                .Must(x => x >= 0)
                .When(x => x.PriceMax != null)
                .WithMessage("Price must be non negative");

            RuleFor(x => x)
                .Must(x => x.PriceMax >= x.PriceMin)
                .When(x => x.PriceMax != null && x.PriceMin != null)
                .WithMessage("PriceMax cant be lesser than PriceMin");
        }
    }
}
