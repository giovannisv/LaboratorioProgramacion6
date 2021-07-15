using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;


namespace WebApp.Pages.Vehiculo
{
    public class GridModel : PageModel
    {
        private readonly IVehiculoServicio VehiculoServicio;

        public GridModel(VehiculoServicio vehiculoServicio)
        {
            this.VehiculoServicio = vehiculoServicio;
        }

        public IEnumerable<VehiculoEntity> GridList { get; set; } = new List<VehiculoEntity>();

        public string Mensaje { get; set; } = "";
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await VehiculoServicio.Get();

                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"] as string;
                }
                TempData.Clear();
                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }
        public async Task<IActionResult> OnGetEliminar(int id)
        {
            try
            {
                var result = await VehiculoServicio.Delete(new()
                {
                    VehiculoId = id
                });

                if (result.CodeError != 0)
                {
                    throw new Exception(message: result.MsgError);
                }
                TempData["Msg"] = "se elimino correctamente";
                return Redirect("Grid");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }       

    }
}
   
