using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupManager
{
    class ModelUsuario
    {
        public int Insert(Usuario u)
        {
            string sql = "insert into usuario" +
            "(email, nome, senha,data_nasc,cpf,sexo,cargo)" +
            "values(@1, @2, @3, @4, @5,@6,@7)";

            List<object> param = new List<object>();

            param.Add(u.Email);
            param.Add(u.Nome);
            param.Add(u.Senha);
            param.Add(u.DataNasc);
            param.Add(u.Cpf);
            param.Add(u.Sexo);
            param.Add(u.Cargo);
            ConexaoBanco.Executar(sql, param);
            return u.IdUser;
        }
    }
}
