using Contract;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PromFutureTest.Models;
using System.Diagnostics;
using static System.Net.WebRequestMethods;

namespace PromFutureTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IConfiguration _configuration;

        public HomeController(IAuthenticateService authenticateService, IConfiguration configuration)
        {
            _authenticateService = authenticateService;
            _configuration = configuration;
        }
        private AuthenticateModel GetAuthenticateModel()
        {
            var authSection = _configuration.GetSection("Authenticate");
            var url = authSection.GetValue<string>("Url");
            var login = authSection.GetValue<string>("Login");
            var password = authSection.GetValue<string>("Password");
            return new AuthenticateModel {Url=url, Login= login, Password = password };

        }
        


        public async Task<IActionResult> Index()
        {
            var model = GetAuthenticateModel();

            var user = await _authenticateService.Authenticate(model);
            return RedirectToAction("GetCommand", new { user.Token });
        }
        public async Task<IActionResult> GetCommand(string token)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient
                    .GetAsync($"http://178.57.218.210:398/commands/types?token={token}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<CommandModel>(apiResponse);
                    
                }
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}