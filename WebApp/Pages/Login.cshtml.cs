using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ServicioApi servicioApi;

        public LoginModel(ServicioApi servicioApi)
        {
            this.servicioApi = servicioApi;
        }
        [FromBody]
        [BindProperty]
        public UsuariosEntity Entity { get; set; } = new UsuariosEntity();
        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = await servicioApi.UsuarioLogin(Entity);
                if (result.CodeError == 0)
                {

                    HttpContext.Session.Set<UsuariosEntity>(IApp.UsuarioSession, result);
                    return new JsonResult(result);
                }
                else
                {
                    return new JsonResult(result);
                }
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }

    }
}

