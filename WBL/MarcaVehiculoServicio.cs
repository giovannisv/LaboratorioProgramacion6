using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IMarcaVehiculoServicio
    {

        Task<DBEntity> Create(MarcaVehiculoEntity entity);
        Task<DBEntity> Delete(MarcaVehiculoEntity entity);
        Task<IEnumerable<MarcaVehiculoEntity>> Get();
        Task<IEnumerable<MarcaVehiculoEntity>> GetLista();
        Task<MarcaVehiculoEntity> GetByID(MarcaVehiculoEntity entity);
        Task<DBEntity> Update(MarcaVehiculoEntity entity);
    }

    public class MarcaVehiculoServicio : IMarcaVehiculoServicio
    {
        private readonly IDataAcces sql;

        public MarcaVehiculoServicio(IDataAcces _sql)
        {
            sql = _sql;
        }
        public async Task<IEnumerable<MarcaVehiculoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<MarcaVehiculoEntity>("MarcaVehiculoObtener");
                return await result;

            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<MarcaVehiculoEntity> GetByID(MarcaVehiculoEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<MarcaVehiculoEntity>("MarcaVehiculoObtener", new
                {
                    entity.MarcaVehiculoID
                }
                    );
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<DBEntity> Create (MarcaVehiculoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("MarcaVehiculoInsertar", new
                {
                    entity.Descripcion,
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
        public async Task<DBEntity> Update (MarcaVehiculoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("MarcaVehiculoActualizar", new
                {
                    entity.MarcaVehiculoID,
                    entity.Descripcion,
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
        public async Task<DBEntity> Delete(MarcaVehiculoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("MarcaVehiculoEliminar", new
                {
                    entity.MarcaVehiculoID,
                    
                }
                    );
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<MarcaVehiculoEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<MarcaVehiculoEntity>("MarcaVehiculoLista");

                return await result;

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
