using Microsoft.AspNetCore.Http;

namespace PVenta.Utilities
{
    public class Session
    {
        public static IHttpContextAccessor _httpContextAccessor;

        public static void CrearSessionVar(string nombre, string valor)
        {
            _httpContextAccessor = new HttpContextAccessor();
            _httpContextAccessor.HttpContext.Session.SetString(nombre, valor);
        }

        public static string ObtenerSessionVar(string nombre)
        {
            _httpContextAccessor = new HttpContextAccessor();
            return _httpContextAccessor.HttpContext.Session.GetString(nombre);
        }
    }
}