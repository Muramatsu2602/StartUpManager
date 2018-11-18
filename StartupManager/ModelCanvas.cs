using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartupManager
{
    class ModelCanvas
    {
        public bool Alteracao(int idProjeto)
        {
            
            DataTable dt = new DataTable();
            try
            {
                ConexaoBanco.Conectar();

                String sql = "SELECT id_projeto FROM canvas";
                sql += "WHERE  id_projeto = ''; ";
                dt = ConexaoBanco.SelecionarDataTable(sql);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar todos os registros !!! \n" + ex.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConexaoBanco.Desconectar();
            /*return dt;*/
            return String.IsNullOrWhiteSpace(dt.Rows[0][0].ToString());
        }
    }
}
