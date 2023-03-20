//crie um conversor de moedas
//usuário insere o valor em reais e vc deve mostrar 3 opções de moedas para ele
//dólar, euro, yene
//instale o pacote AwesomeAPI
//instale o Newtonsoft.Json
using System;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading;

double valorreal = 0, valoroutramoeda = 0, cotacaooutramoeda;
string moedaescolhida, continuar = "1";

while(continuar == "1")
{
    Console.WriteLine("Insira o Valor em Reais (R$): ");
    valorreal = double.Parse(Console.ReadLine());

    Console.Clear();

    Console.WriteLine("Informe");
    Console.WriteLine("1 - Para Dolar");
    Console.WriteLine("2 - Para Euro");
    Console.WriteLine("3 - Para Ienes");
    moedaescolhida = Console.ReadLine();
    ObterCotacao(moedaescolhida);

    Console.Clear();

    Console.Write("Aguarde");
    for (int i = 0; i < 5; i++)
    {
        Console.Write(".");
        Thread.Sleep(1000);
    }

    Console.WriteLine();

    Console.Clear();
    static async Task<double> ObterCotacao(string moeda)
    {
        using (var httpClient = new HttpClient())
        {
            var url = "";

            switch (moeda)
            {
                case "1":
                    url = "https://economia.awesomeapi.com.br/USD-BRL";
                    break;
                case "2":
                    url = "https://economia.awesomeapi.com.br/EUR-BRL";
                    break;
                case "3":
                    url = "https://economia.awesomeapi.com.br/JPY-BRL";
                    break;
            }

            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            dynamic data = JsonConvert.DeserializeObject(content);
            return (double)data[0].bid;
        }
    }




    switch (moedaescolhida)
    {
        case "1":
            cotacaooutramoeda = await ObterCotacao(moedaescolhida);
            valoroutramoeda = valorreal / cotacaooutramoeda;
            Console.WriteLine(valorreal + "R$ Em Dólares é: " + valoroutramoeda);
            break;
        case "2":
            cotacaooutramoeda = await ObterCotacao(moedaescolhida);
            valoroutramoeda = valorreal / cotacaooutramoeda;
            Console.WriteLine(valorreal + "R$ Em Euro é: " + valoroutramoeda);
            break;
        case "3":
            cotacaooutramoeda = await ObterCotacao(moedaescolhida);
            valoroutramoeda = valorreal / cotacaooutramoeda;
            Console.WriteLine(valorreal + "R$ Em Ienes é: " + valoroutramoeda);
            break;
        default:
            Console.WriteLine("Informe somente os números (1, 2 ou 3)");
            break;
    }

    Console.WriteLine();
    Console.WriteLine("Deseja Continuar o Programa? \n 1 - Para Continuar \n 2 - Para Encerrar");
    continuar = Console.ReadLine();

    Console.Clear();
}




