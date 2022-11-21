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

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="serviceAuftrag">Zuweisung des Auftrags services</param>
        /// <param name="logger">zuweisung des loggers</param>
        public ServiceAuftragController(IServiceAuftragService serviceAuftrag, ILogger<ServiceAuftragDBService> logger)
        {
            _ServiceAuftrag = serviceAuftrag;
            _logger = logger;
        }

        /// <summary>
        /// Get alle aufträge
        /// </summary>
        /// <returns>liste aller services</returns>
        [HttpGet]
        public List<ServiceAuftragDTO> GetAllServices()
        {
            _logger.LogInformation("Get All Request von Services aufgerufen");

            return _ServiceAuftrag.GetAllServices();
        }

        /// <summary>
        /// Get Auftrag an der Id
        /// </summary>
        /// <param name="id">welche Id?</param>
        /// <returns>einen Service mit der angegebenen Id von allen Service</returns>
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

        /// <summary>
        /// Neuer auftrag posten 
        /// </summary>
        /// <param name="Data">Daten des zu Postenden auftrags</param>
        [AllowAnonymous]
        [HttpPost]
        public void PostNewAuftrag(ServiceAuftragDTO Data)
        {
            _logger.LogInformation("Post Request von Services aufgerufen");

            _ServiceAuftrag.PostNewAuftrag(Data);
        }

        /// <summary>
        /// Status eines Auftrags ändern
        /// </summary>
        /// <param name="id">Id des Auftrags wo status geändert werden soll</param>
        /// <param name="status">Der neue Status</param>
        [HttpPut]
        public void PutStatusänderung(int id, string status)
        {
            _logger.LogInformation("Put Request von Services aufgerufen");

            _ServiceAuftrag.PutStatusänderung(id, status);
        }

        /// <summary>
        /// Auftrag löschen
        /// </summary>
        /// <param name="id">Id des zu löschenden auftrags</param>
        /// <returns></returns>
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
