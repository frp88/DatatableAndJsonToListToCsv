using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DatatableAndJsonToListToCsv {
    public static class CsvService {
        // Percorre uma lista de objetos (transforma uma lista de objetos em formato CSV, cria um arquivo CSV e salva esse arquivo no PC
        public static bool CriaArquivoCsv(List<Produto> listaProdutos) {
            try {
                string filePath = @"C:\Dados\csvProdutos.csv";
                List<string> linhas = new List<string>();
                string linha = $"Id;Nome;Estoque;Estoque JSON;Valor;Valor JSON;Data de Cadastro;Data de Atualização";
                linhas.Add(linha);
                long count = 1;
                foreach (var prod in listaProdutos) {
                    linha = $"{prod.Id};{prod.Nome};{prod.Estoque};{prod.EstoqueJson};{prod.Valor};{prod.ValorJson};{prod.DataCadastro};{prod.DataAtualizacao}";
                    linhas.Add(linha);
                    Console.WriteLine($"Registro {count} pronto para salvar no arquivo CSV");
                    count++;
                }
                Console.WriteLine("Dados prontos para salvar no arquivo CSV. Por favor aguarde...");
                // Salva o arquivo CSV no PC 
                File.WriteAllLines(filePath, linhas, Encoding.UTF8);
                Console.WriteLine("Dados salvos com sucesso no arquivo CSV!");
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine("Falha ao criar o arquivo CSV: " + ex.Message);
                return false;
            }
        }

        // Percorre uma lista de objetos (transforma uma lista de objetos em formato CSV, cria um arquivo CSV e salva esse arquivo no PC com o StringBuilder
        public static bool CriaArquivoCsvStringBuilder(List<Produto> listaProdutos) {
            try {
                string filePath = @"D:\Dados\csvProdutosStringBuilder.csv";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Id;Nome;Estoque;Estoque JSON;Valor;Valor JSON;Data de Cadastro;Data de Atualização");
                listaProdutos.ForEach(prod => sb.AppendLine(
                   $"{prod.Id};{prod.Nome};{prod.Estoque};{prod.EstoqueJson};{prod.Valor};{prod.ValorJson};{prod.DataCadastro};{prod.DataAtualizacao}"
                   ));
                // Salva o arquivo CSV no PC 
                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
                Console.WriteLine("Arquivo CSV criado com sucesso!");
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine("Falha ao criar o arquivo CSV: " + ex.Message);
                return false;
            }
        }
    }
}
