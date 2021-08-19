using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Cliente
{
    public class GridModel : PageModel
    {
        private readonly ServicioApi servicio;

        public GridModel(ServicioApi servicio)
        {
            this.servicio = servicio;
        }

        public IEnumerable<ClientesEntity> GridList { get; set; } = new List<ClientesEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await servicio.ClientesGet();

                return Page();

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }





    }







}
