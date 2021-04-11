using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVenta.Models
{
    public class Login
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public int ClaveTienda { get; set; }
    }
}