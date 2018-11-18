using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartupManager
{
    class ModelUsuario
    {
        public void Insert(Usuario u)
        {
            string sql = "insert into usuario" +
            "(email, nome, senha,data_nasc,cpf,sexo,cargo)" +
            "values(@1, @2, @3, @4, @5, @6, @7)";

            List<object> param = new List<object>();

            param.Add(u.Email);
            param.Add(u.Nome);
            param.Add(u.Senha);
            param.Add(DateTime.Parse(u.DataNasc));
            param.Add(u.Cpf);
            param.Add(u.Sexo);
            param.Add(u.Cargo);
            ConexaoBanco.Executar(sql, param);
            ConexaoBanco.Desconectar();
        }
        public DataTable listarTodos()
        {
            DataTable dt = new DataTable();
            try
            {
                ConexaoBanco.Conectar();

                String sql = "SELECT id_user AS \"ID\", nome AS \"NOME\", email AS \"E-MAIL\",data_nasc AS \"NASCIMENTO\", cpf AS \"CPF\"," +
                             "cargo AS \"CARGO\", sexo AS \"SEXO\" FROM usuario ";
                sql += "WHERE   data_exclusao IS NULL ";
                dt = ConexaoBanco.SelecionarDataTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar todos os registros !!! \n" + ex.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexaoBanco.Desconectar();
            return dt;
        }

        public Usuario BuscaId(Int64 id)
        {
            Usuario u = null;
            try
            {
                ConexaoBanco.Conectar();

                String sql = "SELECT * FROM usuario WHERE id_user= @1";
                List<object> param = new List<object>();
                param.Add(id);
                var dados = ConexaoBanco.Selecionar(sql, param);
                if (dados.Read())
                {
                    u = new Usuario();
                    u.IdUser = Int64.Parse(dados["id_user"].ToString());
                    u.Nome = (string)dados["nome"];
                    u.Email = (string)dados["email"];
                    u.Cargo = (string)dados["cargo"];
                    u.Cpf = (string)dados["cpf"];
                    u.Email = (string)dados["email"];
                    u.DataNasc = dados["data_nasc"].ToString();
                    u.Data_exclusao = dados["data_exclusao"].ToString();
                    u.Senha = (string)dados["senha"];
                    u.Sexo = Char.Parse(dados["sexo"].ToString());

                    ConexaoBanco.Desconectar();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar Usuario de ID:  " + id + "\n" + ex.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexaoBanco.Desconectar();

            return u;
        }

        public void Update(Usuario u)
        {
            try
            {
                String sql = "UPDATE usuario SET ";
                sql += " nome = '" + u.Nome + "', ";
                sql += " senha  = '" + u.Senha + "', ";
                sql += " email  = '" + u.Email + "', ";
                sql += " data_nasc  = '" + u.DataNasc + "', ";
                sql += " cpf  = '" + u.Cpf + "', ";
                sql += " cargo  = '" + u.Cargo + "', ";
                sql += " sexo  = '" + u.Sexo + "' ";
                sql += " WHERE id_user = " + u.IdUser + ";";
                ConexaoBanco.Executar(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o Serviço !!! \n" + ex.Message, "ERRO !!!", MessageBoxButtons.OK,
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
                String sql = "UPDATE usuario SET data_exclusao= " + "'" + DateTime.Now.ToString("yyyy/MM/dd") + "'" + "WHERE id_user = " + id + ";";
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
                String sql = "SELECT  id_user, nome, email, data_nasc, cpf, cargo, sexo FROM usuario";
                if (campo.Equals("id_user"))
                {
                    sql += " WHERE " + campo + " =" + Convert.ToInt64(busca) + ";";
                }
                else if (campo.Equals("data_nasc"))
                {
                    sql += " WHERE " + campo + " LIKE '%" + Convert.ToDateTime(busca) + "%';";
                }
                else
                {
                    sql += " WHERE UPPER(" + campo + ") LIKE UPPER('%" + busca + "%');";
                }

                dt = ConexaoBanco.SelecionarDataTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar os registros !!! \n" + ex.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexaoBanco.Desconectar();
            return dt;
        }
    }
}
