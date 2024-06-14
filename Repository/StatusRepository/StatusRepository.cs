using Data;
using DTO.StatusDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.StatusRepository;

public class StatusRepository(ApplicationContext context) : IStatusRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Status> _statuses = context.Set<Status>();

    public StatusDto Get(long id)
    {
        var status = _statuses.SingleOrDefault(a => a.ID == id);
        if (status == null) return null;
        return new StatusDto
        {
            ID = status.ID,
            Status_Info = status.Status_Info,
        };
    }
    public List<StatusDto> GetAll()
    {
        var statuses = _statuses.ToList();
        List<StatusDto> lstatuses = new List<StatusDto>();
        foreach (var status in statuses)
        {
            lstatuses.Add(new StatusDto
            {
                ID = status.ID,
                Status_Info = status.Status_Info,
            });
        }
        return lstatuses;
    }
    public void Insert(CreateStatusDto dto)
    {
        Status status = new Status
        {
            Status_Info = dto.Status_Info,
        };
        _statuses.Add(status);
        context.SaveChanges();
    }
    public void Update(UpdateStatusDto dto)
    {
        var status = _statuses.SingleOrDefault(a => a.ID == dto.ID);
        if (status == null) return;
        status.Status_Info = dto.Status_Info;
        _statuses.Update(status);
        context.SaveChanges();
    }
    public void Delete(long id)
    {
        var status = _statuses.SingleOrDefault(a => a.ID == id);
        if (status == null) return;
        _statuses.Remove(status);
        context.SaveChanges();
    }
    public void SaveChanges()
    {
        context.SaveChanges();
    }
}