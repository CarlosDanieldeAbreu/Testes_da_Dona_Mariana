using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.WinApp.Compartilhado;

namespace Testes.WinApp.ModuloQuestão
{
    public class ConfiguracaoToolboxQuestao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Questão";
        public override string TooltipInserir { get { return "Inserir uma nova questão"; } }

        public override string TooltipEditar { get { return "Editar uma nova questão"; } }

        public override string TooltipExcluir { get { return "Excluir uma nova questão"; } }
    }
}
