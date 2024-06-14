using DTO.RoomDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RoomService;

public interface IRoomService
{
    RoomDto GetRoom(long id);
    List<RoomDto> GetRoom();
    void InsertRoom(CreateRoomDto dto);
    void UpdateRoom(UpdateRoomDto dto);
    void DeleteRoom(long id);
}
