using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace Bot.Mega
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o número do concurso: ");
            string numeroDoConcurso = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(numeroDoConcurso))
            {
                numeroDoConcurso = "2103";
            }

            string url = @"http://www1.caixa.gov.br/loterias/loterias/megasena/megasena_pesquisa_new.asp?submeteu=sim&opcao=concurso&txtConcurso=" + numeroDoConcurso;
            string html;

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers["Cookie"] = "security=true";
                html = webClient.DownloadString(url);
            }

            html = html.Replace("<span class=\"num_sorteio\"><ul>",""); //Retira span
            html = html.Replace("</ul></span>", ""); //Retira span
            html = html.Replace("</li>", ""); //Retira span

            string[] vet = Regex.Split(html, "<li>");
            List<int> resultado = new List<int>();

            resultado.Add(int.Parse(vet[1]));
            resultado.Add(int.Parse(vet[2]));
            resultado.Add(int.Parse(vet[3]));
            resultado.Add(int.Parse(vet[4]));
            resultado.Add(int.Parse(vet[5]));
            resultado.Add(int.Parse(vet[6].Substring(0,2)));

            resultado.OrderBy(x => x).ToList().ForEach(num => {
                Console.WriteLine(num);
            });
            
        }
    }
}
