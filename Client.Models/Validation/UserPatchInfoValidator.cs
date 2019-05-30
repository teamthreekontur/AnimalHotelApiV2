﻿using Client.Models.User;
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
        private const string validSpecCharsForLogin = @",.-";
        private const string validSpecCharsForPass = @"|\'""~№_<>(){}[]!?.,;:@#$%^&+-*/=";
        public UserPatchInfoValidator()
        {
            RuleFor(x => x.Login)
                .Length(3, 255)
                .When(x => x.Login != null)
                .WithMessage(@"Login must be 3..255 char length");
            RuleFor(x => x.Login)
                .Must(x => x.All(c => char.IsLetterOrDigit(c) || validSpecCharsForLogin.Contains(c)))
                .When(x => x.Login != null)
                .WithMessage(@"Login must include only letters\digits\spec symbols: " + validSpecCharsForLogin);
            RuleFor(x => x.Password)
                .Length(12, 255)
                .When(x => x.Password != null)
                .WithMessage(@"Password must be 12..255 char length");
            RuleFor(x => x.Password)
                .Must(x => x.All(c => char.IsLetterOrDigit(c) || validSpecCharsForPass.Contains(c)))
                .When(x => x.Password != null)
                .WithMessage(@"Password must include only letters\digits\spec symbols: " + validSpecCharsForPass);
        }
    }
}
