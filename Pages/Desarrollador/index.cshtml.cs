using System.Data.SqlClient;
using demoaspcore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

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
            string cadena = _config.GetConnectionString("CadenaLocal");
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM desarrollador", cn);
                cn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                desarrolladores = new List<Desarrollador>();

                while (rd.Read())
                {
                    desarrolladores.Add(new Desarrollador
                    {
                        IdDesarrollador = rd.IsDBNull(0) ? null : (int?)rd.GetInt32(0),
                        NOMBRES = rd.IsDBNull(1) ? null : rd.GetString(1),
                        APELLIDOS = rd.IsDBNull(2) ? null : rd.GetString(2),
                        DNI = rd.IsDBNull(3) ? null : rd.GetString(3),
                        CORREO = rd.IsDBNull(4) ? null : rd.GetString(4)
                    });
                }
            }
        }
    }
}

