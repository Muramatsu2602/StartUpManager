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
    public partial class frmListaUsuario : MaterialSkin.Controls.MaterialForm
    {
        ModelUsuario up = new ModelUsuario();
        private Usuario u;
        public frmListaUsuario(Usuario u)
        {
            InitializeComponent();
            this.u = u;
            if (u.Cargo != "CEO")
            {
                btnNovo.Visible = false;
                btnAlterar.Visible = false;
                btnExcluir.Visible = false;
            }
         
            CarregaGrid();
            cmbCampo.SelectedIndex = 1;
        }
        public void CarregaGrid()
        {
            dgvDados.DataSource = up.listarTodos();
            //dgvDados.Columns[0].ReadOnly = true;
        }

        private void btnCanvas_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString());
            frmCanvasInterativo canvas = new frmCanvasInterativo(u, id);
            canvas.ShowDialog();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCadastro cad = new frmCadastro(0);
            cad.ShowDialog();
            CarregaGrid();

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgvDados.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString());
                frmCadastro altera = new frmCadastro(id);
                altera.ShowDialog();
                CarregaGrid();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvDados.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString());
                DialogResult dr = MessageBox.Show("Deseja realmente EXCLUIR ?", "StartUp Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                {
                    up.Excluir(id);
                    CarregaGrid();
                }
            }
            else
            {
                MessageBox.Show("Selecione apenas um Registro!!!");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtConsulta.Text = null;
            cmbCampo.SelectedIndex = 0;
            CarregaGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtConsulta.Text))
            {
                MessageBox.Show("Preencha o campo com termos a serem consultados");
                CarregaGrid();
                txtConsulta.Focus();
            }

            if (cmbCampo.SelectedText == "...")
            {
                MessageBox.Show("Escolha um campo a ser consultado");
                CarregaGrid();
                cmbCampo.Focus();
            }

            try
            {
              
               dgvDados.DataSource = up.BuscaPorCampo(cmbCampo.SelectedItem.ToString(), txtConsulta.Text.ToUpper());

            }
            catch (Exception exception)
            {

            }

        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CarregaGrid();
        }

        private void btnProjeto_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu(u);
            menu.Show();
            this.Close();
        }
    }
}
