namespace XYZ.AuthService.Domain
{
    public enum Rol
    {
        ADMIN = 0,
        OPERADOR = 1,
        SUPERVISOR = 2
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Rol Rol { get; set; }
    }
}
