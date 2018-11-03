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
    public partial class frmCadastroAlteracaoProjeto : MaterialSkin.Controls.MaterialForm

    {
        public frmCadastroAlteracaoProjeto()
        {
            InitializeComponent();
            // testar recebimento do ID para mudar o texto entre "CADASTRO" e "ALTERACAO", que nem PHP
            this.Text = "CADASTRO";
        }

        private void frmCadastroAlteracaoProjeto_Load(object sender, EventArgs e)
        {

        }
    }
}
