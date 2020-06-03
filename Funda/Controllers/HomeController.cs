using System.Threading.Tasks;
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
            var mostCommonAmsterdamAgents = await _houseService.GetMostCommonAmsterdamAgentsAsync();
            var mostCommonAmsterdamGardenAgents = await _houseService.GetMostCommonGardenAgentsAsync();

            return View();
        }
    }
}