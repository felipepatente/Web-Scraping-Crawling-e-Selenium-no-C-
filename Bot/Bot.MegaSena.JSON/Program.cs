using Newtonsoft.Json;
using System;
using System.Net;

namespace Bot.MegaSena.JSON
{
    class Program
    {
        static void Main(string[] args)
        {            
            string url = @"http://loterias.caixa.gov.br/wps/portal/loterias/landing/megasena/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbwMPI0sDBxNXAOMwrzCjA0sjIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wNnUwNHfxcnSwBgIDUyhCvA5EawAjxsKckMjDDI9FQE-F4ca/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KO6H80AU71KG7J0072/res/id=buscaResultado/c=cacheLevelPage/=/?timestampAjax=1593608679095";
            string json;

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers["Cookie"] = "security=true";
                json = webClient.DownloadString(url);
            }

            var resultadoDaMegaSena = JsonConvert.DeserializeObject<Resultado>(json);

            Console.WriteLine(resultadoDaMegaSena.resultadoOrdenado);
        }
    }
}
