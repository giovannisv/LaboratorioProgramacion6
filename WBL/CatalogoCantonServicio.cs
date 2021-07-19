using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface ICatalogoCantonServicio
    {
        Task<IEnumerable<CatalogoCantonEntity>> GetLista(CatalogoProvinciaEntity entity);
    }

    public class CatalogoCantonServicio : ICatalogoCantonServicio
    {
        private readonly IDataAcces sql;

        public CatalogoCantonServicio(IDataAcces _sql)
        {
            sql = _sql;
        }
        public async Task<IEnumerable<CatalogoCantonEntity>> GetLista(CatalogoProvinciaEntity entity)
        {
            try
            {
                var result = sql.QueryAsync<CatalogoCantonEntity>("CatalogoCantonLista" ,new
                    

                
                {
                    entity.IdCatalogoProvincia
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }



    }
}
