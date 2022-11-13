using System.Text.Json.Serialization;

namespace SkiServiceBackend.DTO
{
    public class LoginDTO
    {
        [JsonPropertyName("Benutzer_Name")]
        public string BenutzerName { get; set; }

        [JsonPropertyName("Benutzer_Passwort")]
        public string BenutzerPasswort { get; set; }
    }
}
