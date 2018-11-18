using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace StartupManager
{
    class ModelCanvas
    {
        public bool ExisteCanvas(int idProjeto)
        {
            bool recebe = false; 
            try
            {
                ConexaoBanco.Conectar();

                String sql = "SELECT id_projeto FROM canvas WHERE id_projeto = " + idProjeto + ";";
                return recebe = ((ConexaoBanco.SelecionarDataTable(sql).Rows.Count) > 0) ? true:false;
                
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Erro ao buscar todos os registros !!! \n" + ex.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexaoBanco.Desconectar();
            }       
            return recebe;
        }
        public DataTable DataReader (int idProjeto)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string sql = "SELECT id_canvas, proposta_de_valor, relacionamento, canais, segmento_cliente, parcerias_chave, atividade_chave, recursos_chave, estrura_dados, fonte_receita, id_projeto";
                sql += " FROM canvas WHERE id_projeto = " + idProjeto + ";" ;
                dataTable = ConexaoBanco.SelecionarDataTable(sql);
            }
            catch(NpgsqlException erro)
            {
                MessageBox.Show("Erro ao buscar todos os registros !!! \n" + erro.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexaoBanco.Desconectar();
            }
            return dataTable;
        }
        public void Insert(Canvas c, int id)
        {
            string sql = "INSERT INTO canvas" +
                         "(canais, fonte_receita, estrura_dados, parcerias_chave, proposta_de_valor, recursos_chave, relacionamento, segmento_cliente, atividade_chave, id_projeto)" +
                         "VALUES(@1, @2, @3, @4, @5, @6, @7, @8, @9, @10);";
            try
            {
                List<object> param = new List<object>();
                param.Add(c.Canais);
                param.Add(c.FonteReceita);
                param.Add(c.EstruturaDados);
                param.Add(c.ParceriasChave);
                param.Add(c.PropostaDeValor);
                param.Add(c.RecursosChave);
                param.Add(c.Relacionamento);
                param.Add(c.SegmentoChave);
                param.Add(c.Atividade_chave);
                param.Add(id);           
                ConexaoBanco.Executar(sql, param);
                MessageBox.Show("Canvas salvo com sucesso!", "StartUpManager 72B",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(NpgsqlException erro)
            {
                MessageBox.Show("Erro ao buscar todos os registros !!! \n" + erro.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexaoBanco.Desconectar();
            }
            
        }
        public void Upadate(Canvas c, int id)
        {
            try
            {
                List<object> param = new List<object>();
                param.Add(c.PropostaDeValor);
                param.Add(c.Relacionamento);
                param.Add(c.Canais);
                param.Add(c.SegmentoChave);
                param.Add(c.ParceriasChave);
                param.Add(c.Atividade_chave);               
                param.Add(c.RecursosChave);
                param.Add(c.EstruturaDados);
                param.Add(c.FonteReceita);
                param.Add(c.UltimaAlteracao);
                String sql = "UPDATE canvas SET ";
                sql += "proposta_de_valor = @1, ";
                sql += "relacionamento = @2, ";
                sql += "canais = @3, ";
                sql += "segmento_cliente = @4, ";
                sql += "parcerias_chave = @5, ";
                sql += "atividade_chave = @6, ";
                sql += "recursos_chave = @7, ";
                sql += "estrura_dados = @8, ";
                sql += "fonte_receita = @9, ";
                sql += "ultima_alteracao = @10 ";
                sql += "WHERE id_projeto = " + id;
                ConexaoBanco.Executar(sql, param);
                MessageBox.Show("Canvas salvo com sucesso!", "StartUpManager 72B",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(NpgsqlException erro)
            {
                MessageBox.Show("Erro ao buscar todos os registros !!! \n" + erro.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexaoBanco.Desconectar();
            }
        }
        
        
    }
}