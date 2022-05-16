using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes.Dominio.ModuloQuestão
{
    public class ValidadorQuestao : AbstractValidator<Questao>
    {
        public ValidadorQuestao()
        {
        }
    }
}
