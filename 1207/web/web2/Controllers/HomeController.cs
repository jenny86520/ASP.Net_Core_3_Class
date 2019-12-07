using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using web2.Models;

namespace web2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Profile _profile;

        public HomeController(ILogger<HomeController> logger, IOptionsSnapshot<Profile> profile)
        {
            _logger = logger;
            _profile = profile.Value;   // Class-1207: 練習設定組態並注入 IOptionsSnapshot<T> 物件
        }

        public IActionResult Index()
        {
            return View(_profile);
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
