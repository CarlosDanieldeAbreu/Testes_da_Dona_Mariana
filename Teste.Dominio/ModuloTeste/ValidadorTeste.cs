using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Testes.Dominio.ModuloTeste
{
    public class ValidadorTeste : AbstractValidator<Teste>
    {
        public ValidadorTeste()
        { 
            RuleFor(x => x.Titulo).NotNull().NotEmpty();

            RuleFor(x => x.QtdQuestoes).NotNull().NotEmpty();

            RuleFor(x => x.Turma).NotNull().NotEmpty();

            RuleFor(x => x.Disciplina).NotNull().NotEmpty();

            RuleFor(x => x.materia).NotNull().NotEmpty();
        }
    }
}
