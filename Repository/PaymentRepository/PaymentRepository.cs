using Data;
using DTO.PaymentDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.PaymentRepository;

public class PaymentRepository(ApplicationContext context) : IPaymentRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Payment> _payments = context.Set<Payment>();

    public PaymentDto Get(long id)
    {
        var payment = _payments.SingleOrDefault(a => a.ID == id);
        if (payment == null) return null;
        return new PaymentDto
        {
            ID = payment.ID,
            Payment_Info = payment.Payment_Info,
        };
    }
    public List<PaymentDto> GetAll()
    {
        var payments = _payments.ToList();
        List<PaymentDto> lpayments = new List<PaymentDto>();
        foreach (var payment in payments)
        {
            lpayments.Add(new PaymentDto
            {
                ID = payment.ID,
                Payment_Info = payment.Payment_Info,
            });
        }
        return lpayments;
    }
    public void Insert(CreatePaymentDto dto)
    {
        Payment payment = new Payment
        {
            Payment_Info = dto.Payment_Info,
        };
        _payments.Add(payment);
        context.SaveChanges();
    }
    public void Update(UpdatePaymentDto dto)
    {
        var payment = _payments.SingleOrDefault(a => a.ID == dto.ID);
        if (payment == null) return;
        payment.Payment_Info = dto.Payment_Info;
        _payments.Update(payment);
        context.SaveChanges();
    }
    public void Delete(long id)
    {
        var payment = _payments.SingleOrDefault(a => a.ID == id);
        if (payment == null) return;
        _payments.Remove(payment);
        context.SaveChanges();
    }
    public void SaveChanges()
    {
        context.SaveChanges();
    }
}