using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Funda.Services;

namespace Funda.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHouseService _houseService;

        public HomeController(IHouseService houseService)
        {
            _houseService = houseService;
        }

        public async Task<ActionResult> Index()
        {
            var mostCommonSellers = await _houseService.GetMostCommonAmsterdamSellersAsync();

            return View();
        }
    }
}