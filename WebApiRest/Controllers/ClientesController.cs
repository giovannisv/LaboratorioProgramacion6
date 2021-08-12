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
    public class ClientesController : ControllerBase
    {
        private readonly IClientesServicio clientesServicio;

        public ClientesController(IClientesServicio clientesServicio)
        {
            this.clientesServicio = clientesServicio;
        }
        [HttpGet]
        public async Task<IEnumerable<ClientesEntity>>Get()
        {
            try
            {
                return await clientesServicio.Get();

            }
            catch (Exception ex)
            {
                return new List<ClientesEntity>();
            }
        }

        [HttpGet("{id}")]
        public async Task<ClientesEntity> GetById(int id)
        {
            try
            {
                return await clientesServicio.GetById(new ClientesEntity { ClientesId = id});

            }
            catch (Exception ex)
            {
                return new ClientesEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }
        [HttpPost]
        public async Task<DBEntity> Create (ClientesEntity entity)
        {
            try
            {
                return await clientesServicio.Create(entity);

            }
            catch (Exception ex)
            {
                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }
        [HttpPut]
        public async Task<DBEntity> Update(ClientesEntity entity)
        {
            try
            {
                return await clientesServicio.Update(entity);

            }
            catch (Exception ex)
            {
                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }
        [HttpDelete("{id}")]
        public async Task<DBEntity>Delete(int id)
        {
            try
            {
                return await clientesServicio.Delete(new ClientesEntity() { ClientesId = id});

            }
            catch (Exception ex)
            {
                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

    }
}
