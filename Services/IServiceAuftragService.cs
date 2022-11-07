using ProjektarbeitBackend.Models;
using SkiServiceBackend.DTO;

namespace SkiServiceBackend.Services
{
    public interface IServiceAuftragService
    {
        List<ServiceAuftragDTO> GetAllServices();

        ServiceAuftrag ?GetService(int id);

        void PostNewAuftrag(ServiceAuftragDTO auftrag);

        void PutStatusänderung(int id, string Status);

        void DeleteAuftrag(int id);
    }
}
