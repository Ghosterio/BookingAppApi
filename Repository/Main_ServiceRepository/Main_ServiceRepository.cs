using Data;
using DTO.Main_ServiceDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Main_ServiceRepository;

public class Main_ServiceRepository(ApplicationContext context) : IMain_ServiceRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Main_Service> _main_services = context.Set<Main_Service>();

    public Main_ServiceDto Get(long id)
    {
        var main_service = _main_services.SingleOrDefault(a => a.ID == id);
        if (main_service == null) return null;
        return new Main_ServiceDto
        {
            ID = main_service.ID,
            Service = main_service.Service,
        };
    }
    public List<Main_ServiceDto> GetAll()
    {
        var main_services = _main_services.ToList();
        List<Main_ServiceDto> lmain_services = new List<Main_ServiceDto>();
        foreach (var main_service in main_services)
        {
            lmain_services.Add(new Main_ServiceDto
            {
                ID = main_service.ID,
                Service = main_service.Service,
            });
        }
        return lmain_services;
    }
    public void Insert(CreateMain_ServiceDto dto)
    {
        Main_Service main_service = new Main_Service
        {
            Service = dto.Service,
        };
        _main_services.Add(main_service);
        context.SaveChanges();
    }
    public void Update(UpdateMain_ServiceDto dto)
    {
        var main_service = _main_services.SingleOrDefault(a => a.ID == dto.ID);
        if (main_service == null) return;
        main_service.Service = dto.Service;
        _main_services.Update(main_service);
        context.SaveChanges();
    }
    public void Delete(long id)
    {
        var main_service = _main_services.SingleOrDefault(a => a.ID == id);
        if (main_service == null) return;
        _main_services.Remove(main_service);
        context.SaveChanges();
    }
    public void SaveChanges()
    {
        context.SaveChanges();
    }
}