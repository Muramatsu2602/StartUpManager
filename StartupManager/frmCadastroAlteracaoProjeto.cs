using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartupManager
{
    public partial class frmCadastroAlteracaoProjeto : MaterialSkin.Controls.MaterialForm

    {
        private Usuario u;
        private Projeto p;
        private ModelProjeto model;
        private ModelUsuario modelUsuario;
        private int id;
        
        public frmCadastroAlteracaoProjeto(Usuario u, int idProjeto)
        {
            InitializeComponent();
            model = new ModelProjeto();
            this.u = u;
            // testar recebimento do ID para mudar o texto entre "CADASTRO" e "ALTERACAO", que nem PHP
            this.Text = "ALTERAR";
            id = idProjeto;

            try
            {

                if (id != 0)
                {
                    this.Text = "Alteração";
                    btnSalvar.Text = "Alterar";
                    p = model.BuscaId(id);
                    // exibir dados no formulario
                    txtNome.Text = p.Nome;
                    txtDescricao.Text = p.Descricao;
                    modelUsuario = new ModelUsuario();
                    u = modelUsuario.BuscaId(p.Id_ceo);
                }
                else
                {
                    p = new Projeto();
                    this.Text = "Cadastro";
                    modelUsuario = new ModelUsuario();
                    u = modelUsuario.BuscaId(u.IdUser);
                }

                lblIdCEO.Text = u.IdUser.ToString();
                lblNomeCEO.Text = u.Nome;

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        private void frmCadastroAlteracaoProjeto_Load(object sender, EventArgs e)
        {

        }
        private bool validar()
        {
            if (String.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Preencha o campo Nome!");
                return false;

            }
            if (String.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MessageBox.Show("Preencha o campo Descrição!");
                return false;
            }


            return true;
        }
        private void pegaCampos()
        {
            
            p.Id_ceo = u.IdUser;
            p.Nome = txtNome.Text;
            p.Descricao = txtDescricao.Text;
            p.DataCriacao = (id == 0)?DateTime.Now.ToString("yyyy-MM-dd"):p.DataCriacao;
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validar())
            {

                if (id == 0)
                {
                    try
                    {
                        pegaCampos();

                        model.Insert(p);
                        MessageBox.Show("Dados salvos com sucesso!", "StartUpManager 72B",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("Erro de execução da QUERY !!! " + er.Message, "StartUpManager 72B",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        pegaCampos();
                        model.Update(p);
                        MessageBox.Show("Projeto Alterado");
                        this.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Erro de execução da QUERY na alteracao !!! " + exception.Message, "StartUpManager 72B",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

    }
}
