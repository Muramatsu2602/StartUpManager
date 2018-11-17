using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupManager
{
    class Projeto
    {
        private String ultimaAlteracao;
        private Int64 idProjeto;
        private String nome;
        private String dataCriacao;
        private String dataExcluido;
        private Int64 id_ceo;
        private String descricao;

        public string UltimaAlteracao
        {
            get
            {
                DateTime dt = DateTime.Parse(ultimaAlteracao);
                return dt.ToString("dd/MM/yyyy");
            }
            set => ultimaAlteracao = value;
        }
        public Int64 IdProjeto { get => idProjeto; set => idProjeto = value; }
        public string Nome { get => nome; set => nome = value; }
        public string DataCriacao
        {
            get
            {
                DateTime dt = DateTime.Parse(dataCriacao);
                return dt.ToString("dd/MM/yyyy");
            }
            set => dataCriacao = value;
        }
        public string DataExcluido
        {
            get
            {
                DateTime dt = DateTime.Parse(dataExcluido);
                return dt.ToString("dd/MM/yyyy");
            }
            set => dataExcluido = value;
        }
        public Int64 Id_ceo { get => id_ceo; set => id_ceo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
    }
}
