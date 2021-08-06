using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBL;
using Entity;

namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosServicio usuariosServicio;

        public UsuariosController(IUsuariosServicio usuariosServicio)
        {
            this.usuariosServicio = usuariosServicio;
        }
        [HttpPost("Login")]
        public async Task<UsuariosEntity>Login(UsuariosEntity entity)
        {
            try
            {
                return await usuariosServicio.Login(entity);

            }
            catch (Exception ex)
            {


                return new UsuariosEntity() { CodeError = ex.HResult,MsgError=ex.Message };
                
            }

        }
         [HttpPost("Registrar")]
        public async Task<DBEntity>Registrar(UsuariosEntity entity)
        {
            try
            {
                return await usuariosServicio.Registrar(entity);

            }
            catch (Exception ex)
            {


                return new UsuariosEntity() { CodeError = ex.HResult,MsgError=ex.Message };
                
            }

        }

    }
}
