using System;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Alura.ListaLeitura.App.HTML;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController
    {
        public string Detalhes(HttpContext context) //este metodo atende a requisição cujo template é Livros/Detalhes/{id}
        {
            int id = Convert.ToInt32(context.GetRouteValue("id")); //pega a "id" da rota criada e coloca dentro de uma variável inteira
            var repo = new LivroRepositorioCSV(); //criar um objeto para representar o repositorio
            var livro = repo.Todos.First(l => l.Id == id); //pegar um livro no repositorio cujo "id" foi envido pela rota
            return livro.Detalhes(); //retornar uma resposta  com os detalhes do livro
        }

        public static Task ParaLer(HttpContext context) //metodo que define a resposta dada ao acessar o endereço, neste caso, a resposta vai ser imprimir os livros da lista ParaLer
        {
            var _repo = new LivroRepositorioCSV(); //para pegar os livros é preciso ir ao repositório
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("para-ler");
            //colocar o HttpContext context como argumento de entrada serve para incapsular as informações da requisição em questão

            foreach (var livro in _repo.ParaLer.Livros)
            {
                conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - { livro.Autor}</li>#NOVO-ITEM#"); //está substituindo o item do html pelo livro e o autor no repositorio
            }
            conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", "");

            return context.Response.WriteAsync(conteudoArquivo); //faz com que a resposta que será dada seja a lista entre parenteses, isto é, faz com que o código converse com a web
                                                                 // _repo.ParaLer.ToString() acessa o repositório na lista ParaLer e transforma em uma string
        }

        public static Task Lendo(HttpContext context)
        {

            var _repo = new LivroRepositorioCSV();
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("lendo");

            foreach (var livro in _repo.Lendo.Livros)
            {
                conteudoArquivo = conteudoArquivo.Replace("#ITEM-LENDO#", $"<li>{livro.Titulo} - { livro.Autor}</li>#ITEM-LENDO#"); //está substituindo o item do html pelo livro e o autor no repositorio
            }
            conteudoArquivo = conteudoArquivo.Replace("#ITEM-LENDO#", "");

            return context.Response.WriteAsync(conteudoArquivo);
        }

        public static Task Lidos(HttpContext context)
        {

            var _repo = new LivroRepositorioCSV();
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("lidos");

            foreach (var livro in _repo.Lidos.Livros)
            {
                conteudoArquivo = conteudoArquivo.Replace("#ITEM-LIDO#", $"<li>{livro.Titulo} - { livro.Autor}</li>#ITEM-LIDO#"); //está substituindo o item do html pelo livro e o autor no repositorio
            }
            conteudoArquivo = conteudoArquivo.Replace("#ITEM-LIDO#", "");


            return context.Response.WriteAsync(conteudoArquivo);
        }

    }
}
