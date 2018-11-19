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
        public bool verifica = false;
        private int id;
        private frmMenu listagem;
        private ModelUsuario model;
        public frmCadastro(int id)
        {
            InitializeComponent();

            this.id = id;
            //DeixaAzul();
            try
            {

                if (id != 0)
                {
                    this.Text = "Alteração";
                    btnSalvar.Text = "Alterar";
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

                if (id == 0)
                {
                    u = new Usuario();
                    pegaCampos();
                    try
                    {
                       // frmLogin login = new frmLogin();
                        ModelUsuario i = new ModelUsuario();
                        i.Insert(u);
                        MessageBox.Show("Dados salvos com sucesso! Prossiga com o Login", "StartUpManager 72B",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();


                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("Erro de execução da QUERY !!! " + er.Message, "StartUpManager 72B",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        pegaCampos();
                        model.Update(u);
                        MessageBox.Show("Usuario Alterado");
                        this.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Erro de execução da QUERY !!! " + exception.Message, "StartUpManager 72B",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void DeixaAzul()
        {
            /* VISUAL*/
            var skinMenager = MaterialSkin.MaterialSkinManager.Instance;
            skinMenager.AddFormToManage(this);
            skinMenager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinMenager.ColorScheme = new MaterialSkin.ColorScheme
                /* (MaterialSkin.Primary.Blue600, MaterialSkin.Primary.Blue700, MaterialSkin.Accent.Indigo100, MaterialSkin.TextShade.WHITE);*/
                (
                    MaterialSkin.Primary.Blue400, MaterialSkin.Primary.Blue500,
                    MaterialSkin.Primary.Blue500, MaterialSkin.Accent.LightBlue200,
                    MaterialSkin.TextShade.WHITE
                );

        }
        private void pegaCampos()
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

            u.Sexo = (radFem.Checked) ? 'F' : 'M';
            u.Nome = txtNome.Text;
            u.Senha = result;
            u.Email = txtEmail.Text;
            u.Cpf = mskCPF.Text;
            u.Cargo = cmbCargo.SelectedItem.ToString();
            u.DataNasc = dtpData.Value.ToString("yyyy-MM-dd");
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

            if (id == 0)
            {
                model = new ModelUsuario();

                DataTable dt = model.BuscaPorCampo("cpf", mskCPF.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Usuario Já Cadastrado !\nProcure um CEO!");
                    Limpa();
                    return false;
                }

            }

            return true;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpa();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            frmLogin log = new frmLogin();
            log.Show();
            this.Hide();
        }

    }
}
