using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Security.Cryptography;
using System.Text.RegularExpressions;


namespace StartupManager
{
    public partial class frmLogin : MaterialSkin.Controls.MaterialForm
    {
        private Usuario u;
        private Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

        private void frmCadastro_Load(object sender, EventArgs e)
        {
            try
            {
                ConexaoBanco.Conectar();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Eis que surgiu um erro ao conectar-se ao Banco de Dados!" + "\n\nSaiba Mais: " +
                                 erro.Message, "StartUpManager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void StartForm()
        {
            Application.Run(new frmSplashScreen());
        }

        public frmLogin()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
            txtEmail.Focus();
        }
        private void Limpa()
        {
            txtEmail.Clear();
            txtSenha.Clear();

        }
        private void btnCancela_Click(object sender, EventArgs e)
        {
            Limpa();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConexaoBanco.Desconectar();
            Application.Exit();
        }

        private void btnEntra_Click(object sender, EventArgs e)
        {

            // teste de consistencia basico (enquanto nao há verificacao real do  bd)

            if (!String.IsNullOrWhiteSpace(txtEmail.Text) || rg.IsMatch(txtEmail.Text) )
            {
                if (!String.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    string sql = "select * from usuario where email = @1 and senha = @2";

                    List<object> param = new List<object>();

                    param.Add(txtEmail.Text);
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
                    param.Add(result);
                    var dados = ConexaoBanco.Selecionar(sql, param);
                    if (dados.Read())
                    {


                        u = new Usuario();
                        u.IdUser = Int64.Parse(dados["id_user"].ToString());
                        u.Nome = (string)dados["nome"];
                        u.Email = (string)dados["email"];
                        u.Cargo = (string)dados["cargo"];
                        u.Cpf = (string)dados["cpf"];
                        u.Email = (string)dados["email"];
                        u.DataNasc = dados["data_nasc"].ToString();
                        u.Data_exclusao = dados["data_exclusao"].ToString();
                        u.Senha = (string)dados["senha"];
                        u.Sexo = Char.Parse(dados["sexo"].ToString());

                        ConexaoBanco.Desconectar();
                        this.Hide();
                        frmMenu menu = new frmMenu(u);
                        menu.Show();
                        Limpa();


                    }
                    else
                    {
                        MessageBox.Show("Colaborador não encontrado! Verifique os campos", "StartUpManager 72B", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ConexaoBanco.Desconectar();
                        Limpa();
                    }

                }
                else
                {
                    MessageBox.Show("Preencha o campo de senha!", "StartUpManager 72B", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha o campo de e-mail! adequadamente", "StartUpManager 72B", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Deseja sair?", "StartUpManager", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (resp == DialogResult.OK)
            {
                this.Close();
                Application.Exit();
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }

        private void lblCadastrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCadastro cad = new frmCadastro(0);
            cad.Show();
        }
    }
}
