using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IClientesServicio
    {
        Task<DBEntity> Create(ClientesEntity entity);
        Task<DBEntity> Delete(ClientesEntity entity);
        Task<IEnumerable<ClientesEntity>> Get();
        Task<ClientesEntity> GetByID(ClientesEntity entity);
        Task<DBEntity> Update(ClientesEntity entity);
    }

    public class ClientesServicio : IClientesServicio
    {
        private readonly IDataAcces sql;

        public ClientesServicio(IDataAcces _sql)
        {
            sql = _sql;
        }
        public async Task<IEnumerable<ClientesEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ClientesEntity, AgenciasEntity>("ClientesObtener", "AgenciaId");
                return await result;

            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<ClientesEntity> GetByID(ClientesEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ClientesEntity>("ClientesObtener", new
                {
                    entity.ClientesId
                }
                    );
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<DBEntity> Create(ClientesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ClientesInsertar", new
                {
                    entity.NombreCompleto,
                    entity.Direccion,
                    entity.Telefono,
                    entity.AgenciaId,
                    entity.Estado
                }
                    );
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<DBEntity> Update(ClientesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ClientesActualizar", new
                {
                    entity.ClientesId,
                    entity.NombreCompleto,
                    entity.Direccion,
                    entity.Telefono,
                    entity.AgenciaId,
                    entity.Estado
                }
                    );
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<DBEntity> Delete(ClientesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ClientesEliminar", new
                {
                    entity.ClientesId

                }
                    );
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}

