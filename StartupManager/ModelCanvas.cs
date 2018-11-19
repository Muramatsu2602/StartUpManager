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

        public Canvas BuscaId(Int64 idProjeto)
        {
            Canvas p = null;
            try
            {
                ConexaoBanco.Conectar();

                String sql = "SELECT * FROM canvas WHERE id_projeto= @1";
                List<object> param = new List<object>();
                param.Add(idProjeto);
                var dados = ConexaoBanco.Selecionar(sql, param);
                if (dados.Read())
                {
                    p = new Canvas();
                    p.IdCanvas = Int64.Parse(dados["id_canvas"].ToString());
                    p.PropostaDeValor = (string)dados["proposta_de_valor"];
                    p.Relacionamento = (string)dados["relacionamento"];
                    p.Canais = (string)dados["canais"];
                    p.SegmentoChave = (string)dados["segmento_cliente"];
                    p.ParceriasChave = (string)dados["parcerias_chave"];
                    p.Atividade_chave = (string)dados["atividade_chave"];
                    p.RecursosChave = (string)dados["recursos_chave"];
                    p.EstruturaDados = (string)dados["estrura_dados"];
                    p.FonteReceita = (string)dados["fonte_receita"];
                    p.IdProjeto = Int64.Parse(dados["id_projeto"].ToString());
                    p.UltimaAlteracao = DateTime.Parse(dados["ultima_alteracao"].ToString());

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar Projeto de ID:  " + idProjeto + "\n" + ex.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexaoBanco.Desconectar();
            }

            return p;
        }

        public void Insert(Canvas c)
        {
            string sql = "INSERT INTO canvas" +
                         "(canais, fonte_receita, estrura_dados, parcerias_chave, proposta_de_valor, recursos_chave, relacionamento, segmento_cliente, atividade_chave, id_projeto, ultima_alteracao)" +
                         "VALUES(@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11);";
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
                param.Add(c.IdProjeto);
                param.Add(DateTime.Now);

                ConexaoBanco.Executar(sql, param);
                MessageBox.Show("Canvas salvo com sucesso!", "StartUpManager 72B",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro ao Salvar todos os registros !!! \n" + erro.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexaoBanco.Desconectar();
            }

        }
        public void Update(Canvas c)
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
                param.Add(DateTime.Now);
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
                sql += "WHERE id_canvas = " + c.IdCanvas;
                ConexaoBanco.Executar(sql, param);
                MessageBox.Show("Canvas Atualizado com sucesso!", "StartUpManager 72B",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro ao Atualizar todos os registros !!! \n" + erro.Message, "ERRO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexaoBanco.Desconectar();
            }
        }


    }
}