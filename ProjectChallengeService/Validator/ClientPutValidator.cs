using FluentValidation;
using ProjectChallengeDomain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChallengeService.Validator
{
    public class ClientPutValidator : AbstractValidator<ClientRequestPut>
    {
        public ClientPutValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null.");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id can not be empty.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty.");
            RuleFor(x => x.Name).NotNull().WithMessage("Name can not be null.");
            RuleFor(x => x.Age).GreaterThan(0).WithMessage("Age should be bigger than 0.");
            RuleFor(x => x.Age).NotNull().WithMessage("Age can not be null.");
        }

    }
}
