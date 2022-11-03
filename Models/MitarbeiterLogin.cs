

namespace ProjektarbeitBackend.Models
{
    public class MitarbeiterLogin
    {
        public int Id { get; set; }

        public Mitarbeiter Mitarbeiter { get; set; }

        public string Benutzername { get; set; }

        public int Passwort { get; set; }
    }
}
