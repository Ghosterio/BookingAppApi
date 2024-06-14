using DTO.RoomDto;
using Repository.RoomRepository;
using Service.RoomService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RoomService;

public class RoomService(IRoomRepository roomRepository) : IRoomService
{
    private IRoomRepository _roomRepository = roomRepository;

    public RoomDto GetRoom(long id)
    {
        return _roomRepository.Get(id);
    }

    public List<RoomDto> GetRoom()
    {
        return _roomRepository.GetAll();
    }

    public void InsertRoom(CreateRoomDto dto)
    {
        _roomRepository.Insert(dto);
    }

    public void UpdateRoom(UpdateRoomDto dto)
    {
        _roomRepository.Update(dto);
    }

    public void DeleteRoom(long id)
    {
        _roomRepository.Delete(id);
    }
}
