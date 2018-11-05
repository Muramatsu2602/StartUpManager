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
    public partial class frmListaUsuario: MaterialSkin.Controls.MaterialForm
    {
        ModelUsuario up = new ModelUsuario();
        public frmListaUsuario()
        {
            InitializeComponent();
            CarregaGrid();
        }

        

        public  void CarregaGrid()
        {
            dgvDados.DataSource = up.listarTodos();
            //dgvDados.Columns[0].ReadOnly = true;
        }

        private void btnCanvas_Click(object sender, EventArgs e)
        {
            frmCanvasInterativo canvas = new frmCanvasInterativo();
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
                DialogResult dr = MessageBox.Show("Deseja realmente EXCLUIR ?", "RTPark", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
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
    }
}
