using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DatatableAndJsonToListToCsv {
    public static class ConexaoDbService {
        // Retorna um DataTable de uma tabela do Sql Server
        public static DataTable ObtemProdutosDaTabelaDoBd() {
            String comandoSql = @"select * from produtos;";
            ConexaoDb con = new ConexaoDb();
            return con.RetornaTabela(comandoSql);
        }

        // Converte um DataTable em uma Lista de Produtos
        public static List<Produto> ConverteDataTableEmListaDeProdutos(DataTable dtProdutos) {
            List<Produto> listProdutos = (
                from prodRow in dtProdutos.AsEnumerable()
                select new Produto() {
                    Id = Convert.ToInt32(prodRow["Id"]),
                    Nome = prodRow["Nome"].ToString(),
                    Estoque = Convert.ToInt32(prodRow["Estoque"]),
                    Valor = Convert.ToDouble(prodRow["Valor"]),
                    DataCadastro = Convert.ToDateTime(prodRow["DataCadastro"]),
                    DataAtualizacao = Convert.ToDateTime(prodRow["DataAtualizacao"])
                }).ToList();
            return listProdutos;
        }

        // Imprime os dados de um DataTable
        public static void ImprimeProdutosDaTabelaDoBd(DataTable dtProdutos) {
            Console.WriteLine(" --- DADOS DA TABELA DO BD ---");
            Console.WriteLine("-----------------------------------------");
            for (int i = 0; i < dtProdutos.Rows.Count; i++) {
                Console.WriteLine($"ID: {dtProdutos.Rows[i]["Id"]} | Nome: {dtProdutos.Rows[i]["Nome"]} | Estoque: {dtProdutos.Rows[i]["Estoque"]} | Valor: R$ {dtProdutos.Rows[i]["Valor"]}");
            }
            Console.WriteLine("==========================================");
        }
    }
}
