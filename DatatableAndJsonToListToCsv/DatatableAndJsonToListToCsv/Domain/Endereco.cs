
namespace DatatableAndJsonToListToCsv {
    public class Endereco {
        public int Id { get; set; }

        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string UF { get; set; }

        public Endereco() { }

        public Endereco(string cep) {
            this.Cep = cep;
        }
        public Endereco(string cep, string logradouro, string complemento, string bairro, string uf) {
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Bairro = bairro;
            UF = uf;
        }

        public Endereco(int id, string cep, string logradouro, string complemento, string bairro, string uf) {
            Id = id;
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Bairro = bairro;
            UF = uf;
        }
    }
}
