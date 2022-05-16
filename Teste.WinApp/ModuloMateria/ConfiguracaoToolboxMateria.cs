using Testes.WinApp.Compartilhado;

namespace Testes.WinApp.ModuloMateria
{
    public class ConfiguracaoToolboxMateria : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Matérias";

        public override string TooltipInserir { get { return "Inserir uma nova matéria"; } }

        public override string TooltipEditar { get { return "Editar uma nova matéria"; } }

        public override string TooltipExcluir { get { return "Excluir uma nova matéria"; } }
    }
}
