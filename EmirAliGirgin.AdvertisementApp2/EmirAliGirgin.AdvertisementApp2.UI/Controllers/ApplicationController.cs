using EmirAliGirgin.AdvertisementApp2.Business.Interfaces;
using EmirAliGirgin.AdvertisementApp2.Dtos;
using EmirAliGirgin.AdvertisementApp2.UI.Extensions;
using EmirAliGirgin.AdvertisementApp2.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.UI.Controllers
{
    [Authorize(Roles="Admin")]
    public class ApplicationController : Controller
    {
        private readonly IAdvertisementService _advertisementService;

        public ApplicationController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> List()
        {
            var list = await _advertisementService.GetAllAsync();
            return this.ResponseView(list);
        }

        public IActionResult Create()
        {
            return View(new CreateAdvertisementDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAdvertisementDto dto)
        {
            var createdValue = await _advertisementService.CreateAsync(dto);
            return this.ResponseRedirectAction(createdValue, "List");
        }

        public async Task<IActionResult> Update(int id)
        {
            var data = await _advertisementService.GetByIdAsync<UpdateAdvertisementDto>(id);
            return this.ResponseView(data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAdvertisementDto dto)
        {
            var response = await _advertisementService.UpdateAsync(dto);
            return this.ResponseRedirectAction(response, "List");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _advertisementService.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "List");
        }
    }
}
