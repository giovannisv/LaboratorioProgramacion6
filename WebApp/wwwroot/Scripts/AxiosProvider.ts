
namespace App.AxiosProvider   {

    //export const GuardarEmpleado = () => axios.get<Entity.DBEntity>("aplicacion").then(({data})=>data );
    export const AgenciaEliminar = (id) => axios.delete<DBEntity>("Agencia/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);

}




