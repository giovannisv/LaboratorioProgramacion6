using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.MarcaVehiculo
{
    public class GridModel : PageModel
    {
        private readonly IMarcaVehiculoServicio marcaVehiculoServicio;

        public GridModel(IMarcaVehiculoServicio marcaVehiculoServicio )
        {
            this.marcaVehiculoServicio = marcaVehiculoServicio;
        }

        public IEnumerable<MarcaVehiculoEntity> GridList { get; set; } = new List<MarcaVehiculoEntity>();    

        public string Mensaje { get; set; }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await marcaVehiculoServicio.Get();

                if(TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"] as string;
                }
                TempData.Clear();
                return Page();
            }
            catch (Exception ex)
            {

                return Content ( ex.Message);
            }

        }
        public async Task<IActionResult> OnGetEliminar(int id)
        {
            try
            {
                var result = await marcaVehiculoServicio.Delete(new()
                {
                    MarcaVehiculoID=id
                });

                if(result.CodeError!=0)
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






        public void OnPost()
        {
        }

        public void OnPut()
        {
        }

        public void OnDelete()
        {
        }

    }
}
