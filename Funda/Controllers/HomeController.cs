using System.Threading.Tasks;
using System.Web.Mvc;
using Funda.Models;
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
            var model = new HomeViewModel();

            return View(model);
        }

        public async Task<ActionResult> AgentList(bool withGarden)
        {
            var model = new AgentListViewModel();
            model.AgentList = withGarden ?
                await _houseService.GetMostCommonAmsterdamAgentsAsync() :
                await _houseService.GetMostCommonGardenAgentsAsync();

            return View(model);
        }
    }
}