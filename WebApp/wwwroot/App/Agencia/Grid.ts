﻿import { data } from "jquery";

namespace AgenciaGrid {

    export function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar este registro? ", "Eliminar", "warning", "#3085d6", "#d33")
            .then(result => {
                if (result.isConfirmed) {
                    Loading.fire("Borrando");
                    App.AxiosProvider.AgenciaEliminar(id).then(data =>{

                        Loading.close();

                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Se elimino correctamente", icon: "success" }).then(() => window.location.reload())
                        } else {
                            Toast.fire({ title: data.MsgError, icon: "error" })
                        

                        }

                    });
                    

                }
            });
    }

    $("#GridView").DataTable();


}