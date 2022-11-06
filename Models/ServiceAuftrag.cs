using System.ComponentModel.DataAnnotations;

namespace ProjektarbeitBackend.Models
{
    public class ServiceAuftrag
    {
        public int Id { get; set; }
        
        public Dienstleistungen Dienstleistung { get; set; }

        public Priorität priorität { get; set; }

        public string KundenName { get; set; }

        public string Email { get; set; }

        public int Telefon { get; set; }

        public Status status { get; set; }

        public DateTime Create_Date { get; set; }

        public DateTime Pickup_Date { get; set; }
    }

    public enum Priorität
    {
        Niedrig, Mittel, Hoch
    }

    public enum Status
    {
        Offen, InArbeit, Abgeschlossen 
    }



}
