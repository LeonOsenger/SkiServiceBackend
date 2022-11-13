using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektarbeitBackend.Models;
using SkiServiceBackend.DTO;

namespace SkiServiceBackend.Services
{
    public class ServiceAuftragDBService : IServiceAuftragService
    {
        private readonly SkiServiceContext _dbContext;
        

        public ServiceAuftragDBService(SkiServiceContext dbContext, ILogger<ServiceAuftragDBService> logger)
        {
            _dbContext = dbContext;
        }

        public List<ServiceAuftragDTO> GetAllServices()
        {
            List<ServiceAuftrag> Auftag = _dbContext.serviceAuftrag
                .Include(d => d.Dienstleistung)
                .ToList();

            List<ServiceAuftragDTO> result = new List<ServiceAuftragDTO>();

            Auftag.ForEach(p => result.Add(new ServiceAuftragDTO()
            {
                AuftragsId = p.Id,
                AuftragsDienstleistung = p.Dienstleistung.DienstleistungsName,
                Auftagpriorität = p.priorität,
                auftragsKundenName = p.KundenName,
                KundenEmail = p.Email,
                KundenTelefon = p.Telefon,
                Auftragsstatus = p.status,
                AuftragCreate_Date = p.Create_Date,
                AuftragPickup_Date = p.Pickup_Date
            }));

            return result;
        }

        public ServiceAuftrag ?GetService(int id)
        {
            return _dbContext.serviceAuftrag
                .Include(d => d.Dienstleistung)
                .FirstOrDefault(x => x.Id == id);
        }

        public void PostNewAuftrag(ServiceAuftragDTO auftrag)
        {
            ServiceAuftrag addData = new ServiceAuftrag()
            {
                Id = auftrag.AuftragsId,
                Dienstleistung = _dbContext.serviceDienstleistungen.FirstOrDefault(e => e.DienstleistungsName == auftrag.AuftragsDienstleistung),
                priorität = auftrag.Auftagpriorität,
                KundenName = auftrag.auftragsKundenName,
                Email = auftrag.KundenEmail,
                Telefon = auftrag.KundenTelefon,    
                status = auftrag.Auftragsstatus,
                Create_Date = auftrag.AuftragCreate_Date,
                Pickup_Date = auftrag.AuftragPickup_Date
            };

            _dbContext.Add(addData);
            _dbContext.SaveChanges();


        }

        public void PutStatusänderung(int id, string Status)
        {
            ServiceAuftrag auftrag = _dbContext.serviceAuftrag.FirstOrDefault(x => x.Id == id);

            if (auftrag == null) return;
            auftrag.status.Equals(Status);
            _dbContext.SaveChanges();
        }

        public void DeleteAuftrag(int id)
        {
            ServiceAuftrag auftrag = _dbContext.serviceAuftrag.FirstOrDefault(x => x.Id == id);
            if(auftrag != null)
            {
                _dbContext.serviceAuftrag.Remove(auftrag);
                _dbContext.SaveChanges();
            }
        }
    }
}
