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
    public class EditModel : PageModel
    {
        private readonly IMarcaVehiculoServicio marcaVehiculoServicio;

        public EditModel(IMarcaVehiculoServicio marcaVehiculoServicio)
        {
            this.marcaVehiculoServicio = marcaVehiculoServicio;
        }
        [BindProperty]
        public MarcaVehiculoEntity Entity { get; set; } = new MarcaVehiculoEntity();    
        [BindProperty (SupportsGet =true)]
        public int ? id { get; set; }

        public async Task<IActionResult>OnGet()
        {
            try
            {
                if(id.HasValue)
                {
                    Entity = await marcaVehiculoServicio.GetByID(new() { MarcaVehiculoID = id });
                }
                return Page();
            }
            catch (Exception ex)
            {

                return Content(content:ex.Message);
            }
         }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Entity.MarcaVehiculoID.HasValue)
                {
                    //actualizar
                    var result= await marcaVehiculoServicio.Update(Entity);
                    if (result.CodeError != 0) throw new Exception(message: result.MsgError);
                    TempData["Msg"] = "Se actualizo correctamente";
                }

                else
                {

                    //nuevo
                    var result = await marcaVehiculoServicio.Create(Entity);
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
