using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GasPrice.Models;

namespace GasPrice.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGasRepo _repo;

        public HomeController(IGasRepo _repo)
        {
            this._repo = _repo;
        }

        public IActionResult Index()
        {
            var states = new StateList();

            return View(states);
        }

        public IActionResult ShowState(string selectedState)
        {
            var state = _repo.PricesForState(selectedState);

            return View(state);
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
