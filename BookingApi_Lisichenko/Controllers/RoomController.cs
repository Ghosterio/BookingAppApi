using DTO.RoomDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.RoomService;

namespace BookingApi_Lisichenko.Controllers;

[ApiController]
[Route("room")]

public class RoomСontroller(IRoomService roomService) : Controller
{
    [HttpGet]
    public JsonResult GetRoom()
    {
        var room = roomService.GetRoom();
        return Json(room);
    }

    [Route("{id}")]
    [HttpGet]
    public IActionResult GetRoom(long id)
    {
        var room = roomService.GetRoom(id);
        if (room == null) return NotFound("Комната не найден");
        return Json(room);
    }
    [Authorize]
    [Route("create")]
    [HttpPost]
    public JsonResult CreateRoom(CreateRoomDto dto)
    {
        roomService.InsertRoom(dto);
        return Json("created");
    }
    [Authorize]
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateRoom(UpdateRoomDto dto)
    {
        roomService.UpdateRoom(dto);
        return Json("updated");
    }
    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteRoom(long id)
    {
        roomService.DeleteRoom(id);
        return Json("deleted");
    }
}
