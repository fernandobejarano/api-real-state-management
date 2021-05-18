using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


namespace MillionAndUp.Cross_Cutting.Auth
{
    public class TokenService : ITokenService
    {
        public string CreateToken()
        {
            var key = Encoding.ASCII.GetBytes("8C136A86-13EF-469F-8B8C-CC6797323C9A");
            var tokenHandler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
