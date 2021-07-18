using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CatalogoCantonEntity
    {
        //se crea constructor vacio
        public CatalogoCantonEntity()
        {
            CatalogoProvincia = CatalogoProvincia ?? new CatalogoProvinciaEntity();
        }

        public int? IdCatalogoCanton { get; set; }
        public string NombreCatalogoCanton { get; set; }
        public int? IdCatalogoProvincia { get; set; }
        //llaveforanea
        public CatalogoProvinciaEntity CatalogoProvincia { get; set; }

    }
}
