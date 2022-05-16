using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Testes.WinApp.Compartilhado;
using Testes.Dominio.ModuloQuestão;
using Testes.Dominio.ModuloMateria;

namespace Testes.WinApp.ModuloQuestão
{
    public class ControladorQuestao : ControladorBase
    {
        private IRepositorioQuestao repositorioQuestao;
        private IRepositorioMateria repositorioMateria;
        private TabelaQuestaoControl tabelaQuestao;

        public ControladorQuestao(IRepositorioQuestao repositorioQuestao, IRepositorioMateria repositorioMateria)
        {
            this.repositorioQuestao = repositorioQuestao;
            this.repositorioMateria = repositorioMateria;
        }
        public List<Materia> Materias
        {
            get { return repositorioMateria.SelecionarTodos(); }
        }


        public override void Editar()
        {
            Questao questaoSelecionada = ObtemQuestaoSelecionada();

            if (questaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma matéria questão",
                "Edição de Guestão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            TelaCadastroQuestaoForm tela = new TelaCadastroQuestaoForm(Materias);

            tela.Questao = questaoSelecionada;

            tela.GravarRegistro = repositorioQuestao.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarQuestao();
            }
        }

        private Questao ObtemQuestaoSelecionada()
        {
            var numero = tabelaQuestao.ObtemNumeroQuestaoSelecionada();

            return repositorioQuestao.SelecionarPorNumero(numero);
        }

        public override void Excluir()
        {
            Questao questaoSelecionada = ObtemQuestaoSelecionada();

            if (questaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma questão primeiro",
                "Exclusão de Questões", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a questão?",
                "Exclusão de Questões", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioQuestao.Excluir(questaoSelecionada);
                CarregarQuestao();
            }
        }

        public override void Inserir()
        {
            TelaCadastroQuestaoForm tela = new TelaCadastroQuestaoForm(Materias);
            tela.Questao = new Questao();

            tela.GravarRegistro = repositorioQuestao.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarQuestao();
            }
        }

        private void CarregarQuestao()
        {
            List<Questao> questao = repositorioQuestao.SelecionarTodos();

            tabelaQuestao.AtualizarRegistros(questao);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {questao.Count} quest( ão/ões)");
        }


        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxQuestao();
        }

        public override UserControl ObtemListagem()
        {
            tabelaQuestao = new TabelaQuestaoControl();

            CarregarQuestao();

            return tabelaQuestao;
        }
    }
}
