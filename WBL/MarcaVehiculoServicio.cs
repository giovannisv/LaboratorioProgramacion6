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
        Task<IEnumerable<MarcaVehiculoEntity>> Get();
        Task<MarcaVehiculoEntity> GetByID(MarcaVehiculoEntity entity);
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

    }
}
