using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Cliente
{
    public class EditModel : PageModel
    {
        private readonly ServicioApi servicio;

        public EditModel(ServicioApi servicio)
        {
            this.servicio = servicio;
        }
        [BindProperty(SupportsGet =true)]

        public int ? id { get; set; }
        public ClientesEntity Entity = new ClientesEntity();
        public IEnumerable<AgenciasEntity> AgenciaLista { get; set; } = new List<AgenciasEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await  servicio.ClientesGetById ( id.Value);
                }
                AgenciaLista = await servicio.AgenciasGetLista();
                return Page();
            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }
        }


    }
}
