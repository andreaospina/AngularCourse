using BackEndPreguntasRespuestas.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackEndPreguntasRespuestas.Utils
{
    public class JwtConfigurator
    {
        public static string GetToken(Usuario userInfo,IConfiguration configuration)
        {
            string SecretKey = configuration["Jwt:SecretKey"];
            string Issuer = configuration["Jwt:Issuer"];
            string Audience = configuration["Jwt:Audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credencials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.NombreUsuario),
                new Claim("idUsuario", userInfo.Id.ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credencials
                );
                
            return new JwtSecurityTokenHandler().WriteToken(token);        
        }

        public static int GetTokenIdUsuario(ClaimsIdentity identity)
        {
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                foreach (var claim in claims)
                {
                    if (claim.Type == "idUsuario")
                    {
                        return int.Parse(claim.Value);
                    }
                }
            }

            return 0;
        }
    }
}
