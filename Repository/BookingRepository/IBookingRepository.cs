using DTO.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.BookingRepository;

public interface IBookingRepository
{
    BookingDto Get(long id);
    List<BookingDto> GetAll();
    void Insert(CreateBookingDto dto);
    void Update(UpdateBookingDto dto);
    void Delete(long id);
    void SaveChanges();
}
