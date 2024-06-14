using DTO.PaymentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PaymentService;

public interface IPaymentService
{
    PaymentDto GetPayment(long id);
    List<PaymentDto> GetPayment();
    void InsertPayment(CreatePaymentDto dto);
    void UpdatePayment(UpdatePaymentDto dto);
    void DeletePayment(long id);
}