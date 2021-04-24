using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVenta.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace PVenta.Controllers
{
    public class LoginController : Controller
    {
        public LoginController([FromServices] IConfiguration config)
        {
            
        }

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

        public string CerrarSesion()
        {
            try
            {
                HttpContext.Session.Remove("Token");
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public void CrearSessionVars()
        {
            HttpContext.Session.SetString("Token", "445217");
        }
    }
}