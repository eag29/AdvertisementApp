using EmirAliGirgin.AdvertisementApp2.Business.Interfaces;
using EmirAliGirgin.AdvertisementApp2.UI.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceService _service;
        private readonly IAdvertisementService _advertisementService;

        public HomeController(IProvidedServiceService service, IAdvertisementService advertisementService)
        {
            _service = service;
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _service.GetAllAsync();
            return this.ResponseView(values);
        }
        public async Task<IActionResult> HumanResource()
        {
            var response = await _advertisementService.GetActivesAsync();
            return this.ResponseView(response);
        }
    }
}
