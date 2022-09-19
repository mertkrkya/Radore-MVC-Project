using FluentValidation;
using Radore_MVC_Project.Models;

namespace Radore_MVC_Project.ValidationRules
{
    public class AccountUpdateValidator : AbstractValidator<HostingDetailDto>
    {
        public AccountUpdateValidator()
        {
            RuleFor(x => x.HostingDomainName).NotEmpty().NotNull().WithMessage("Hosting Domain Name is a required.");
            RuleFor(x => x.HostingPackage).NotEmpty().NotNull().WithMessage("Hosting Package Name is a required.");
            RuleFor(x => x.IncomingConnections).InclusiveBetween(1, int.MaxValue).WithMessage($"Incoming Connections must be between 1 to {int.MaxValue}.");
            RuleFor(x => x.RamMax).InclusiveBetween(1, int.MaxValue).WithMessage($"Ram Max must be between 1 to {int.MaxValue}.");
            RuleFor(x => x.CpuLoad).InclusiveBetween(1, int.MaxValue).WithMessage($"Cpu Load must be between 1 to {int.MaxValue}.");
            RuleFor(x => x.RamUsage).InclusiveBetween(1, int.MaxValue).WithMessage($"RamUsage must be between 1 to {int.MaxValue}.");
        }
    }
}
