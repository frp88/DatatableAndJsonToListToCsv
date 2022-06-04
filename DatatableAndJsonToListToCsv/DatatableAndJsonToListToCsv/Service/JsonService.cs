using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DatatableAndJsonToListToCsv {
    public static class JsonService {
        // Serializa uma lista de objetos (transforma uma lista de objetos em arquivo JSON e salva no PC)
        public static bool SerializaListaDeProdutos(List<Produto> listaProdutos) {
            try {
                string jsonFilePatch = @"D:\Dados\jsonProdutos.json";
                // Atribui da Lista de Produtos para o arquivo JSON
                var jsonProdutos = JsonConvert.SerializeObject(listaProdutos);
                // Salva o arquivo JSON no PC 
                File.WriteAllText(jsonFilePatch, jsonProdutos);
                Console.WriteLine("Arquivo JSON criado com sucesso!");
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine("Falha ao criar o arquivo JSON: " + ex.Message);
                return false;
            }
        }

        // Desserializa um arquivo JSON em uma lista de objetos (transforma um arquivo JSON em uma lista de objetos)
        public static List<Produto> DesserializaListaDeProdutos() {
            try {
                List<Produto> listaProdutos = new List<Produto>();
                string jsonFilePatch = @"D:\Dados\jsonProdutos.json";
                // Atribui o conteúdo do arquivo JSON para uma string 
                string jsonProdutos = File.ReadAllText(jsonFilePatch);
                // Converte o JSON em uma lista de objetos da classe Produto
                listaProdutos = JsonConvert.DeserializeObject<List<Produto>>(jsonProdutos);
                return listaProdutos;
            }
            catch (Exception ex) {
                Console.WriteLine("Falha ao ler o arquivo JSON: " + ex.Message);
                return null;
            }
        }


        // Serializa uma lista de objetos com StreamWriter
        public static bool SerializaListaDeProdutosStreamReader(List<Produto> listaProdutos) {
            try {
                using (StreamWriter stream = new StreamWriter(Path.Combine(@"D:\Dados", "jsonProdutos.json"))) {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(stream, listaProdutos);
                }
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine("Falha ao criar o arquivo JSON: " + ex.Message);
                return false;
            }

        }

        // Desserializa um arquivo JSON em uma lista de objetos com StreamWriter
        public static List<Produto> DesserializaListaDeProdutosStreamReader() {
            try {
                List<Produto> listaProdutos = new List<Produto>();
                using (StreamReader stream = new StreamReader(@"D:\Dados\jsonProdutos.json")) {
                    string jsonProdutos = stream.ReadToEnd();
                    // Converte o JSON em uma lista de objetos da classe Produto
                    listaProdutos = JsonConvert.DeserializeObject<List<Produto>>(jsonProdutos);
                }
                return listaProdutos;
            }
            catch (Exception ex) {
                Console.WriteLine("Falha ao ler o arquivo JSON: " + ex.Message);
                return null;
            }
        }
    }
}
