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
        private Usuario u;
        private Canvas canvas = new Canvas();
        private int idProjeto;
        private ModelCanvas modelCanvas = new ModelCanvas();
        public frmCanvasInterativo(Usuario u, int id)
        {
            InitializeComponent();
            this.u = u;
            idProjeto = id;
            InterfaceUsuario();
            if (modelCanvas.ExisteCanvas(idProjeto))
                preencheCampos();
        }
        private void frmCanvasInterativo_Load(object sender, EventArgs e)
        {

        }
        private void preencheCampos()
        {
            DataTable dataTable = modelCanvas.DataReader(idProjeto);
            txtCanais.Text = dataTable.Rows[0][3].ToString();
            txtEstruturaDeCustos.Text = dataTable.Rows[0][8].ToString();
            txtFontesDeReceita.Text = dataTable.Rows[0][9].ToString();
            txtPrincipaisParcerias.Text = dataTable.Rows[0][5].ToString();
            txtPropostaDeValor.Text = dataTable.Rows[0][1].ToString();
            txtRecursos.Text = dataTable.Rows[0][7].ToString();
            txtRelacionamentoComClientes.Text = dataTable.Rows[0][2].ToString();
            txtSegmentoDeClientes.Text = dataTable.Rows[0][4].ToString();
            txtAtividadesPrincipais.Text = dataTable.Rows[0][6].ToString();
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
            canvas.UltimaAlteracao = DateTime.Now;
            canvas.Atividade_chave = txtAtividadesPrincipais.Text;
        }
        private bool validar()
        {
            if (!(String.IsNullOrWhiteSpace(txtAtividadesPrincipais.Text)) || txtAtividadesPrincipais.Text.Length <=2000 )
                return true;
            if (!(String.IsNullOrWhiteSpace(txtCanais.Text)) || txtCanais.Text.Length <=2000)
                return true;
            if (!(String.IsNullOrWhiteSpace(txtEstruturaDeCustos.Text)) || txtEstruturaDeCustos.Text.Length <=2000)
                return true;
            if (!(String.IsNullOrWhiteSpace(txtFontesDeReceita.Text)) || txtFontesDeReceita.Text.Length <=2000)
                return true;
            if (!(String.IsNullOrWhiteSpace(txtPrincipaisParcerias.Text)) || txtPrincipaisParcerias.Text.Length <=2000)
                return true;
            if (!(String.IsNullOrWhiteSpace(txtPropostaDeValor.Text)) || txtPropostaDeValor.Text.Length <=2000)
                return true;
            if (!(String.IsNullOrWhiteSpace(txtRecursos.Text)) || txtRecursos.Text.Length <=2000)
                return true;
            if (!(String.IsNullOrWhiteSpace(txtRelacionamentoComClientes.Text)) || txtRelacionamentoComClientes.Text.Length <=2000)
                return true;
            if (!(String.IsNullOrWhiteSpace(txtSegmentoDeClientes.Text)) || txtSegmentoDeClientes.Text.Length <=2000)
                return true;
            MessageBox.Show("Um campo obrigatoriamente deve estar preenchido e com menos de 2000 caracteres");
            return false;
        }
        
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
                if (modelCanvas.ExisteCanvas(idProjeto))
                {
                    pegaCampos();
                    modelCanvas.Upadate(canvas, idProjeto);                   
                    this.Close();
                }
                else
                {
                    pegaCampos();
                    modelCanvas.Insert(canvas, idProjeto);
                    this.Close();
                }

            }
        }
    }
}