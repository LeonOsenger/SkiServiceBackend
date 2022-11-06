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

        [JsonPropertyName("Auftrag_Priorität")]
        public Priorität Auftagpriorität { get; set; }

        [JsonPropertyName("Auftrag_KundenName")]
        public string auftragsKundenName { get; set; }

        [JsonPropertyName("Auftrag_KundenEmail")]
        public string KundenEmail { get; set; }

        [JsonPropertyName("Auftrag_KundenTelefon")]
        public int KundenTelefon { get; set; }

        [JsonPropertyName("Auftrag_status")]
        public Status Auftragsstatus { get; set; }

        [JsonPropertyName("Auftrag_CreateDate")]
        public DateTime AuftragCreate_Date { get; set; }

        [JsonPropertyName("Auftrag_PickUpDate")]
        public DateTime AuftragPickup_Date { get; set; }


    }
}
