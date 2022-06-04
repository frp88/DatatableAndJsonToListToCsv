using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DatatableAndJsonToListToCsv {
    public static class EnderecoService {
        // Obtém um Endeço pelo CEP
        public static Endereco ObtemEnderecoPeloCep(string cep) {
            string viaCEPUrl = "https://viacep.com.br/ws/" + cep + "/json/";
            WebClient client = new WebClient();
            string stringJSON = client.DownloadString(viaCEPUrl);
            // Converte a string JSON e Objeto Genérico
            JObject jsonRetornado = JObject.Parse(stringJSON);
            Console.WriteLine($"\nJSON Retornado: \n{jsonRetornado}\n");

            Endereco endereco = new Endereco();
            // Converte o JSON em um objeto da classe Endereco
            endereco = JsonConvert.DeserializeObject<Endereco>(stringJSON);
            //Console.WriteLine(" --- Endereço em objeto: \nLogradouro: " + endereco.Logradouro);

            return endereco;
        }
    }
}
