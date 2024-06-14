using DTO.PaymentDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.PaymentService;

namespace BookingApi_Lisichenko.Controllers;

[ApiController]
[Route("payment")]

public class PaymentController(IPaymentService paymentService) : Controller
{
    [HttpGet]
    public JsonResult GetPayment()
    {
        var payment = paymentService.GetPayment();
        return Json(payment);
    }
    
    [Route("{id}")]
    [HttpGet]
    public IActionResult GetPayment(long id)
    {
        var payment = paymentService.GetPayment(id);
        if (payment == null) return NotFound("Оплата не найдена");
        return Json(payment);
    }
    [Authorize]
    [Route("create")]
    [HttpPost]
    public JsonResult CreatePayment(CreatePaymentDto dto)
    {
        paymentService.InsertPayment(dto);
        return Json("created");
    }
    [Authorize]
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdatePayment(UpdatePaymentDto dto)
    {
        paymentService.UpdatePayment(dto);
        return Json("updated");
    }
    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeletePayment(long id)
    {
        paymentService.DeletePayment(id);
        return Json("deleted");
    }
}
