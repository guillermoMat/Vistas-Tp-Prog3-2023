using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

using TpFinalWeb.Models;

namespace TpFinalWeb.Controllers
{
    public class AccesoController : Controller
    {
        static string cadenaConexion = "Data Source=DESKTOP-3D9QJNG;Initial Catalog=Usuario;Integrated Security=true";

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario oUsuario)
        {
            using (SqlConnection cn=new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario",cn);
                cmd.Parameters.AddWithValue("Correo",oUsuario.Correo);
                cmd.Parameters.AddWithValue("Clave",oUsuario.Clave);

                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                oUsuario.Id=Convert.ToInt32(cmd.ExecuteScalar().ToString());//solamente nos lee la primera fila y primer columna
            }

            if (oUsuario.Id!=0)
            {
                ViewData["usuario"] = oUsuario;

                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }

        }

        
    }
}
