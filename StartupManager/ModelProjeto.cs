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

                String sql = "SELECT p.id_projeto AS  \"ID\", p.nome AS \"NOME\",p.data_criacao AS  \"CRIAÇÃO \", u.nome AS  \"CEO \" FROM projeto AS \"p\" ";
                sql += " INNER JOIN usuario AS \"u\" ON (u.id_user = p.id_ceo)";
                sql += " WHERE id_ceo= " + u.IdUser + " AND data_excluido IS NULL ;";

                dt = ConexaoBanco.SelecionarDataTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar todos os registros !!! \n" + ex.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexaoBanco.Desconectar();
            return dt;
        }

       
        public void Insert(Projeto p)
        {
            string sql = "insert into projeto" +
                         "(descricao, nome, data_criacao,id_ceo)" +
                         "values(@1, @2, @3, @4)";

            List<object> param = new List<object>();

            param.Add(p.Descricao);
            param.Add(p.Nome);
            param.Add(DateTime.Parse(p.DataCriacao));
            param.Add(p.Id_ceo);

            ConexaoBanco.Executar(sql, param);
            ConexaoBanco.Desconectar();
        }

        public bool VerificaIdCEO(int id)
        {
            //ModelUsuario model = new ModelUsuario();

            //DataTable dt = model.BuscaPorCampo("id_ceo", id.ToString());
            //if (dt.Rows.Count > 0)
            //{
            //    return true;
            //}

            String sql = "SELECT * FROM usuario WHERE id_user =" + id + " AND cargo= 'CEO'";

            if (ConexaoBanco.Selecionar(sql) != null)
            {
                return true;
            }
            ConexaoBanco.Desconectar();
            return false;


        }

        public Projeto BuscaId(Int64 id)
        {
            Projeto p = null;
            try
            {
                ConexaoBanco.Conectar();

                String sql = "SELECT * FROM projeto WHERE id_projeto= @1";
                List<object> param = new List<object>();
                param.Add(id);
                var dados = ConexaoBanco.Selecionar(sql, param);
                if (dados.Read())
                {
                    p = new Projeto();
                    p.IdProjeto = Int64.Parse(dados["id_projeto"].ToString());
                    p.Descricao = (string)dados["descricao"];
                    p.Nome = (string)dados["nome"];
                    p.DataCriacao = dados["data_criacao"].ToString();
                    p.Id_ceo = Int64.Parse(dados["id_ceo"].ToString());
                    p.DataExcluido = dados["data_excluido"].ToString();
                    p.UltimaAlteracao = dados["ultima_alteracao"].ToString();


                    ConexaoBanco.Desconectar();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar Projeto de ID:  " + id + "\n" + ex.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexaoBanco.Desconectar();

            return p;
        }

        public void Update(Projeto p)
        {
            try
            {
                String sql = "UPDATE projeto SET ";
                sql += " nome = '" + p.Nome + "', ";
                sql += " descricao  = '" + p.Descricao + "', ";
                sql += " ultima_alteracao  = '" + DateTime.Now.ToString("yyyy/MM/dd") + "' ";
                sql += " WHERE id_projeto = " + p.IdProjeto + ";";
                ConexaoBanco.Executar(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o Projeto !!! \n" + ex.Message, "ERRO !!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                ConexaoBanco.Desconectar();
            }
        }

        public void Excluir(int id)
        {
            try
            {
                ConexaoBanco.Conectar();
                String sql = "UPDATE projeto SET data_excluido= " + "'" + DateTime.Now + "'" + "WHERE id_projeto = " + id + ";";
                ConexaoBanco.Executar(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir o Serviço !!! \n" + ex.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexaoBanco.Desconectar();
            }
        }

        public DataTable BuscaPorCampo(string campo, string busca)
        {
            DataTable dt = new DataTable();
            try
            {
                ConexaoBanco.Conectar();

                String sql = "SELECT  id_projeto AS \"ID\" , nome AS \"NOME\", descricao AS \"DESCRIÇÃO\", data_criacao AS \"CRIAÇÃO\", id_ceo AS \"ID do CEO\"  FROM projeto";
                if (campo.Equals("id_projeto"))
                {
                    sql += " WHERE " + campo + " =" + Convert.ToInt64(busca) + ";";
                }
                else
                {
                    sql += " WHERE UPPER(" + campo + ") LIKE UPPER('%" + busca + "%');";
                }

                dt = ConexaoBanco.SelecionarDataTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar os registros de projetos !!! \n" + ex.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexaoBanco.Desconectar();
            return dt;
        }
    }
}
