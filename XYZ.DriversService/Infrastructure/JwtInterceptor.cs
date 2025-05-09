using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace XYZ.DriversService.Infrastructure
{
    public class JwtInterceptor : Interceptor
    {
        private readonly IConfiguration _config;

        public JwtInterceptor(IConfiguration config)
        {
            _config = config;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            var token = ExtractToken(context.RequestHeaders);

            if (string.IsNullOrEmpty(token) || !ValidateToken(token, out ClaimsPrincipal claimsPrincipal))
            {
                throw new RpcException(new Status(StatusCode.Unauthenticated, "Token JWT inválido o ausente."));
            }

            return await continuation(request, context);
        }

        private string? ExtractToken(Metadata headers)
        {
            var authHeader = headers.FirstOrDefault(h => h.Key == "authorization");
            if (authHeader == null || !authHeader.Value.StartsWith("Bearer "))
                return null;

            return authHeader.Value.Substring("Bearer ".Length);
        }

        private bool ValidateToken(string token, out ClaimsPrincipal claimsPrincipal)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _config["Jwt:Issuer"],
                ValidAudience = _config["Jwt:Audience"],
                IssuerSigningKey = key
            };

            try
            {
                var handler = new JwtSecurityTokenHandler();
                claimsPrincipal = handler.ValidateToken(token, parameters, out _);
                return true;
            }
            catch
            {
                claimsPrincipal = null!;
                return false;
            }
        }
    }
}
