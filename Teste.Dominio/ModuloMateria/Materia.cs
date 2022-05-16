using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.Dominio.Compartilhado;

namespace Testes.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public Materia()
        {

        }

        public Materia(string nome, DisciplinaEnum disciplina, string serie)
        {
            Nome = nome;
            Disciplina = disciplina;
            Serie = serie;
        }


        public string Nome { get; set; }
        public DisciplinaEnum Disciplina { get; set; }

        public string Serie { get; set; }

        public override void Atualizar(Materia registro)
        {
        }

        public override string ToString()
        {
            return $"Número: {Numero}, Nome: {Nome}, Disciplina: {Disciplina}, Série: {Serie}";
        }
    }
}
