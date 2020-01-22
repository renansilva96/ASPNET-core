using System;
using System.Collections.Generic;
using System.IO;


namespace Alura.ListaLeitura.App.HTML
{
    public class HtmlUtils
    {
        public static string CarregaArquivoHTML(string nomeArquivo)
        {
            var nomeCompletoArquivo = $"HTML/{nomeArquivo}.html"; //será chamado quando for necessário abrir um arquivo html, que dependerá do nome chamado
            using (var arquivo = File.OpenText(nomeCompletoArquivo))
            {
                return arquivo.ReadToEnd(); //vai pegar todo conteudo e colocar numa string
            }
        }
    }
}
