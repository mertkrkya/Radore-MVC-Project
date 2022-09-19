using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Radore_MVC_Project.Models;
using Radore_MVC_Project.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Radore_MVC_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAPIService _apiService;
        public AccountController(IAPIService apiService)
        {
            _apiService = apiService;
        }
        public IActionResult Index()
        {
            var accounts = _apiService.GetAll();
            List<HostingDetailDto> hostingDetails = new List<HostingDetailDto>();
            foreach (var item in accounts)
            {
                hostingDetails.Add(_apiService.GetDetailByHostingDomainName(item));
            }
            return View(hostingDetails.OrderBy(r => r.HostingDomainName).ToList());
        }
        [HttpGet]
        public IActionResult CreateAccount()
        {
            return View(new HostingDto());
        }

        [HttpPost]
        public IActionResult CreateAccount(HostingDto hosting)
        {
            if (ModelState.IsValid)
            {
                var res = _apiService.CreateAccount(hosting);
                if (res.Message.Contains("Created/updated"))
                    TempData["message"] = "Added";
                else
                    TempData["message"] = "Error";
                return RedirectToAction("Index");
            }
            else
                return View("CreateAccount",hosting);
        }
        [HttpGet]
        public IActionResult UpdateAccount(string hostingDomainName)
        {
            var account = _apiService.GetDetailByHostingDomainName(hostingDomainName);
            return View(account);
        }

        [HttpPost]
        public IActionResult UpdateAccount(HostingDetailDto hosting)
        {
            if (ModelState.IsValid)
            {
                var res = _apiService.UpdateAccount(hosting);
                if (res.Message.Contains("Created/updated"))
                    TempData["message"] = "Updated";
                else
                    TempData["message"] = "Error";
                return RedirectToAction("Index");
            }
            else
                return View("UpdateAccount",hosting);
        }
        public IActionResult DeleteAccount(string hostingDomainName, string hostingPackage)
        {
            var res = _apiService.DeleteAccount(hostingDomainName,hostingPackage);
            if (res.Message.Contains("Deleted"))
                TempData["message"] = "Deleted";
            else
                TempData["message"] = "Error";
            return RedirectToAction("Index");
        }
    }
}
