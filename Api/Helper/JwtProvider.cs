using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Api.Helper
{
    public static class JwtProvider
    {
        private static readonly IConfiguration _config;

        static JwtProvider()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _config = builder.Build();
        }
            
        public static Result<string> GenerateToken(int userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.Jwt.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var SecurityToken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(1),
              signingCredentials: credentials);

            var token =  new JwtSecurityTokenHandler().WriteToken(SecurityToken);

            System.Console.WriteLine(token);

            return Result<string>.Ok(token);

            // var tokenHandler = new JwtSecurityTokenHandler();
            // var key = Encoding.ASCII.GetBytes(Configuration["JwtSecurityKey"]);
            
            // var tokenDescriptor = new SecurityTokenDescriptor
            // {
            //     Subject = new ClaimsIdentity(
            //         new List<Claim> 
            //         { 
            //             new Claim(ClaimsIdentity.DefaultIssuer, userId) }
            //         ),
            //     Expires = DateTime.UtcNow.AddDays(7),
            //     SigningCredentials = new SigningCredentials(
            //         new SymmetricSecurityKey(key), 
            //         SecurityAlgorithms.HmacSha256Signature)
            // };

            // var token = tokenHandler.CreateToken(tokenDescriptor);
            // // return tokenHandler.WriteToken(token);

            // return Result<string>.Ok(tokenHandler.WriteToken(token));
        }
    }
}