using DataProtectionInServer.Models;
using DataProtectionInServer.Security;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataProtectionInServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHostEnvironment _host;

        public HomeController(ILogger<HomeController> logger, IHostEnvironment host)
        {
            _logger = logger;
            _host = host;
        }

        public IActionResult Index()
        {
            string key = "Aman bu ifade çok gizli";
            DataProtector dataProtector = new DataProtector(_host.ContentRootPath + "\\crypted.halkbank");
            int length = dataProtector.EncryptData(key);

            string decrypted = dataProtector.DecryptData(length);
            ViewBag.Data = decrypted;

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