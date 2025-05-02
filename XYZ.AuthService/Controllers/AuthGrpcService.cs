using Grpc.Core;
using XYZ.AuthService.Application;
using Domain = XYZ.AuthService.Domain;
using Protos = XYZ.AuthService.Protos;

namespace XYZ.AuthService.Controllers
{
    public class AuthGrpcService : Protos.AuthService.AuthServiceBase
    {
        private readonly Application.AuthService _authService;

        public AuthGrpcService(Application.AuthService authService)
        {
            _authService = authService;
        }

        public override Task<Protos.LoginResponse> Login(Protos.LoginRequest request, ServerCallContext context)
        {
            var (success, token, rol) = _authService.Login(request.Username, request.Password);

            if (!success)
                throw new RpcException(new Status(StatusCode.Unauthenticated, "Usuario o contraseña inválidos"));

            return Task.FromResult(new Protos.LoginResponse
            {
                Token = token,
                Rol = rol switch
                {
                    Domain.Rol.ADMIN => Protos.Rol.Admin,
                    Domain.Rol.OPERADOR => Protos.Rol.Operador,
                    Domain.Rol.SUPERVISOR => Protos.Rol.Supervisor,
                    _ => Protos.Rol.Operador
                }
            });

        }

        public override Task<Protos.RegisterResponse> RegisterUser(Protos.RegisterRequest request, ServerCallContext context)
        {
            return Task.FromResult(new Protos.RegisterResponse { Success = true });
        }
    }
}
