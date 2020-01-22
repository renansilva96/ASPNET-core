using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
   public class CadastroController
    {
        public static Task Incluir(HttpContext context)
        {
            var livro = new Livro() //criar um livro
            {
                Titulo = context.Request.Form["titulo"].First(), //Form busca as informações do formulario, pois as informações estão sendo passadas pelo corpo da requisição
                Autor = context.Request.Form["autor"].First(),
            };

            var repo = new LivroRepositorioCSV(); //o livro será usado dentro do repositorio
            repo.Incluir(livro); //para adicionar o livro no repositorio
            return context.Response.WriteAsync("O livro foi adicionado com sucesso");
        }

        public static Task ExibeFormulario(HttpContext context)
        {
            /* faz com que o formulario seja enviado para requisição Cadastro/Incluir */
            var html = HtmlUtils.CarregaArquivoHTML("formulario"); //chama o outro metodo que irá abrir o arquivo html
            return context.Response.WriteAsync(html);
        }


        public static Task NovoLivro(HttpContext context)
        {
            var livro = new Livro() //criar um livro
            {
                Titulo = Convert.ToString(context.GetRouteValue("nome")), // GetRouteValue recupera a informação das rotas, nesse caso das rotas com templete, definindo titulo e autor 
                Autor = Convert.ToString(context.GetRouteValue("autor")),
            };

            var repo = new LivroRepositorioCSV(); //o livro será usado dentro do repositorio
            repo.Incluir(livro); //para adicionar o livro no repositorio
            return context.Response.WriteAsync("O livro foi adicionado com sucesso");
        }


    }
}
