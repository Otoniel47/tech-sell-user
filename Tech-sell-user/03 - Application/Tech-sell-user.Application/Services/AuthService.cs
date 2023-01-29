using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Web;
using Tech_sell_user.Application.DTOs.Request;
using Tech_sell_user.Application.DTOs.Responses;
using Tech_sell_user.Application.Interfaces;
using Tech_sell_user.Domain.Entities;
using Tech_sell_user.Domain.Utils;

namespace Tech_sell_user.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly TechSellUserSettings _appSettings;

        public AuthService(
            IUserService userService,
            IOptions<TechSellUserSettings> options)
        {
            _userService = userService;
            _appSettings = options.Value;
        }

        public AuthResponse LoginAsync(AuthRequest request)
        {
            var user = _userService.GetByEmailAsync(request.Email.Trim());

            if (user is not null && user.Email == default || user?.Email == null)
                return new AuthResponse { Message = "Usuário não cadastrado", Success = false };

            return AuthenticateUser(request, user);
        }

        #region Private

        private static bool VerifyPassword(User user, string passworkFromRequest)
        {
            var passwordCalculated = HttpUtility.UrlEncode(Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: passworkFromRequest,
                salt: Convert.FromBase64String(user.Salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8)));

            return user.Password == passwordCalculated;
        }

        private string GenerateJwtToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(_appSettings.TokenExpirationTimeInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private AuthResponse AuthenticateUser(AuthRequest request, User? user)
        {
            if (VerifyPassword(user, request.Password))
            {
                var token = GenerateJwtToken();

                return new AuthResponse { Token = token, Message = "Logado com sucesso!", Success = true };
            }

            return new AuthResponse { Message = "Email ou senha inválida", Success = false };
        }

        #endregion
    }
}