using Radore_MVC_Project.Models;
using System.Collections.Generic;

namespace Radore_MVC_Project.Services
{
    public interface IAPIService
    {
        List<string> GetAll();
        HostingDetailDto GetDetailByHostingDomainName(string hostingDomainName);
        MessageDto CreateAccount(HostingDto hosting);
        MessageDto UpdateAccount(HostingDetailDto hosting);
        MessageDto DeleteAccount(string hostingDomainName, string hostingPackage);

    }
}
