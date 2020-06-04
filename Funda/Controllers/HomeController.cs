using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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

        public ActionResult Index()
        {
            var model = new HomeViewModel();

            return View(model);
        }

        public async Task<ActionResult> AgentList(bool withGarden)
        {
            var model = new AgentListViewModel();

            try
            {
                model.AgentList = withGarden ?
                    await _houseService.GetMostCommonAmsterdamAgentsAsync() :
                    await _houseService.GetMostCommonGardenAgentsAsync();
            }
            catch (HttpException ex)
            {
                return new HttpStatusCodeResult(ex.GetHttpCode());
            }

            return View(model);
        }
    }
}