using Testes.WinApp.Compartilhado;

namespace Testes.WinApp.ModuloTeste
{
    public class ConfiguracaoToolboxTeste : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Testes";

        public override string TooltipInserir { get { return "Inserir uma nova teste"; } }

        public override string TooltipEditar { get { return "Editar uma nova teste"; } }

        public override string TooltipExcluir { get { return "Excluir uma nova teste"; } }
    }
}
