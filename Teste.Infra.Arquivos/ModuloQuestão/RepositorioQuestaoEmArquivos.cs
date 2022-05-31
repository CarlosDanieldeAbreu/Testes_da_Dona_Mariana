using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.Dominio.ModuloQuestão;

namespace Testes.Infra.Arquivos.ModuloQuestão
{
    public class RepositorioQuestaoEmArquivos : RepositorioEmArquivoBase<Questao>, IRepositorioQuestao
    {
        public RepositorioQuestaoEmArquivos(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Questoes.Count > 0)
                contador = dataContext.Questoes.Max(x => x.Numero);
        }

        public override List<Questao> ObterRegistros()
        {
            return dataContext.Questoes;
        }

        public override AbstractValidator<Questao> ObterValidador()
        {
            return new ValidadorQuestao();
        }

        public void AdicionarItens(Questao questaoSelecionada, List<AlternativaQuestao> itens)
        {
            foreach (var item in itens)
            {
                questaoSelecionada.AdicionarAlternativa(item);
            }
        }
    }
}
