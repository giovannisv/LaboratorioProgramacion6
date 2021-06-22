using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.MarcaVehiculo
{
    public class GridModel : PageModel
    {
        private readonly IMarcaVehiculoServicio marcaVehiculoServicio;

        public GridModel(IMarcaVehiculoServicio marcaVehiculoServicio )
        {
            this.marcaVehiculoServicio = marcaVehiculoServicio;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
        }

        public void OnPut()
        {
        }

        public void OnDelete()
        {
        }

    }
}
