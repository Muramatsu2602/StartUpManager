using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupManager
{
    public class Usuario
    {
        private Int64 idUser;
        private String nome;
        private String senha;
        private String email;
        private String dataNasc;
        private String cpf;
        private String cargo;
        private String data_exclusao;
        private char sexo;

        public Int64 IdUser { get => idUser; set => idUser = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Email { get => email; set => email = value; }
        public string DataNasc { get => dataNasc; set => dataNasc = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public string Data_exclusao { get => data_exclusao; set => data_exclusao = value; }
        public char Sexo { get => sexo; set => sexo = value; }
    }
}
