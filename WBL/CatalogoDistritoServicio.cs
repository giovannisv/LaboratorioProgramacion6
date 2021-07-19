using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface ICatalogoDistritoServicio
    {
        Task<IEnumerable<CatalogoDistritoEntity>> GetLista(CatalogoCantonEntity entity);
    }

    public class CatalogoDistritoServicio : ICatalogoDistritoServicio
    {

        private readonly IDataAcces sql;

        public CatalogoDistritoServicio(IDataAcces _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<CatalogoDistritoEntity>> GetLista(CatalogoCantonEntity entity)
        {
            try
            {
                var result = sql.QueryAsync<CatalogoDistritoEntity>("CatalogoDistritoLista", new

                {
                    entity.IdCatalogoCanton
                } );

                return await result;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
