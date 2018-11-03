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
        public frmCanvasInterativo()
        {
            InitializeComponent();
        }

        private void frmCanvasInterativo_Load(object sender, EventArgs e)
        {

        }

        private void btnAjudaCanvas_Click(object sender, EventArgs e)
        {
            frmAjudaCanvas ajuda = new frmAjudaCanvas();
            ajuda.ShowDialog();
        }
    }
}
