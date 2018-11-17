using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartupManager
{
    class ModelUsuarioProjeto
    {
        public DataTable listarTodos(Int64 idProjeto)
        {
            DataTable dt = new DataTable();
            try
            {
                ConexaoBanco.Conectar();


                String sql = "SELECT up.id_usuario AS \"ID\", u.nome AS \"NOME\",u.cargo AS \"CARGO\", u.email AS \"E-MAIL\", up.data_inclusao AS \"INCLUSÃO\" ";
                sql += " FROM usuario_projeto AS up";
                sql += " INNER JOIN usuario AS u ON (u.id_user = up.id_usuario)";
                sql += " WHERE up.id_projeto=" + idProjeto + ";";
                dt = ConexaoBanco.SelecionarDataTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar todos os registros !!! \n" + ex.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexaoBanco.Desconectar();
            return dt;
        }

        public void Inserir(UsuarioProjeto up)
        {
            string sql = "insert into usuario_projeto" +
                         "(id_projeto, id_usuario, data_inclusao)" +
                         "values(@1, @2, @3)";

            List<object> param = new List<object>();

            param.Add(up.Id_projeto);
            param.Add(up.Id_usuario);
            param.Add(DateTime.Now);

            ConexaoBanco.Executar(sql, param);
            ConexaoBanco.Desconectar();
        }
    }
}
