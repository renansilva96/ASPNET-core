using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Alura.ListaLeitura.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var _repo = new LivroRepositorioCSV();

            IWebHost host = new WebHostBuilder() //o IwebHost, representa um hospedeiro web, então a ideia é criar um objeto que hospeda os pedidos web, para isso, é utilizado o  WebHostBuilder que cria um hospedeiro web  
                .UseKestrel() //serve para mostrar que este host irá usar o servidor Kestrel que implementa o modelo http
                .UseStartup<Startup>() //classe de inicialização desse servidor web, codigo de configuração estará na classe Startup. Logo essa classe irá receber a requisição e definir como será a resposta
                .Build(); // Build cria uma implementação do IwebHost.
            host.Run(); //fazer com que o hospedeiro "suba", esteja disponivel para receber as chamadas web

            //ImprimeLista(_repo.ParaLer);
            //ImprimeLista(_repo.Lendo);
            //ImprimeLista(_repo.Lidos);
        }

        static void ImprimeLista(ListaDeLeitura lista)
        {
            Console.WriteLine(lista);
        }
    }
}
