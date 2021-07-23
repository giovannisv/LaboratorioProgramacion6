var AgenciaEdit;
(function (AgenciaEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity,
            CantonLista: [],
            DistritoLista: [],
        },
        methods: {
            OnChangeProvincia: function () {
                var _this = this;
                Loading.fire("Cargando..");
                App.AxiosProvider.AgenciaChangeProvincia(this.Entity).then(function (data) {
                    Loading.close();
                    _this.CantonLista = data;
                });
            },
            OnChangeCanton: function () {
                var _this = this;
                Loading.fire("Cargando..");
                App.AxiosProvider.AgenciaChangeCanton(this.Entity).then(function (data) {
                    Loading.close();
                    _this.DistritoLista = data;
                });
            },
            save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardando");
                    App.AxiosProvider.AgenciaGuardar(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Se guardo el registro", icon: "success" }).then(function () { return window.location.href = "Agencia/Grid"; });
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" });
                        }
                    });
                }
                else {
                    Toast.fire({ title: "Por favor complete los campos requeridos" });
                }
            }
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        },
        created: function () {
            this.OnChangeProvincia();
            this.OnChangeCanton();
        }
    });
    Formulario.$mount("#AppEdit");
})(AgenciaEdit || (AgenciaEdit = {}));
export {};
//# sourceMappingURL=Edit.js.map