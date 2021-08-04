using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IUsuariosServicio
    {
        Task<DBEntity> Registrar (UsuariosEntity entity);
        Task<IEnumerable<UsuariosEntity>> Login(UsuariosEntity entity);
    }

    public class UsuariosServicio : IUsuariosServicio
    {
        private readonly IDataAcces sql;

        public UsuariosServicio(IDataAcces _sql)
        {
            sql = _sql;
        }
        public async Task<IEnumerable<UsuariosEntity>> Login(UsuariosEntity entity)
        {
            try
            {
                var result = sql.QueryAsync<UsuariosEntity>("Login", new
                {

                    entity.Usuario,
                    entity.Contrasena

                });
                return await result;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<DBEntity> Registrar (UsuariosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("UsuarioRegistrar", new
                {
                    entity.Usuario,
                    entity.Nombre,
                    entity.Contrasena
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




       
