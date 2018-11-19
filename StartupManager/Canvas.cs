using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupManager
{
    class Canvas
    {
        private Int64 idCanvas;
        private String propostaDeValor;
        private String relacionamento;
        private String canais;
        private String segmentoChave;
        private String parceriasChave;
        private String recursosChave;
        private String estruturaDados;
        private String fonteReceita;
        private DateTime ultimaAlteracao;
        private Int64 idProjeto;

        public Int64 IdCanvas { get => idCanvas; set => idCanvas = value; }
        public string PropostaDeValor { get => propostaDeValor; set => propostaDeValor = value; }
        public string Relacionamento { get => relacionamento; set => relacionamento = value; }
        public string Canais { get => canais; set => canais = value; }
        public string SegmentoChave { get => segmentoChave; set => segmentoChave = value; }
        public string ParceriasChave { get => parceriasChave; set => parceriasChave = value; }
        public string RecursosChave { get => recursosChave; set => recursosChave = value; }
        public string EstruturaDados { get => estruturaDados; set => estruturaDados = value; }
        public string FonteReceita { get => fonteReceita; set => fonteReceita = value; }
        public string Atividade_chave { get; set; }
        public DateTime UltimaAlteracao { get => ultimaAlteracao; set => ultimaAlteracao = value; }
        public long IdProjeto { get => idProjeto; set => idProjeto = value; }
    }
}
