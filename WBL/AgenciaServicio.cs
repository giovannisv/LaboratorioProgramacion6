using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IAgenciaServicio
    {
        Task<DBEntity> Create(AgenciasEntity entity);
        Task<DBEntity> Delete(AgenciasEntity entity);
        Task<IEnumerable<AgenciasEntity>> Get();
        Task<AgenciasEntity> GetByID(AgenciasEntity entity);
        Task<DBEntity> Update(AgenciasEntity entity);
    }

    public class AgenciaServicio : IAgenciaServicio
    {

        private readonly IDataAcces sql;

        public AgenciaServicio(IDataAcces _sql)
        {
            sql = _sql;
        }
        public async Task<IEnumerable<AgenciasEntity>> Get()
        {

            try
            {
                var result = sql.QueryAsync<AgenciasEntity,
                    CatalogoProvinciaEntity,
                    CatalogoCantonEntity,
                    CatalogoDistritoEntity

                    >("AgenciaObtener", "IdCatalogoProvincia,IdCatalogoCanton,IdCatalogoDistrito");
                return await result;

            }
            catch (Exception EX)
            {

                throw;
            }

        }

        public async Task<AgenciasEntity> GetByID(AgenciasEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<AgenciasEntity>("AgenciaObtener", new
                {
                    entity.AgenciaId
                }
                    );
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<DBEntity> Create(AgenciasEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("AgenciaInsertar", new
                {
                    entity.Nombre,
                    entity.IdCatalogoProvincia,
                    entity.IdCatalogoCanton,
                    entity.IdCatalogoDistrito,
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

        public async Task<DBEntity> Update(AgenciasEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("AgenciaActualizar", new
                {
                    entity.AgenciaId,
                    entity.Nombre,
                    entity.IdCatalogoProvincia,
                    entity.IdCatalogoCanton,
                    entity.IdCatalogoDistrito,
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
        public async Task<DBEntity> Delete(AgenciasEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("AgenciaEliminar", new
                {
                    entity.AgenciaId,

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
