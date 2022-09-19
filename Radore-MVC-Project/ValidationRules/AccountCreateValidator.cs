using FluentValidation;
using Radore_MVC_Project.Models;

namespace Radore_MVC_Project.ValidationRules
{
    public class AccountCreateValidator : AbstractValidator<HostingDto>
    {
        public AccountCreateValidator()
        {
            RuleFor(x => x.HostingDomainName).NotEmpty().NotNull().WithMessage("Hosting Domain Name is a required.");
            RuleFor(x => x.HostingPackage).NotEmpty().NotNull().WithMessage("Hosting Package Name is a required.");
        }
    }
}
