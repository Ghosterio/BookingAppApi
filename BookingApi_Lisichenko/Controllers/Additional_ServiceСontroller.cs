using DTO.Additional_ServiceDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Additional_ServiceService;

namespace BookingApi_Lisichenko.Controllers;

[ApiController]
[Route("additional_service")]

public class Additional_ServiceСontroller(IAdditional_ServiceService additional_serviceService) : Controller
{
    [HttpGet]
    public JsonResult GetAdditional_Service()
    {
        var additional_service = additional_serviceService.GetAdditional_Service();
        return Json(additional_service);
    }
    
    [Route("{id}")]
    [HttpGet]
    public IActionResult GetAdditional_Service(long id)
    {
        var additional_service = additional_serviceService.GetAdditional_Service(id);
        if (additional_service == null) return NotFound("Услуга не найдена");
        return Json(additional_service);
    }
    [Authorize]
    [Route("create")]
    [HttpPost]
    public JsonResult CreateAdditional_Service(CreateAdditional_ServiceDto dto)
    {
        additional_serviceService.InsertAdditional_Service(dto);
        return Json("created");
    }
    [Authorize]
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateAdditional_Service(UpdateAdditional_ServiceDto dto)
    {
        additional_serviceService.UpdateAdditional_Service(dto);
        return Json("updated");
    }
    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteAdditional_Service(long id)
    {
        additional_serviceService.DeleteAdditional_Service(id);
        return Json("deleted");
    }
}
