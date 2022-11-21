using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektarbeitBackend.Models;
using SkiServiceBackend.DTO;

namespace SkiServiceBackend.Services
{
    public class ServiceAuftragDBService : IServiceAuftragService
    {
        private readonly SkiServiceContext _dbContext;
        
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="logger"></param>
        public ServiceAuftragDBService(SkiServiceContext dbContext, ILogger<ServiceAuftragDBService> logger)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get all AUfträge
        /// </summary>
        /// <returns>Liste aller aufträge</returns>
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

        /// <summary>
        /// Get Aufträg by id
        /// </summary>
        /// <param name="id">Id des Auftrags</param>
        /// <returns>EInen Auftrag</returns>
        public ServiceAuftrag ?GetService(int id)
        {
            return _dbContext.serviceAuftrag
                .Include(d => d.Dienstleistung)
                .FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Neuer Auftrag erstellen
        /// </summary>
        /// <param name="auftrag">Daten des Auftrags</param>
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

        /// <summary>
        /// Status ändern
        /// </summary>
        /// <param name="id">Id des Auftrags</param>
        /// <param name="Status">Neuer Status</param>
        public void PutStatusänderung(int id, string Status)
        {
            ServiceAuftrag auftrag = _dbContext.serviceAuftrag.FirstOrDefault(x => x.Id == id);

            if (auftrag == null) return;
            auftrag.status.Equals(Status);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Auftrag Löschen
        /// </summary>
        /// <param name="id">Id des Auftrags</param>
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
