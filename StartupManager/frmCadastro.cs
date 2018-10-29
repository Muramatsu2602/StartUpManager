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
using System.Security.Cryptography;

namespace StartupManager
{
    public partial class frmCadastro : MaterialSkin.Controls.MaterialForm
    {

        private bool novoCadastro = false;//É true na função novo Cadastro   
        Usuario u;
    
        public frmCadastro()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            radMasc.Checked = true;
        }
        // a conexao é executada
        private void frmCadastro_Load(object sender, EventArgs e)
        {
            ConexaoBanco.Conectar();  
        }
        private void frmCadastro_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConexaoBanco.Desconectar();
        }
        private void Limpa()
        {
            txtEmail.Clear();
            txtNome.Clear();
            txtSenha.Clear();
            comboBox1.Refresh();



        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            u = new Usuario();
            string result;
            using (MD5 hash = MD5.Create())
            {
                result = String.Join
                (
                    "",
                    from ba in hash.ComputeHash
                    (
                        Encoding.UTF8.GetBytes(txtSenha.Text)
                    )
                    select ba.ToString("x2")
                );
            }

            frmLogin login = new frmLogin();
            u.Sexo = (radFem.Checked) ? 'F' : 'M';
            u.Nome = txtNome.Text;
            u.Senha = result;
            u.Email = txtEmail.Text;
            u.Cargo = comboBox1.SelectedItem.ToString();
            u.DataNasc = dtpData.ToString();

            try
            {
               // chamar metodo do model
                MessageBox.Show("Dados salvos com sucesso!", "StartUpManager 72B",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
               this.Hide();
               login.Show();

            }
            catch (Exception er)
            {
                MessageBox.Show("Erro de execução da QUERY !!! "+er.Message, "StartUpManager 72B",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpa();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmLogin log = new frmLogin();
            log.Show();
            this.Hide();
        }
    }
}
