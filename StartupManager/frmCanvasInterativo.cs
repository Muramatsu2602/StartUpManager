using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace StartupManager
{
    public partial class frmCanvasInterativo : MaterialSkin.Controls.MaterialForm

    {
        private Canvas canvas;
        private Projeto projeto;
        private int idProjeto;
        private ModelCanvas modelCanvas = new ModelCanvas();
        private ModelProjeto modelProjeto = new ModelProjeto();
        public frmCanvasInterativo(int id)
        {
            InitializeComponent();
            idProjeto = id;

            //Busca para saber se existe um canvas
            canvas = modelCanvas.BuscaId(idProjeto);

            //Pega os dados do projeto
            projeto = modelProjeto.BuscaId(idProjeto);

            lblNomeProjeto.Text = projeto.Nome;

            if (canvas != null)
            {
                preencheCampos();
                lblUltimaAtualizacao.Text = canvas.UltimaAlteracao.ToString("dd/MM/yyyy");
            }
            else
            {
                canvas = new Canvas();
                canvas.IdProjeto = idProjeto;
                lblUltimaAtualizacao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }
        private void frmCanvasInterativo_Load(object sender, EventArgs e)
        {

        }
        private void preencheCampos()
        {
            txtCanais.Text = canvas.Canais;
            txtEstruturaDeCustos.Text = canvas.EstruturaDados;
            txtFontesDeReceita.Text = canvas.FonteReceita;
            txtPrincipaisParcerias.Text = canvas.ParceriasChave;
            txtPropostaDeValor.Text = canvas.PropostaDeValor;
            txtRecursos.Text = canvas.RecursosChave;
            txtRelacionamentoComClientes.Text = canvas.Relacionamento;
            txtSegmentoDeClientes.Text = canvas.SegmentoChave;
            txtAtividadesPrincipais.Text = canvas.Atividade_chave;
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
            canvas.Atividade_chave = txtAtividadesPrincipais.Text;
        }
        private bool validar()
        {
            if (!(String.IsNullOrWhiteSpace(txtAtividadesPrincipais.Text)) || txtAtividadesPrincipais.Text.Length <= 2000)
                return true;
            if (!(String.IsNullOrWhiteSpace(txtCanais.Text)) || txtCanais.Text.Length <= 2000)
                return true;
            if (!(String.IsNullOrWhiteSpace(txtEstruturaDeCustos.Text)) || txtEstruturaDeCustos.Text.Length <= 2000)
                return true;
            if (!(String.IsNullOrWhiteSpace(txtFontesDeReceita.Text)) || txtFontesDeReceita.Text.Length <= 2000)
                return true;
            if (!(String.IsNullOrWhiteSpace(txtPrincipaisParcerias.Text)) || txtPrincipaisParcerias.Text.Length <= 2000)
                return true;
            if (!(String.IsNullOrWhiteSpace(txtPropostaDeValor.Text)) || txtPropostaDeValor.Text.Length <= 2000)
                return true;
            if (!(String.IsNullOrWhiteSpace(txtRecursos.Text)) || txtRecursos.Text.Length <= 2000)
                return true;
            if (!(String.IsNullOrWhiteSpace(txtRelacionamentoComClientes.Text)) || txtRelacionamentoComClientes.Text.Length <= 2000)
                return true;
            if (!(String.IsNullOrWhiteSpace(txtSegmentoDeClientes.Text)) || txtSegmentoDeClientes.Text.Length <= 2000)
                return true;
            MessageBox.Show("Um campo obrigatoriamente deve estar preenchido e com menos de 2000 caracteres");
            return false;
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            frmAjudaCanvas ajuda = new frmAjudaCanvas();
            ajuda.ShowDialog();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (canvas.IdCanvas != 0)
                {
                    pegaCampos();
                    modelCanvas.Update(canvas);
                    this.Close();
                }
                else
                {
                    pegaCampos();
                    modelCanvas.Insert(canvas);
                    this.Close();
                }

            }
        }
    }
}