using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DatatableAndJsonToListToCsv {
    public static class ListService {
        // Mescla duas listas em uma única lista e retorna a lista mesclada
        public static List<Produto> MesclaDuasListas(List<Produto> listaProdutosDoBb, List<Produto> listaProdutosDoJson) {
            List<Produto> listaMesclada = new List<Produto>();
            foreach (Produto prodDb in listaProdutosDoBb) {
                Produto novoProduto = prodDb;
                foreach (Produto prodJson in listaProdutosDoJson) {
                    if (prodDb.Id == prodJson.Id) {
                        novoProduto.EstoqueJson = prodJson.Estoque;
                        novoProduto.ValorJson = prodJson.Valor;
                    }
                }
                listaMesclada.Add(novoProduto);
            }
            return listaMesclada;
        }

        // Imprime os dados de uma Lista
        public static void ImprimeProdutosDaLista(List<Produto> listProdutos) {
            Console.WriteLine(" --- DADOS DA LISTA DE PRODUTOS ---");
            Console.WriteLine("-----------------------------------------");
            foreach (var prod in listProdutos) {
                Console.WriteLine($"ID: {prod.Id} - Nome: {prod.Nome} - Estoque: {prod.Estoque} - Estoque JSON: {prod.EstoqueJson} - Valor: R$ {prod.Valor} - Valor Json: R$ {prod.ValorJson} - Data de Cadastro: {prod.DataCadastro} - Última Atualização: {prod.DataAtualizacao}");
            }
            Console.WriteLine("==========================================");
        }

        // Adiciona muitos registros na Lista para realizar teste de extress
        public static void AdicionaMuitosRegistros(List<Produto> listaProdutos) {
            List<Produto> novaListaGrande = new List<Produto>();
            Console.WriteLine("Lista gerada");
            long count = 1;
            //for (int i = 1; i <= 100000; i++) {
            foreach (var prod in listaProdutos) {
                Produto novoProduto = prod;
                novaListaGrande.Add(novoProduto);
                Console.WriteLine($"Produto {count++} lido com sucesso");
                count++;
            }
            //}

             Console.WriteLine("Todos registros foram lidos.");
            Console.WriteLine("Arquivo CSV criado.");

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            // Executa a função que cria e escreve um arquivo CSV a partir de uma Lista e salva o arquivo em um diretório do Sistema Operacional
            CsvService.CriaArquivoCsv(novaListaGrande);
            Console.WriteLine($"Tempo gasto: {stopwatch.ElapsedTicks}");
            stopwatch.Stop();
            Console.WriteLine("Registros inseridos no CSV. Processo finalizado.");
        }
    }
}
