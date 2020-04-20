using FluentValidation;
using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Validators
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("{PropertyName} can not be empty");
            RuleFor(x => x.LastName).NotNull().WithMessage("{PropertyName} can not be empty");
            RuleFor(x => x.DateOfBirth).GreaterThan(DateTime.Now.Date.AddYears(-120));
            RuleFor(x => x.DateOfBirth).LessThan(DateTime.Now.Date.AddYears(-18));
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
