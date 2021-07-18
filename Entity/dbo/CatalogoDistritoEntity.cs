using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CatalogoDistritoEntity
    {
        public CatalogoDistritoEntity()
        {
            CatalogoCanton = CatalogoCanton ?? new CatalogoCantonEntity();
            //?? validacion son signos de pregunta
        }

        public int? IdCatalogoDistrito { get; set; }
        public string NombreCatalogoDistrito { get; set; }
        public int? IdCatalogoCanton { get; set; }
        //llave foranea
        public CatalogoCantonEntity CatalogoCanton { get; set; }

    }
}
