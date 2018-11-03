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
        private ModelUsuario model;
        public frmCadastro(int id)
        {
            InitializeComponent();
            try
            {

                if (id != 0)
                {
                    this.Text = "Alteração";
                    model = new ModelUsuario();
                    u = model.BuscaId(id);
                    // exibir dados no formulario
                    txtEmail.Text = u.Email;
                    txtNome.Text = u.Nome;
                    mskCPF.Text = u.Cpf;
                    dtpData.Value = DateTime.Parse(u.DataNasc);
                    if (u.Sexo.ToString().Equals("M"))
                    {
                        radMasc.Checked = true;
                    }
                    else
                    {
                        radFem.Checked = true;
                    }
                    cmbCargo.SelectedItem = u.Cargo;
                }
                else
                {
                    this.Text = "Cadastro";
                    cmbCargo.SelectedIndex = 0;
                    radMasc.Checked = true;
                }

            }
            catch (Exception e)
            {
                throw e;
            }

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
            cmbCargo.Refresh();
            mskCPF.Clear();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validar())
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

                u.Sexo = (radFem.Checked) ? 'F' : 'M';
                u.Nome = txtNome.Text;
                u.Senha = result;
                u.Email = txtEmail.Text;
                u.Cpf = mskCPF.Text;
                u.Cargo = cmbCargo.SelectedItem.ToString();
                u.DataNasc = dtpData.Value.ToString("yyyy-MM-dd");

                try
                {
                    frmLogin login = new frmLogin();
                    ModelUsuario i = new ModelUsuario();
                    i.Insert(u);
                    MessageBox.Show("Dados salvos com sucesso!", "StartUpManager 72B",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    login.Show();

                }
                catch (Exception er)
                {
                    MessageBox.Show("Erro de execução da QUERY !!! " + er.Message, "StartUpManager 72B",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


        }

        private bool validar()
        {
            if (String.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Preencha o campo Email!");
                return false;

            }
            if (String.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Preencha o campo Nome!");
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Preencha o campo Senha!");
                return false;
            }

            mskCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (mskCPF.Text.Length >= 0 && mskCPF.Text.Length < 11)
            {

                MessageBox.Show("Preencha o campo CPF de modo correto!");
                return false;

            }

            mskCPF.TextMaskFormat = MaskFormat.IncludeLiterals;

            if (!radFem.Checked && !radMasc.Checked)
            {

                MessageBox.Show("Selecione o campo Sexo!");
                return false;

            }
            if (cmbCargo.SelectedIndex == 0)
            {

                MessageBox.Show("Preencha o campo Cargo!");
                return false;

            }

            return true;
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
