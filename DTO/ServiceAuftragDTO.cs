using ProjektarbeitBackend.Models;
using System.Text.Json.Serialization;

namespace SkiServiceBackend.DTO
{
    public class ServiceAuftragDTO
    {
        [JsonPropertyName("Auftrag_Id")]
        public int AuftragsId { get; set; }

        [JsonPropertyName("Auftrag_Dienstleistung")]
        public string AuftragsDienstleistung { get; set; }

        [JsonPropertyName("Auftrag_Preis")]
        public float auftragsPreis { get; set; }

        [JsonPropertyName("Auftrag_KundenName")]
        public string auftragsKundenName { get; set; }

        [JsonPropertyName("Auftrag_KundeEmail")]
        public string KundeEmail { get; set; }

        [JsonPropertyName("Auftrag_KundenTelefon")]
        public int KundenTelefon { get; set; }


    }
}
