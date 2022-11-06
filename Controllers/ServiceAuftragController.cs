using Microsoft.AspNetCore.Mvc;
using ProjektarbeitBackend.Models;
using SkiServiceBackend.DTO;
using SkiServiceBackend.Services;

namespace SkiServiceBackend.Controllers
{
    [Route("api[controller]")]
    [ApiController]

    public class ServiceAuftragController : ControllerBase
    {
        private readonly IServiceAuftragService _ServiceAuftrag;

        public ServiceAuftragController(IServiceAuftragService serviceAuftrag)
        {
            _ServiceAuftrag = serviceAuftrag;
        }

        [HttpGet]
        public List<ServiceAuftragDTO> GetAllServices()
        {
            return _ServiceAuftrag.GetAllServices();
        }

        [HttpGet("{id}")]
        public ServiceAuftragDTO GetService(int id)
        {
            ServiceAuftrag auftrag = _ServiceAuftrag.GetService(id);
            ServiceAuftragDTO result = new ServiceAuftragDTO();


            result.AuftragsId = auftrag.Id;
            result.AuftragsDienstleistung = auftrag.Dienstleistung.DienstleistungsName;
            result.auftragsPreis = auftrag.Dienstleistung.Preis;
            result.Auftagpriorität = auftrag.priorität;
            result.auftragsKundenName = auftrag.KundenName;
            result.KundenEmail = auftrag.Email;
            result.KundenTelefon = auftrag.Telefon;
            result.Auftragsstatus = auftrag.status;
            result.AuftragCreate_Date = auftrag.Create_Date;
            result.AuftragPickup_Date = auftrag.Pickup_Date;

            return result;
        }

        [HttpPost]
        public void PostNewAuftrag(ServiceAuftragDTO Data)
        {
            _ServiceAuftrag.PostNewAuftrag(Data);
        }
    }
}
