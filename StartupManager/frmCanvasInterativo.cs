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
    public partial class frmCanvasInterativo : MaterialSkin.Controls.MaterialForm

    {
        private Usuario u;
        private Canvas canvas = new Canvas();
        private int idProjeto;
        private ModelCanvas modelCanvas = new ModelCanvas();
        public frmCanvasInterativo(Usuario u, int id)
        {
            InitializeComponent();
            this.u = u;
            idProjeto = id;
        }
        private void frmCanvasInterativo_Load(object sender, EventArgs e)
        {

        }

        private void btnAjudaCanvas_Click(object sender, EventArgs e)
        {
            frmAjudaCanvas ajuda = new frmAjudaCanvas();
            ajuda.ShowDialog();
        }
        private void pegaCampos()
        {
            canvas.Canais = txtCanais.Text;
            canvas.EstruturaDados = txtEstruturaDeCustos.Text;
            canvas.FonteReceita = txtFontesDeReceita.Text;
            canvas.ParceriasChave = txtPrincipaisParcerias.Text;
            canvas.PropostaDeValor = txtPropostaDeValor.Text;
            canvas.RecursosChave = txtRecursos.Text;
            canvas.Relacionamento = txtRelacionamentoComClientes.Text;
            canvas.SegmentoChave = txtSegmentoDeClientes.Text;
            canvas.UltimaAlteracao = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private bool validar()
        {
            if (!(String.IsNullOrWhiteSpace(txtAtividadesPrincipais.Text)))
                return true;
            if (!(String.IsNullOrWhiteSpace(txtCanais.Text)))
                return true;
            if (!(String.IsNullOrWhiteSpace(txtEstruturaDeCustos.Text)))
                return true;
            if (!(String.IsNullOrWhiteSpace(txtFontesDeReceita.Text)))
                return true;
            if (!(String.IsNullOrWhiteSpace(txtPrincipaisParcerias.Text)))
                return true;
            if (!(String.IsNullOrWhiteSpace(txtPropostaDeValor.Text)))
                return true;
            if (!(String.IsNullOrWhiteSpace(txtRecursos.Text)))
                return true;
            if (!(String.IsNullOrWhiteSpace(txtRelacionamentoComClientes.Text)))
                return true;
            if (!(String.IsNullOrWhiteSpace(txtSegmentoDeClientes.Text)))
                return true;
            MessageBox.Show("Um campo obrigatoriamente deve estar preenchido");
            return false;
        }
        /*private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Deseja realmente SAIR ?", "StartUp Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            
        }*/
        

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            frmAjudaCanvas ajuda = new frmAjudaCanvas();
            ajuda.ShowDialog();
        }

        private void InterfaceUsuario()
        {
            if (u.Cargo != "CEO")
            {
                btnSalvar.Visible = false;
                btnExcluir.Visible = false;
                txtCanais.Enabled = false;
                txtEstruturaDeCustos.Enabled = false;
                txtFontesDeReceita.Enabled = false;
                txtPrincipaisParcerias.Enabled = false;
                txtPropostaDeValor.Enabled = false;
                txtRecursos.Enabled = false;
                txtRelacionamentoComClientes.Enabled = false;
                txtRecursos.Enabled = false;
                txtSegmentoDeClientes.Enabled = false;
                txtAtividadesPrincipais.Enabled = false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (modelCanvas.Alteracao(idProjeto))
                {
                    lblNomeProjeto.Text = "foi";
                }
                /*if (id == 0)
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
                }*/

            }
        }
    }
}
