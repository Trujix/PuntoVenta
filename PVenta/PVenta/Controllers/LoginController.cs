using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVenta.Models;

namespace PVenta.Controllers
{
    public class LoginController : Controller
    {
        public string IniciarSesion(Login login)
        {
            try
            {
                if (login.Usuario == "adm" && login.Password == "123")
                {
                    CrearSessionVars();
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public void CrearSessionVars()
        {
            HttpContext.Session.SetString("Token", "445217");
        }
    }
}