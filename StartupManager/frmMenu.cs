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
    public partial class frmMenu : MaterialSkin.Controls.MaterialForm
    {
        ModelProjeto mp = new ModelProjeto();
        private Usuario u;
        public frmMenu(Usuario u)
        {
            this.u = u;
            InitializeComponent();
            CarregaGrid();
            InterfaceUsuario();

            cmbCampo.SelectedIndex = 0;
        }


        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Quer sair?",
                       "StartUp Manager",
                       MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Information) == DialogResult.OK)
                    Environment.Exit(1);
                else
                    e.Cancel = true;
            }

        }

        public void CarregaGrid()
        {
            dgvDados.DataSource = mp.listarTodos(u);
        }

        private void btnCanvas_Click(object sender, EventArgs e)
        {
            if (dgvDados.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString());
                frmCanvasInterativo canvas = new frmCanvasInterativo(id);
                canvas.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione apenas um Registro!!!");
            }
        }

        private void btnNovo_click(object sender, EventArgs e)
        {
            frmCadastroAlteracaoProjeto projeto = new frmCadastroAlteracaoProjeto(u, 0);
            projeto.ShowDialog();
            CarregaGrid();
        }

        private void btnTime_Click(object sender, EventArgs e)
        {
            frmListaUsuario listar = new frmListaUsuario(u);
            listar.Show();
        }

        private void btnAlterar_click(object sender, EventArgs e)
        {
            if (dgvDados.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString());
                frmCadastroAlteracaoProjeto projeto = new frmCadastroAlteracaoProjeto(u, id);
                projeto.ShowDialog();
                CarregaGrid();
            }
            else
            {
                MessageBox.Show("Selecione apenas um Registro!!!");
            }
        }

        private void InterfaceUsuario()
        {
            if (u.Cargo != "CEO")
            {
                btnNovo.Visible = false;
                btnAlterar.Visible = false;
                btnExcluir.Visible = false;
                btnEquipe.Visible = false;

            }
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtConsulta.Text.Length > 0)
            {
                this.btnBuscar_Click(sender, e);
            }
            else
            {
                CarregaGrid();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrWhiteSpace(txtConsulta.Text))
            {
                try
                {
                    dgvDados.DataSource = mp.BuscaPorCampo(cmbCampo.SelectedItem.ToString(), txtConsulta.Text.ToUpper());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERRO NA CONSULTA DE PROJETOS! \n Mais detalhes:" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Preencha o campo com termos a serem consultados");
                CarregaGrid();
                txtConsulta.Focus();

            }


        }

        private void frmMenu_Shown(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void frmMenu_Activated(object sender, EventArgs e)
        {
            CarregaGrid();
        }



        private void btnEquipe_Click(object sender, EventArgs e)
        {
            if (dgvDados.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString());
                frmEquipe equipe = new frmEquipe(id);
                equipe.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione apenas um Registro!!!");
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
                    mp.Excluir(id);
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

        private void dgvDados_DoubleClick(object sender, EventArgs e)
        {
            txtConsulta.Text = null;
            cmbCampo.SelectedIndex = 0;
            CarregaGrid();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("http://google.com");

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.cti.feb.unesp.br/");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.mit.edu/");

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.sebrae.com.br/sites/PortalSebrae");

        }


    }
}
