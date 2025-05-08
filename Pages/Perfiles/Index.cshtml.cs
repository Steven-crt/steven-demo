using System.Data.SqlClient;
using demoaspcore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;
        public IndexModel(IConfiguration config)
        {
            _config = config;
        }

        public List<Perfil> perfiles { get; set; }
        public void OnGet()
        {
            string cadena = _config.GetConnectionString("CadenaTaller").ToString();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("select * from perfil", cn);
            cn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            perfiles = new List<Perfil>();
            while (rd.Read())
            {
                perfiles.Add(new Perfil
                {
                    IdPerfil = (int)rd[0],
                    Nombre = rd[1].ToString(),
                    Descripcion = rd[2].ToString()
                });
            }
            cn.Close();
        }
    }
}
