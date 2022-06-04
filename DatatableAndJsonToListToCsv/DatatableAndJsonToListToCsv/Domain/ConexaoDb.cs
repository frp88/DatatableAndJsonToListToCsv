using System;
using System.Data;
using System.Data.SqlClient;

namespace DatatableAndJsonToListToCsv {
    public class ConexaoDb {
        static String strConexao = @"Data Source=localhost; " +
             "Initial Catalog=ecommerce; Integrated Security=True";
        SqlConnection con = new SqlConnection(strConexao);

        public Boolean ExecutaComandos(String comandoSql) {
            try {
                con.Open();
                SqlCommand comando = new SqlCommand(comandoSql, con);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception erro) {
                Console.WriteLine(erro.Message);
                return false;
            }
            finally {
                con.Close();
            }
        }

        public int RetornaValor(String comandoSQL) {
            try {
                con.Open();
                SqlCommand comando = new SqlCommand(comandoSQL, con);
                int valor = Convert.ToInt32(comando.ExecuteScalar());
                return valor;
            }
            catch (Exception erro) {
                Console.WriteLine(erro.Message);
                throw;
            }
            finally {
                con.Close();
            }

        }


        public DataTable RetornaTabela(String comandoSQL) {
            try {
                con.Open();
                SqlCommand comando = new SqlCommand(comandoSQL, con);
                DataTable tabela = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(comandoSQL, con);
                adaptador.Fill(tabela);
                return tabela;
            }
            catch (Exception erro) {
                Console.WriteLine(erro.Message);
                throw;
            }
            finally {
                con.Close();
            }
        }
    }
}
