using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Agencia
{
    public class GridModel : PageModel
    {
        private readonly IAgenciaServicio agenciaServicio;

        public GridModel(IAgenciaServicio agenciaServicio)
        {
            this.agenciaServicio = agenciaServicio;
        }
        public IEnumerable<AgenciasEntity> GridList { get; set; } = new List <AgenciasEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await agenciaServicio.Get();

                return Page();

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        public async Task<JsonResult>OnDeleteEliminar(int id)
        {
            try
            {
                var result = await agenciaServicio.Delete(new()
                {

                    AgenciaId = id
                });

                return new JsonResult(result);
                
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }


        }
    }

}
