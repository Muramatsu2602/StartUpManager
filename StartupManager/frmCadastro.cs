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
              string sql = "insert into usuario" +
             "(email, nome, senha,data_nasc,cpf,sexo,cargo,excluido)"+ 
             "values(@1, @2, @3, @4, @5,@6,@7,@8)";

            List<object> param = new List<object>();

            param.Add(txtNome.Text);
            param.Add(txtEmail.Text);
            param.Add(result);
            param.Add(dtpData.Value);
            param.Add(mskCPF.Text);
            if (radFem.Checked == true)
            {
                param.Add("F");
            }
            else
            {
                param.Add("M");
            }
            param.Add(comboBox1.SelectedItem.ToString());
            param.Add(true);

            try
            {
                ConexaoBanco.Executar(sql, param);
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
