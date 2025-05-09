using System.Data.SqlClient;
using demoaspcore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace MyApp.Namespace
{
    public class createModel : PageModel
    {
        private readonly IConfiguration _config;

        public createModel(IConfiguration config)
        {
            _config = config;
        }

        [BindProperty]
        public Desarrollador desarrollador { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string cadena = _config.GetConnectionString("CadenaLocal");
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO desarrollador (NOMBRES, APELLIDOS, DNI, CORREO) VALUES (@nom, @ape, @dni, @cor)", cn);
                cmd.Parameters.AddWithValue("@nom", desarrollador.NOMBRES ?? string.Empty);
                cmd.Parameters.AddWithValue("@ape", desarrollador.APELLIDOS ?? string.Empty);
                cmd.Parameters.AddWithValue("@dni", desarrollador.DNI ?? string.Empty);
                cmd.Parameters.AddWithValue("@cor", desarrollador.CORREO ?? string.Empty);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToPage("Index");
        }
    }
}


