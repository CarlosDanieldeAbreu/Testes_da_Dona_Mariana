using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.Dominio.Compartilhado;
using Testes.Dominio.ModuloMateria;
using Testes.Dominio.ModuloQuestão;

namespace Testes.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>
    {
        public string Titulo { get; set; }
        public int QtdQuestoes { get; set; }
        public string Turma { get; set; }
        public DisciplinaEnum Disciplina { get; set; }
        public Materia materia { get; set; }
        //public DateTime data { get; set; }

        public List<Questao> questaos;

        public override void Atualizar(Teste registro)
        {
            this.Titulo = registro.Titulo;
            //data = DateTime.Now;
        }
    }
}
