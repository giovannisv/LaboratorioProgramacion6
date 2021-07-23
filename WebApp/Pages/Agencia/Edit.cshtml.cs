using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Agencia
{
    public class EditModel : PageModel
    {
        private readonly AgenciaServicio agenciaservicio;

        private readonly CaServicio AgenciaServicio;


        public EditModel(IAgenciaServicio AgenciaServicio, IAgenciaServicio agendaServicio)
        {
            thisServicio = AgenciaServicio;
            this.marcaVehiculoServicio = marcaVehiculoServicio;
        }
        [BindProperty]
        public VehiculoEntity Entity { get; set; } = new VehiculoEntity();

        public IEnumerable<MarcaVehiculoEntity> MarcaVehiculoLista { get; set; } = new List<MarcaVehiculoEntity>();
        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await vehiculoServicio.GetByID(new() { VehiculoId = id });
                }
                MarcaVehiculoLista = await marcaVehiculoServicio.GetLista();
                return Page();
            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Entity.VehiculoId.HasValue)
                {
                    //actualizar
                    var result = await vehiculoServicio.Update(Entity);
                    if (result.CodeError != 0) throw new Exception(message: result.MsgError);
                    TempData["Msg"] = "Se actualizo correctamente";
                }

                else
                {

                    //nuevo
                    var result = await vehiculoServicio.Create(Entity);
                    if (result.CodeError != 0) throw new Exception(message: result.MsgError);
                    TempData["Msg"] = "Se agrego correctamente";

                }
                return RedirectToPage("Grid");
            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }
        }
    }
}
