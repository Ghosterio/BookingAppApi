using Data;
using DTO.RoomDto;
using Microsoft.EntityFrameworkCore;
using Repository.RoomRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RoomRepository;

public class RoomRepository(ApplicationContext context) : IRoomRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Room> _roomes = context.Set<Room>();

    public RoomDto Get(long id)
    {
        var room = _roomes.SingleOrDefault(a => a.ID == id);
        if (room == null) return null;
        return new RoomDto
        {
            ID = room.ID,
            Room_Name = room.Room_Name,
            BookingRoomID = room.BookingRoomID,
        };
    }
    public List<RoomDto> GetAll()
    {
        var roomes = _roomes.ToList();
        List<RoomDto> lroomes = new List<RoomDto>();
        foreach (var room in roomes)
        {
            lroomes.Add(new RoomDto
            {
                ID = room.ID,
                Room_Name = room.Room_Name,
                BookingRoomID = room.BookingRoomID,
            });
        }
        return lroomes;
    }
    public void Insert(CreateRoomDto dto)
    {
        Room room = new Room
        {
            Room_Name = dto.Room_Name,
            BookingRoomID = dto.BookingRoomID,
        };
        _roomes.Add(room);
        context.SaveChanges();
    }
    public void Update(UpdateRoomDto dto)
    {
        var room = _roomes.SingleOrDefault(a => a.ID == dto.ID);
        if (room == null) return;
        room.Room_Name = dto.Room_Name;
        room.BookingRoomID = dto.BookingRoomID;
        _roomes.Update(room);
        context.SaveChanges();
    }
    public void Delete(long id)
    {
        var room = _roomes.SingleOrDefault(a => a.ID == id);
        if (room == null) return;
        _roomes.Remove(room);
        context.SaveChanges();
    }
    public void SaveChanges()
    {
        context.SaveChanges();
    }
}
