﻿using Microsoft.EntityFrameworkCore;
using ProjektarbeitBackend.Models;
using SkiServiceBackend.DTO;

namespace SkiServiceBackend.Services
{
    public class ServiceAuftragDBService : IServiceAuftragService
    {
        private readonly SkiServiceContext _dbContext;

        public ServiceAuftragDBService(SkiServiceContext dbContext)
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
                auftragsPreis = p.Dienstleistung.Preis,
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
            return _dbContext.serviceAuftrag.Find(id);
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
            _dbContext.serviceAuftrag.Find(id);
        }

        public void DeleteAudtrag(int id)
        {

        }
    }
}