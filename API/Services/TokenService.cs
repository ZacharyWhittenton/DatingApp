using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entitites;
using API.Interfaces;
//using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService : ITokenService // ITokenService will error without a string of the app user being called. 
    {   
        private readonly SymmetricSecurityKey _key; // our security key
        public TokenService(IConfiguration config) // Storing the token in the configuration
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }
        public string CreateToken(AppUser user) //Creating the token for the user
        {
            var claims = new List<Claim> //addngn a lsit of claims bc we will have more than 1 at soem point
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName) // claim about a user - sets the token to the user
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7), // excpires after a week
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}