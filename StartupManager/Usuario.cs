using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupManager
{
    class Usuario
    {
        private String ultimaAlteracao;
        private int idUser;
        private String nome;
        private String senha;
        private String email;
        private DateTime dataNasc;
        private String cpf;
        private String cargo;
        private Boolean data_exclusao;
        private char sexo;

        public string UltimaAlteracao { get => ultimaAlteracao; set => ultimaAlteracao = value; }
        public int IdUser { get => idUser; set => idUser = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Email { get => email; set => email = value; }
        public DateTime DataNasc { get => dataNasc; set => dataNasc = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public bool Data_exclusao { get => data_exclusao; set => data_exclusao = value; }
        public char Sexo { get => sexo; set => sexo = value; }
    }
}
