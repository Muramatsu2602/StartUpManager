using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;



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
            frmCanvasInterativo canvas = new frmCanvasInterativo(id);
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

        private void frmListaUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if(MessageBox.Show("Quer sair?",
                       "StartUp Manager",
                       MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Information) == DialogResult.OK)
                    Environment.Exit(1);
                else
                    e.Cancel = true; 
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                using (var doc = new PdfSharp.Pdf.PdfDocument())
                {
                    var page = doc.AddPage();
                    var graphics = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
                    var textFormatter = new PdfSharp.Drawing.Layout.XTextFormatter(graphics);
                    var font = new PdfSharp.Drawing.XFont("Arial", 10);
                    int cont = up.listarTodos().Rows.Count;
                    /*cont = 2;*/
                    int posicaoY = 20;
                    int[] posicaoX = { 20, 25, 90, 160, 260, 340, 390 };
                    for (int i = 0; i < cont - 1; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            /*if (i == cont)
                                break;*/
                            textFormatter.DrawString(up.listarTodos().Rows[i][j].ToString(), font, PdfSharp.Drawing.XBrushes.Red, new PdfSharp.Drawing.XRect(posicaoX[j], posicaoY, page.Width, page.Height));


                        }
                        posicaoY += 10;

                        /*if (i == cont)
                            break;*/
                    }
                    doc.Save("arquivo.pdf");
                    System.Diagnostics.Process.Start("arquivo.pdf");
                }
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
          /*  Document documento = new Document(PageSize.A4, 5, 5, 15, 15);
            PdfWriter.GetInstance(documento, new Fil(HttpContext.Current.Server.MapPath("~/documento.pdf"), FileMode.Create));
            documento.Open();
            // cria tablela de 4 coluna
            PdfPTable tabela = new PdfPTable(4);
            // cria uma célula - será usada para cada célula abaixo

            PdfPCell celula = new PdfPCell();*/

        }
    }
}
