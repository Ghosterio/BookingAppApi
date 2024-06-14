using DTO.PaymentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.PaymentRepository;

public interface IPaymentRepository
{
    PaymentDto Get(long id);
    List<PaymentDto> GetAll();
    void Insert(CreatePaymentDto dto);
    void Update(UpdatePaymentDto dto);
    void Delete(long id);
    void SaveChanges();
}