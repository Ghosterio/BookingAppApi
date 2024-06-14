using DTO.RoomDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RoomRepository;

public interface IRoomRepository
{
    RoomDto Get(long id);
    List<RoomDto> GetAll();
    void Insert(CreateRoomDto dto);
    void Update(UpdateRoomDto dto);
    void Delete(long id);
    void SaveChanges();
}
