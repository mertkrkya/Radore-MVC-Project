using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Radore_MVC_Project.Models;
using RestSharp;
using System.Collections.Generic;

namespace Radore_MVC_Project.Services
{
    public class APIService : IAPIService
    {
        private readonly RestClient _restClient;
        private readonly IConfiguration Configuration;
        public string API_URL { get; set; }
        public APIService(IConfiguration configuration)
        {
            _restClient = new RestClient();
            Configuration = configuration;
            API_URL = Configuration.GetValue<string>("API_URL");
        }
        public List<string> GetAll()
        {
            List<string> retList = new List<string>();
            var restRequest = new RestRequest(API_URL+"get-all-accounts", Method.Get);
            var restResponse = _restClient.Execute(restRequest);
            if (restResponse.IsSuccessful)
            {
                var result = restResponse.Content;
                retList = JsonConvert.DeserializeObject<List<string>>(result);
            }
            return retList;
        }
        public MessageDto CreateAccount(HostingDto hosting)
        {
            var restRequest = new RestRequest(API_URL + "create-account", Method.Post).AddBody(hosting);
            var restResponse = _restClient.Execute(restRequest);
            var result = restResponse.Content;
            var res = JsonConvert.DeserializeObject<MessageDto>(result);
            return res;
        }

        public MessageDto DeleteAccount(string hostingDomainName, string hostingPackage)
        {
            HostingDto hosting = new HostingDto();
            hosting.HostingPackage = hostingPackage;
            hosting.HostingDomainName = hostingDomainName;
            var restRequest = new RestRequest(API_URL + "delete-account", Method.Post).AddBody(hosting);
            var restResponse = _restClient.Execute(restRequest);
            var result = restResponse.Content;
            var res = JsonConvert.DeserializeObject<MessageDto>(result);
            return res;
        }

        public HostingDetailDto GetDetailByHostingDomainName(string hostingDomainName)
        {
            var restRequest = new RestRequest(API_URL + "get-account", Method.Get).AddParameter("hostingDomainName", hostingDomainName);
            var restResponse = _restClient.Execute(restRequest);
            if (restResponse.IsSuccessful)
            {
                var result = restResponse.Content;
                return JsonConvert.DeserializeObject<HostingDetailDto>(result);
            }
            return new HostingDetailDto();
        }

        public MessageDto UpdateAccount(HostingDetailDto hosting)
        {
            var restRequest = new RestRequest(API_URL + "create-account", Method.Post).AddBody(hosting);
            var restResponse = _restClient.Execute(restRequest);
            var result = restResponse.Content;
            var res = JsonConvert.DeserializeObject<MessageDto>(result);
            return res;
        }
    }
}
