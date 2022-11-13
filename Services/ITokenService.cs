using Microsoft.AspNetCore.Mvc;

namespace SkiServiceBackend.Services
{
    public interface ITokenService
    {
        string CreateToken(string username);

        bool CheckUser(string Vorname, string Passwort);
    }
}
