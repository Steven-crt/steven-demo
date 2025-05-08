using System.Data.SqlClient;
using demoaspcore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class indexModel : PageModel
    {
        private readonly IConfiguration _config;
        public indexModel(IConfiguration config)
        {
            _config = config;
        }
        public List<Desarrollador> desarrolladores { get; set; }
        public void OnGet()
        {
            string cadena = _config.GetConnectionString("CadenaTaller").ToString();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("select * from desarrollador", cn);
            cn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            desarrolladores = new List<Desarrollador>();
            while (rd.Read())
            {
                desarrolladores.Add(new Desarrollador
                {
                    IdDesarrollador = (int)rd[0],
                    NOMBRES = rd[1].ToString(),
                    APELLIDOS = rd[2].ToString(),
                    DNI = rd[3].ToString(),
                    CORREO = rd[4].ToString(),
                });
            }
            cn.Close();
        }
    }
}
