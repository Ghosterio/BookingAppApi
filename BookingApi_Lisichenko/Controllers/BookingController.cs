using DTO.BookingDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.BookingService;

namespace BookingApi_Lisichenko.Controllers;

[ApiController]
[Route("booking")]

public class BookingController(IBookingService bookingService) : Controller
{
    [HttpGet]
    public JsonResult GetBooking()
    {
        var booking = bookingService.GetBooking();
        return Json(booking);
    }

    [Route("{id}")]
    [HttpGet]
    public IActionResult GetBooking(long id)
    {
        var booking = bookingService.GetBooking(id);
        if (booking == null) return NotFound("Статус не найден");
        return Json(booking);
    }
    [Authorize]
    [Route("create")]
    [HttpPost]
    public JsonResult CreateBooking(CreateBookingDto dto)
    {
        bookingService.InsertBooking(dto);
        return Json("created");
    }
    [Authorize]
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateBooking(UpdateBookingDto dto)
    {
        bookingService.UpdateBooking(dto);
        return Json("updated");
    }
    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteBooking(long id)
    {
        bookingService.DeleteBooking(id);
        return Json("deleted");
    }
}