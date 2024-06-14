using DTO.Booking_DetailsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Booking_DetailsService;

namespace BookingApi_Lisichenko.Controllers;

[ApiController]
[Route("booking_details")]

public class Booking_DetailsController(IBooking_DetailsService booking_detailsService) : Controller
{
    
    [HttpGet]
    public JsonResult GetBooking_Details()
    {
        var booking_details = booking_detailsService.GetBooking_Details();
        return Json(booking_details);
    }

    [Route("{id}")]
    [HttpGet]
    public IActionResult GetBooking_Details(long id)
    {
        var booking_details = booking_detailsService.GetBooking_Details(id);
        if (booking_details == null) return NotFound("Данные не найдены");
        return Json(booking_details);
    }
    [Authorize]
    [Route("create")]
    [HttpPost]
    public JsonResult CreateBooking_Details(CreateBooking_DetailsDto dto)
    {
        booking_detailsService.InsertBooking_Details(dto);
        return Json("created");
    }
    [Authorize]
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateBooking_Details(UpdateBooking_DetailsDto dto)
    {
        booking_detailsService.UpdateBooking_Details(dto);
        return Json("updated");
    }
    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteBooking_Details(long id)
    {
        booking_detailsService.DeleteBooking_Details(id);
        return Json("deleted");
    }
}