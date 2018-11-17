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
        public frmCanvasInterativo(Usuario u)
        {
            InitializeComponent();
            this.u = u;
          
        }

        private void frmCanvasInterativo_Load(object sender, EventArgs e)
        {

        }

        private void btnAjudaCanvas_Click(object sender, EventArgs e)
        {
            frmAjudaCanvas ajuda = new frmAjudaCanvas();
            ajuda.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Deseja realmente SAIR ?", "StartUp Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            
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
    }
}
