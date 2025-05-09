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

        public override async Task<Protos.LoginResponse> Login(Protos.LoginRequest request, ServerCallContext context)
        {
            var (success, token, rol) = await _authService.Login(request.Username, request.Password);

            if (!success)
                throw new RpcException(new Status(StatusCode.Unauthenticated, "Usuario o contraseña inválidos"));

            return new Protos.LoginResponse
            {
                Token = token,
                Rol = rol switch
                {
                    Domain.Rol.ADMIN => Protos.Rol.Admin,
                    Domain.Rol.OPERADOR => Protos.Rol.Operador,
                    Domain.Rol.SUPERVISOR => Protos.Rol.Supervisor,
                    _ => Protos.Rol.Operador
                }
            };
        }

        public override async Task<Protos.RegisterResponse> RegisterUser(Protos.RegisterRequest request, ServerCallContext context)
        {
            var success = await _authService.Register(request.Username, request.Password, (Domain.Rol)request.Rol);
            return new Protos.RegisterResponse { Success = success };

        }
    }
}
