using System;
using System.Collections.Generic;
using System.Data;

namespace DatatableAndJsonToListToCsv {
    public class Program {
        static void Main(string[] args) {
            // Obtém produtos da tabela do banco de dados SQL Server
            DataTable dtProdutos = ConexaoDbService.ObtemProdutosDaTabelaDoBd();
            ConexaoDbService.ImprimeProdutosDaTabelaDoBd(dtProdutos);

            // Converte um dataTable em um List
            List<Produto> listaProdutosDoBb = ConexaoDbService.ConverteDataTableEmListaDeProdutos(dtProdutos);
            ListService.ImprimeProdutosDaLista(listaProdutosDoBb);

            // Executa a função que lê um arquivo JSON e cria uma Lista de Objetos de uma Classe
            List<Produto> listaProdutosDoJson = JsonService.DesserializaListaDeProdutos();
            ListService.ImprimeProdutosDaLista(listaProdutosDoJson);

            // Executa a função que mescla duas listas (enviadas como parâmetro) em uma única lista e retorna a lista mesclada
            List<Produto> listaMesclada = ListService.MesclaDuasListas(listaProdutosDoBb, listaProdutosDoJson);
            Console.WriteLine("\n--- LISTA MESCLADA ---");
            ListService.ImprimeProdutosDaLista(listaMesclada);

            // Executa a função que cria e escreve um arquivo CSV a partir de uma Lista e salva o arquivo em um diretório do Sistema Operacional
            CsvService.CriaArquivoCsv(listaMesclada);


            // Executa a função que cria e escreve um arquivo JSON a partir de uma Lista e salva o arquivo em um diretório do Sistema Operacional
            //bool resultado = JsonService.SerializaListaDeProdutos(listaMesclada);


            // Executa a função que busca o Endereço
            string cep = "15370496";
            var endereco = EnderecoService.ObtemEnderecoPeloCep(cep);
            if (endereco == null) {
                Console.WriteLine("Endereço não encontrado.");
            }
            else {
                Console.WriteLine(" -- Logradouro do Endereço (objeto): " + endereco.Logradouro);
            }

            Console.ReadKey();
        }
    }
}
