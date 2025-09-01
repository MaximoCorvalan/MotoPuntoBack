using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MotoPuntoBack.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MotoPuntoBack.Helpers;

public class Jwt
{
    public Jwt(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    private readonly IConfiguration configuration;

    public string EncriptarSHA256(string input) 
    {
        using (SHA256 sha256 = SHA256.Create()) 
        {
            byte[]bytes =  sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in bytes) 
            {
                stringBuilder.Append(b.ToString("X2"));
            }

            return stringBuilder.ToString();

        }
    }



    public string GenerarJWT(UsuarioDTO us)
    {
        var keyAux = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var issuer = configuration["Jwt:Issuer"];
        var audience = configuration["Jwt:Audience"];
        var subject = configuration["Jwt:Subject"];
        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, Subject),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
        new Claim(JwtRegisteredClaimNames.Name, us.Nombre),
        new Claim("Admin", us.Idrol.ToString())
    };

    
        var signingCredentials = new SigningCredentials(keyAux, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            issuer: Issuer,
            audience: Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }



    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;

    public string Subject { get; set; } = string.Empty;




}
