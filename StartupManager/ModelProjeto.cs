using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartupManager
{
    class ModelProjeto
    {
        public DataTable listarTodos(Usuario u)
        {
            DataTable dt = new DataTable();
            try
            {
                ConexaoBanco.Conectar();

                String sql = "SELECT id_projeto AS \"ID\", nome AS \"NOME\", data_criacao AS \"CRIAÇÃO\",id_ceo AS \"CEO\" FROM projeto ";
                sql += "WHERE data_excluido IS NULL AND id_ceo=" + u.IdUser;
                dt = ConexaoBanco.SelecionarDataTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar todos os registros !!! \n" + ex.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexaoBanco.Desconectar();
            return dt;
        }
        public DataTable listarTodos(int idProjeto)
        {
            DataTable dt = new DataTable();
            try
            {
                ConexaoBanco.Conectar();

                String sql = "SELECT id_projeto AS \"ID\", nome AS \"NOME\", data_criacao AS \"CRIAÇÃO\",id_ceo AS \"CEO\" FROM projeto ";
                sql += "WHERE data_excluido IS NULL AND idProjeto=" + idProjeto;
                dt = ConexaoBanco.SelecionarDataTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar todos os registros !!! \n" + ex.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexaoBanco.Desconectar();
            return dt;
        }
        /*
        public DataTable BuscaPorCampo(string campo, string busca)
        {
            DataTable dt = new DataTable();
            try
            {
                con = new Conexao();
                con.Conectar();
                String sql = "SELECT idcliente, nome, tipo_pessoa, doc_fed, doc_est, dt_nasc, rua, numero, bairro, cidade, estado, cep, telefones, email FROM clientes";
                sql += " WHERE " + campo + " LIKE '%" + busca + "%';";
                dt = con.RetDataTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar os registros !!! \n" + ex.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con = null;
            return dt;
        }*/
        public void Insert(Projeto p)
        {
            string sql = "insert into projeto" +
                         "(descricao, nome, data_criacao,id_ceo)" +
                         "values(@1, @2, @3, @4)";

            List<object> param = new List<object>();

            param.Add(p.Descricao);
            param.Add(p.Nome);
            param.Add(p.DataCriacao);
            param.Add(p.Id_ceo);


            ConexaoBanco.Executar(sql, param);
            ConexaoBanco.Desconectar();
        }
    }
}
