using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupManager
{
    class UsuarioProjeto
    {
        private int id;
        private int id_usuario;
        private int id_projeto;
        private String data_inclusao;
        private String data_exclusao;

        public int Id { get => id; set => id = value; }
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public int Id_projeto { get => id_projeto; set => id_projeto = value; }
        public string Data_inclusao { get => data_inclusao; set => data_inclusao = value; }
        public string Data_exclusao { get => data_exclusao; set => data_exclusao = value; }
    }
}
