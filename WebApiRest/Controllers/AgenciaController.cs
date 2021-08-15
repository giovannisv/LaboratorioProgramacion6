using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBL;


namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciaController : ControllerBase
    {
        private readonly IAgenciaServicio agenciaServicio;

        public AgenciaController(IAgenciaServicio agenciaServicio)
        {
            this.agenciaServicio = agenciaServicio;
        }
        [HttpGet("Lista")]
        public async Task<IEnumerable<AgenciasEntity>> GetLista()
        {
            try
            {
                return await agenciaServicio.GetLista();

            }
            catch (Exception ex)
            {
                return new List<AgenciasEntity>();
            }
        }
    }
}
