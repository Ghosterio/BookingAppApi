using DTO.Main_ServiceDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Main_ServiceService;

namespace BookingApi_Lisichenko.Controllers;

[ApiController]
[Route("main_service")]

public class Main_ServiceСontroller(IMain_ServiceService main_serviceService) : Controller
{
    [HttpGet]
    public JsonResult GetMain_Service()
    {
        var main_service = main_serviceService.GetMain_Service();
        return Json(main_service);
    }

    [Route("{id}")]
    [HttpGet]
    public IActionResult GetMain_Service(long id)
    {
        var main_service = main_serviceService.GetMain_Service(id);
        if (main_service == null) return NotFound("Услуга не найдена");
        return Json(main_service);
    }
    [Authorize]
    [Route("create")]
    [HttpPost]
    public JsonResult CreateMain_Service(CreateMain_ServiceDto dto)
    {
        main_serviceService.InsertMain_Service(dto);
        return Json("created");
    }
    [Authorize]
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateMain_Service(UpdateMain_ServiceDto dto)
    {
        main_serviceService.UpdateMain_Service(dto);
        return Json("updated");
    }
    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteMain_Service(long id)
    {
        main_serviceService.DeleteMain_Service(id);
        return Json("deleted");
    }
}
