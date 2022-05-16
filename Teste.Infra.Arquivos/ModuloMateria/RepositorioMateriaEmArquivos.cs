using Testes.Dominio.ModuloMateria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Testes.Infra.Arquivos.ModuloMateria
{
    public class RepositorioMateriaEmArquivos : RepositorioEmArquivoBase<Materia>, IRepositorioMateria
    {
        public RepositorioMateriaEmArquivos(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Materias.Count > 0)
                contador = dataContext.Materias.Max(x => x.Numero);
        }

        public override List<Materia> ObterRegistros()
        {
            return dataContext.Materias;
        }

        public override AbstractValidator<Materia> ObterValidador()
        {
            return new ValidadorMateria();
        }
    }
}
