using Alura.ListaLeitura.App.Logica;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;



namespace Alura.ListaLeitura.App
{ 
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(); //faz com que a aplicação use o serviço de roteamento do ASPNET core
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app) //vincular a chegada da requisição com o método correto, nesse caso será o LivrosParaLer
        {
            app.UseMvcWithDefaultRoute();
        }       
    }
}