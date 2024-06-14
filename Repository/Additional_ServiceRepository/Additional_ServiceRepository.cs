using Data;
using DTO.Additional_ServiceDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Additional_ServiceRepository;

public class Additional_ServiceRepository(ApplicationContext context) : IAdditional_ServiceRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Additional_Service> _additional_services = context.Set<Additional_Service>();

    public Additional_ServiceDto Get(long id)
    {
        var additional_service = _additional_services.SingleOrDefault(a => a.ID == id);
        if (additional_service == null) return null;
        return new Additional_ServiceDto
        {
            ID = additional_service.ID,
            Service = additional_service.Service,
            Price = additional_service.Price,
        };
    }
    public List<Additional_ServiceDto> GetAll()
    {
        var additional_services = _additional_services.ToList();
        List<Additional_ServiceDto> ladditional_services = new List<Additional_ServiceDto>();
        foreach (var additional_service in additional_services)
        {
            ladditional_services.Add(new Additional_ServiceDto
            {
                ID = additional_service.ID,
                Service = additional_service.Service,
                Price = additional_service.Price,
            });
        }
        return ladditional_services;
    }
    public void Insert(CreateAdditional_ServiceDto dto)
    {
        Additional_Service additional_service = new Additional_Service
        {
            Service = dto.Service,
            Price = dto.Price,
        };
        _additional_services.Add(additional_service);
        context.SaveChanges();
    }
    public void Update(UpdateAdditional_ServiceDto dto)
    {
        var additional_service = _additional_services.SingleOrDefault(a => a.ID == dto.ID);
        if (additional_service == null) return;
        additional_service.Service = dto.Service;
        additional_service.Price = dto.Price;
        _additional_services.Update(additional_service);
        context.SaveChanges();
    }
    public void Delete(long id)
    {
        var additional_service = _additional_services.SingleOrDefault(a => a.ID == id);
        if (additional_service == null) return;
        _additional_services.Remove(additional_service);
        context.SaveChanges();
    }
    public void SaveChanges()
    {
        context.SaveChanges();
    }
}