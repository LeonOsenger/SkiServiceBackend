using System.ComponentModel.DataAnnotations;

namespace ProjektarbeitBackend.Models
{
    public class ServiceAuftrag
    {
        public int Id { get; set; }
        
        public int Auftrags { get; set; }
        
        public Dienstleistungen Dienstleistung { get; set; }

        public string priorität { get; set; }

        public string KundenName { get; set; }

        public string Email { get; set; }

        public int Telefon { get; set; }
    }
}
