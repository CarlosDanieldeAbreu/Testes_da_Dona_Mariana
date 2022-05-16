using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.Dominio.ModuloMateria;
using Testes.Dominio.Compartilhado;

namespace Testes.Dominio.ModuloQuestão
{
    public class Questao : EntidadeBase<Questao>
    {
        public Questao()
        {
            Alternativas = new List<AlternativaQuestao>();
        }

        public Questao(Materia materia, DisciplinaEnum disciplina, string pergunta, List<AlternativaQuestao> alternativa, string resposta)
        {
            Materia = materia;
            Disciplina = disciplina;
            Pergunta = pergunta;
            Alternativas = alternativa;
            Resposta = resposta;
        }

        public Materia Materia { get; set; }
        public DisciplinaEnum Disciplina { get; set; }
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public List<AlternativaQuestao> Alternativas { get; set; }

        public override void Atualizar(Questao registro)
        {

        }

        public override string ToString()
        {
            return $"Número: {Numero}, Matéria: {Materia.Nome}, Disciplina: {Disciplina}, Pergunta: {Pergunta}";
        }

        public void AdicionarItem(AlternativaQuestao item)
        {
            if (Alternativas.Exists(x => x.Equals(item)) == false)
                Alternativas.Add(item);
        }
    }
}
