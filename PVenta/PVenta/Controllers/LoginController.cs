using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PVenta.Models;
using PVenta.Utilities;

namespace PVenta.Controllers
{
    public class LoginController : Controller
    {
        public string IniciarSesion(Login login)
        {
            try
            {
                
                if(login.Usuario == "adm" && login.Password == "123")
                {
                    return "true" + Session.ObtenerSessionVar("Token");
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
    }
}