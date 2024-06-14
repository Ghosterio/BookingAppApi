using DTO.StatusDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.StatusService;

namespace BookingApi_Lisichenko.Controllers;

[ApiController]
[Route("status")]

public class StatusСontroller(IStatusService statusService) : Controller
{
    [HttpGet]
    public JsonResult GetStatus()
    {
        var status = statusService.GetStatus();
        return Json(status);
    }

    [Route("{id}")]
    [HttpGet]
    public IActionResult GetStatus(long id)
    {
        var status = statusService.GetStatus(id);
        if (status == null) return NotFound("Статус не найден");
        return Json(status);
    }
    [Authorize]
    [Route("create")]
    [HttpPost]
    public JsonResult CreateStatus(CreateStatusDto dto)
    {
        statusService.InsertStatus(dto);
        return Json("created");
    }
    [Authorize]
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateStatus(UpdateStatusDto dto)
    {
        statusService.UpdateStatus(dto);
        return Json("updated");
    }
    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteStatus(long id)
    {
        statusService.DeleteStatus(id);
        return Json("deleted");
    }
}