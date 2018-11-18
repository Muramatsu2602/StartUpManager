using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupManager
{
    class Canvas
    {
        private int idCanvas;
        private String propostaDeValor;
        private String relacionamento;
        private String canais;
        private String segmentoChave;
        private String parceriasChave;
        private String recursosChave;
        private String estruturaDados;
        private String fonteReceita;
        private String ultimaAlteracao;

        public int IdCanvas { get => idCanvas; set => idCanvas = value; }
        public string PropostaDeValor { get => propostaDeValor; set => propostaDeValor = value; }
        public string Relacionamento { get => relacionamento; set => relacionamento = value; }
        public string Canais { get => canais; set => canais = value; }
        public string SegmentoChave { get => segmentoChave; set => segmentoChave = value; }
        public string ParceriasChave { get => parceriasChave; set => parceriasChave = value; }
        public string RecursosChave { get => recursosChave; set => recursosChave = value; }
        public string EstruturaDados { get => estruturaDados; set => estruturaDados = value; }
        public string FonteReceita { get => fonteReceita; set => fonteReceita = value; }
        public string Atividade_chave { get; set; }
        public string UltimaAlteracao { get => ultimaAlteracao; set => ultimaAlteracao = value; }

    }
}
