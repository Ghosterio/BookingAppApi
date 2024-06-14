using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Booking_DetailsDto;

public class UpdateBooking_DetailsDto
{
    public long ID { get; set; }
    public DateTime Chek_in_date { get; set; }
    public DateTime Eviction_date { get; set; }
    public bool Prepayment { get; set; }
    public DateTime Date_of_change { get; set; }
    public long PaymentID { get; set; }
    public long BookingID { get; set; }
    public string UserID { get; set; }
}
