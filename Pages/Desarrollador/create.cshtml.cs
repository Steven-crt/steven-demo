using System.Data.SqlClient;
using demoaspcore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class createModel : PageModel
    {
        public readonly IConfiguration _config;
        public createModel(IConfiguration config)
        {
            _config = config;
        }
        [BindProperty]
        public Desarrollador desarrollador { get; set; }
        public IActionResult OnPost()
        {
            string cadena = _config.GetConnectionString("CadenaTaller").ToString();
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("insert into desarrollador values (@nom,@des,@dni,@cor)", cn);
            cmd.Parameters.AddWithValue("@nom", desarrollador.NOMBRES);
            cmd.Parameters.AddWithValue("@ape", desarrollador.APELLIDOS);
            cmd.Parameters.AddWithValue("@dni", desarrollador.DNI);
            cmd.Parameters.AddWithValue("@cor", desarrollador.CORREO);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            return RedirectToPage("Index");
        }
    }
}



