using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public class MarcaVehiculoServicio
    {
        private readonly IDataAcces sql;

        public MarcaVehiculoServicio(IDataAcces _sql)
        {
            sql = _sql;
        }
        public async Task<IEnumerable<MarcaVehiculoEntity>>Get()
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
        
    }
}
