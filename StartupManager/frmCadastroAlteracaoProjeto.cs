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
        Usuario u;
        frmMenu listagem;
        private Projeto projeto = new Projeto();
        private int id;
        public frmCadastroAlteracaoProjeto(Usuario u, int id)
        {
            InitializeComponent();
            this.u = u;
            // testar recebimento do ID para mudar o texto entre "CADASTRO" e "ALTERACAO", que nem PHP
            if (id == 0)
            {
                this.id = id;
                this.Text = "CADASTRO";
            }
            var s = this.u.IdUser;
        }
        private void frmCadastroAlteracaoProjeto_Load(object sender, EventArgs e)
        {

        }
        private bool validar()
        {
            if (String.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Preencha o campo Email!");
                return false;

            }
            if (String.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MessageBox.Show("Preencha o campo Nome!");
                return false;
            }
            

            return true;
        }
        private void pegaCampos()
        {
            
            projeto.Id_ceo = (int)u.IdUser;
            var teste = u.IdUser;
            projeto.Nome = txtNome.Text;
            projeto.Descricao = txtDescricao.Text;
            projeto.DataCriacao = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validar())
            {

                if (id == 0)
                {
                    pegaCampos();
                    try
                    {
                       
                        ModelProjeto i = new ModelProjeto();
                        i.Insert(projeto);
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
                /*else
                {
                    try
                    {
                        pegaCampos();
                        model.Update(u);
                        MessageBox.Show("Usuario Alterado");
                        this.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Erro de execução da QUERY !!! " + exception.Message, "StartUpManager 72B",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }*/

            }
        }
    }
}
