using DTO.PaymentDto;
using Repository.PaymentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PaymentService;

public class PaymentService(IPaymentRepository paymentRepository) : IPaymentService
{
    private IPaymentRepository _paymentRepository = paymentRepository;

    public PaymentDto GetPayment(long id)
    {
        return _paymentRepository.Get(id);
    }

    public List<PaymentDto> GetPayment()
    {
        return _paymentRepository.GetAll();
    }

    public void InsertPayment(CreatePaymentDto dto)
    {
        _paymentRepository.Insert(dto);
    }

    public void UpdatePayment(UpdatePaymentDto dto)
    {
        _paymentRepository.Update(dto);
    }

    public void DeletePayment(long id)
    {
        _paymentRepository.Delete(id);
    }
}