using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjektarbeitBackend.Models;
using SkiServiceBackend.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SkiServiceBackend.Services
{

    public class JWTTokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly SkiServiceContext _dbContext;

        public JWTTokenService(IConfiguration config, SkiServiceContext dbContext)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            _dbContext = dbContext;
        }

        public string CreateToken(string username)
        {
            var claim = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, username)
            };

            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = cred
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }

        public bool CheckUser(string Vorname, string Passwort)
        {
            List<Mitarbeiter> User = _dbContext.mitarbeiters.ToList();
            LoginDTO login = new LoginDTO();
            
            foreach (var U in User)
            {
                if (Vorname == U.Vorname && Passwort == U.Passwort)
                {
                    login.BenutzerName = U.Vorname;
                    login.BenutzerPasswort = U.Passwort;
                    return true;
                }
                    
            }

            return false;
        }
    }
}
