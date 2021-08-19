using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD;
using WBL;


namespace WebApp
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {

            services.AddSingleton<IDataAcces, DataAcces>();
            services.AddTransient<IMarcaVehiculoServicio, MarcaVehiculoServicio>();
            services.AddTransient<IVehiculoServicio, VehiculoServicio>();
            services.AddTransient<IAgenciaServicio, AgenciaServicio>();
            services.AddTransient<IClientesServicio, ClientesServicio>();
            services.AddTransient<ICatalogoProvinciaServicio, CatalogoProvinciaServicio>();
            services.AddTransient<ICatalogoCantonServicio, CatalogoCantonServicio>();
            services.AddTransient<ICatalogoDistritoServicio, CatalogoDistritoServicio>();





            return services;
        }
    }
}
