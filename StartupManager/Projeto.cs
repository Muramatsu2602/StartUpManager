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
        private int idCanvas;
        private int idProjeto;
        private String nome;
        private String dataCriacao;
        private String dataExcluido;
        private int id_ceo;
        private String descricao;

        public string UltimaAlteracao { get => ultimaAlteracao; set => ultimaAlteracao = value; }
        public int IdCanvas { get => idCanvas; set => idCanvas = value; }
        public int IdProjeto { get => idProjeto; set => idProjeto = value; }
        public string Nome { get => nome; set => nome = value; }
        public string DataCriacao { get => dataCriacao; set => dataCriacao = value; }
        public string DataExcluido { get => dataExcluido; set => dataExcluido = value; }
        public int Id_ceo { get => id_ceo; set => id_ceo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
    }
}
