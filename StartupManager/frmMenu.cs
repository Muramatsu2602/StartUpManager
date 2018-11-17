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
        }


        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void CarregaGrid()
        {
            dgvDados.DataSource = mp.listarTodos(u);
        }

        private void btnCanvas_Click(object sender, EventArgs e)
        {
            frmCanvasInterativo canvas = new frmCanvasInterativo(u);
            canvas.ShowDialog();
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
        }

        private void InterfaceUsuario()
        {
            if (u.Cargo != "CEO")
            {
                btnNovo.Visible = false;
                btnAlterar.Visible = false;
                btnExcluir.Visible = false;
                //btnTime.Visible = false;
                //lblTime.Visible = false;
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

        }

        private void frmMenu_Shown(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void frmMenu_Activated(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

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
            /*
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
            */
        }
    }
}
