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
    public class EditModel : PageModel
    {
        private readonly IAgenciaServicio agenciaServicio;
        private readonly ICatalogoProvinciaServicio catalogoProvinciaServicio;
        private readonly ICatalogoCantonServicio catalogoCantonServicio;
        private readonly ICatalogoDistritoServicio catalogoDistritoServicio;

        public EditModel(IAgenciaServicio agenciaServicio, ICatalogoProvinciaServicio catalogoProvinciaServicio,
            ICatalogoCantonServicio catalogoCantonServicio,
            ICatalogoDistritoServicio catalogoDistritoServicio)
        {
            this.agenciaServicio = agenciaServicio;
            this.catalogoProvinciaServicio = catalogoProvinciaServicio;
            this.catalogoCantonServicio = catalogoCantonServicio;
            this.catalogoDistritoServicio = catalogoDistritoServicio;
        }
        [BindProperty]
        [FromBody]
        public AgenciasEntity Entity { get; set; } = new AgenciasEntity();

        public IEnumerable<CatalogoProvinciaEntity> ProvinciaLista { get; set; } = new List<CatalogoProvinciaEntity>();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await agenciaServicio.GetByID(new() { AgenciaId = id });
                }
                ProvinciaLista = await catalogoProvinciaServicio.GetLista();
                return Page();
            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();
                if (Entity.AgenciaId.HasValue)
                {
                    //actualizar
                    result = await agenciaServicio.Update(Entity);

                }

                else
                {

                    //nuevo
                    result = await agenciaServicio.Create(Entity);


                }
                return new JsonResult(result);
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
        public async Task<IActionResult> OnPostChangeProvincia()
        {
            try
            {
                var result = await catalogoCantonServicio.GetLista(
                    new CatalogoProvinciaEntity { IdCatalogoProvincia = Entity.IdCatalogoProvincia }
                    );
                return new JsonResult(result);
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }
        public async Task<IActionResult> OnPostChangeCanton()
        {
            try
            {
                var result = await catalogoDistritoServicio.GetLista(
                    new CatalogoCantonEntity { IdCatalogoCanton = Entity.IdCatalogoCanton }
                    );
                return new JsonResult(result);
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }

        public async Task<IActionResult> OnPostChangeDistrito()
        {
            try
            {
                var result = await catalogoDistritoServicio.GetLista(
                    new CatalogoCantonEntity { IdCatalogoCanton = Entity.IdCatalogoCanton }
                    );
                return new JsonResult(result);
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
    }
}
