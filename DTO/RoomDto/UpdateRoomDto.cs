using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.RoomDto;

public class UpdateRoomDto
{
    public long ID { get; set; }
    public string Room_Name { get; set; }
    public long BookingRoomID { get; set; }
}
