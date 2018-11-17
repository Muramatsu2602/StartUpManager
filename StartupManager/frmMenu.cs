﻿using System;
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
        }


        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void CarregaGrid()
        {
            dgvDados.DataSource = mp.listarTodos(u);
            //dgvDados.Columns[0].ReadOnly = true;
        }

        private void btnCanvas_Click(object sender, EventArgs e)
        {
            frmCanvasInterativo canvas = new frmCanvasInterativo();
            canvas.ShowDialog();
        }

        private void btnNovo_click(object sender, EventArgs e)
        {
            frmCadastroAlteracaoProjeto projeto = new frmCadastroAlteracaoProjeto(u);
            projeto.ShowDialog();
            CarregaGrid();
        }

        private void btnTime_Click(object sender, EventArgs e)
        {
            frmListaUsuario listar = new frmListaUsuario();
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
    }
}
