namespace MarcaVehiculoEdit {
    var Formulario = new Vue(
        {
            data: {
                Formulario: ""
            },
            mounted()
            {

                CreateValidator(this.Formulario);
            }
        }
    );
    Formulario.$mount("#AppEdit");

}