using Client.Models.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.Validation
{
    public class UserPatchInfoValidator : AbstractValidator<UserPatchInfo>
    {
        public UserPatchInfoValidator()
        {
            RuleFor(x => x)
                .NotNull();
            When(x => x != null, () => { FieldRules(); });
        }

        private void FieldRules()
        {
            RuleFor(x => x)
                .Must(x => !(x.Password != null ^ x.ConfirmPassword != null))
                .WithMessage(@"Password and confirmation must be together null or not null");

            RuleFor(x => x.Login)
                .Length(3, 255)
                .When(x => x.Login != null)
                .WithMessage(@"Login must be 3..255 char length");
            RuleFor(x => x.Login)
                .Must(x => x.All(c => char.IsLetterOrDigit(c) || ValidationSymbols.SpecialChars.Contains(c)))
                .When(x => x.Login != null)
                .WithMessage(@"Login must include only letters\digits\spec symbols: " + ValidationSymbols.SpecialChars);

            RuleFor(x => x.Password)
                .Length(12, 255)
                .When(x => x.Password != null)
                .WithMessage(@"Password must be 12..255 char length");
            RuleFor(x => x.Password)
                .Must(x => x.All(c => char.IsLetterOrDigit(c) || ValidationSymbols.SpecialChars.Contains(c)))
                .When(x => x.Password != null)
                .WithMessage(@"Password must include only letters\digits\spec symbols: " + ValidationSymbols.SpecialChars);

            RuleFor(x => x.ConfirmPassword)
                .NotNull();
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .When(x => x.Password != null && x.ConfirmPassword != null)
                .WithMessage(@"Password confirmation must be equal to password");
        }
    }
}
