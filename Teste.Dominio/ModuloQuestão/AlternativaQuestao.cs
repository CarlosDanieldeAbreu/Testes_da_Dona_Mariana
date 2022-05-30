using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.Dominio.Compartilhado;

namespace Testes.Dominio.ModuloQuestão
{
    [Serializable]
    public class AlternativaQuestao : EntidadeBase<AlternativaQuestao>
    {
        public string Alternativa { get; set; }
        public Questao Questao { get; set; }

        public override void Atualizar(AlternativaQuestao registro)
        {
        }

        public override string ToString()
        {
            return Alternativa;
        }
    }
}
