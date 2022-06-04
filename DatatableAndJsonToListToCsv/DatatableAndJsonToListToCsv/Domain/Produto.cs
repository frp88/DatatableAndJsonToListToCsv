using System;

namespace DatatableAndJsonToListToCsv {
    public class Produto {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Estoque { get; set; }
        public double Valor { get; set; }
        public int? EstoqueJson { get; set; }
        public double? ValorJson { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public Produto() {
            DataCadastro = DataAtualizacao = DateTime.Now;

        }

        public Produto(string nome, int estoque, double valor) {
            Nome = nome;
            Estoque = estoque;
            Valor = valor;
            DataCadastro = DataAtualizacao = DateTime.Now;
        }
        public Produto(int id, string nome, int estoque, double valor) {
            Id = id;
            Nome = nome;
            Estoque = estoque;
            Valor = valor;
            DataCadastro = DataAtualizacao = DateTime.Now;
        }

        public Produto(int id, string nome, int estoque, double valor, int estoqueJson, double valorJson) {
            Id = id;
            Nome = nome;
            Estoque = estoque;
            Valor = valor;
            EstoqueJson = estoqueJson;
            ValorJson = valorJson;
            DataCadastro = DataAtualizacao = DateTime.Now;
        }
    }
}