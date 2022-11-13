using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjektarbeitBackend.Models;
using SkiServiceBackend.DTO;
using SkiServiceBackend.Services;

namespace SkiServiceBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class ServiceAuftragController : ControllerBase
    {
        private readonly IServiceAuftragService _ServiceAuftrag;
        private readonly ILogger<ServiceAuftragDBService> _logger;

        public ServiceAuftragController(IServiceAuftragService serviceAuftrag, ILogger<ServiceAuftragDBService> logger)
        {
            _ServiceAuftrag = serviceAuftrag;
            _logger = logger;
        }

        [HttpGet]
        public List<ServiceAuftragDTO> GetAllServices()
        {
            _logger.LogInformation("Get All Request von Services aufgerufen");

            return _ServiceAuftrag.GetAllServices();
        }

        [HttpGet("{id}")]
        public ServiceAuftragDTO GetService(int id)
        {
            _logger.LogInformation("Get by Id Request von Services aufgerufen");

            ServiceAuftrag auftrag = _ServiceAuftrag.GetService(id);
            ServiceAuftragDTO result = new ServiceAuftragDTO();

            if(auftrag != null)
            { 
                result.AuftragsId = auftrag.Id;
                result.AuftragsDienstleistung = auftrag.Dienstleistung.DienstleistungsName;
                result.Auftagpriorität = auftrag.priorität;
                result.auftragsKundenName = auftrag.KundenName;
                result.KundenEmail = auftrag.Email;
                result.KundenTelefon = auftrag.Telefon;
                result.Auftragsstatus = auftrag.status;
                result.AuftragCreate_Date = auftrag.Create_Date;
                result.AuftragPickup_Date = auftrag.Pickup_Date;
            }

            return result;
        }

        [AllowAnonymous]
        [HttpPost]
        public void PostNewAuftrag(ServiceAuftragDTO Data)
        {
            _logger.LogInformation("Post Request von Services aufgerufen");

            _ServiceAuftrag.PostNewAuftrag(Data);
        }

        [HttpPut]
        public void PutStatusänderung(int id, string status)
        {
            _logger.LogInformation("Put Request von Services aufgerufen");

            _ServiceAuftrag.PutStatusänderung(id, status);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAuftrag(int id)
        {
            _logger.LogInformation("Delete Request von Services aufgerufen");

            if (_ServiceAuftrag == null)
            { return NotFound(); }

            if (_ServiceAuftrag.GetService(id) == null)
            { return BadRequest(); }    
            else
            { 
                _ServiceAuftrag.DeleteAuftrag(id); 
                return Ok();
            }

        }
    }
}
