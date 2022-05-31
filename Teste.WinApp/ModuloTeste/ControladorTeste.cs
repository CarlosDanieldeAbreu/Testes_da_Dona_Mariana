using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Testes.Dominio.ModuloMateria;
using Testes.Dominio.ModuloQuestão;
using Testes.Dominio.ModuloTeste;
using Testes.Infra.Arquivos.ModuloMateria;
using Testes.Infra.Arquivos.ModuloQuestão;
using Testes.Infra.Arquivos.ModuloTeste;
using Testes.WinApp.Compartilhado;

namespace Testes.WinApp.ModuloTeste
{
    internal class ControladorTeste : ControladorBase
    {
        private IRepositorioQuestao repositorioQuestao;
        private IRepositorioMateria repositorioMateria;
        private IRepositorioTeste repositorioTeste;
        private TabelaTesteControl tabelaTestes;


        public ControladorTeste(IRepositorioTeste repositorioTeste, IRepositorioMateria repositorioMateria, IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioTeste = repositorioTeste;
            this.repositorioMateria = repositorioMateria;
            this.repositorioQuestao = repositorioQuestao;
        }

        public override void Inserir()
        {
            List<Materia> Materias = repositorioMateria.SelecionarTodos();
            TelaCadastroTesteForm tela = new TelaCadastroTesteForm(Materias);
            tela.Teste = new Teste();

            tela.GravarRegistro = repositorioTeste.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                List<Questao> questoesFiltradas = ObterListaQuestoesComFiltros(tela.Teste);

                if (questoesFiltradas == null || questoesFiltradas.Count == 0)
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape("Nenhuma questao encontrada");
                    return;
                }

                tela.Teste.questaos = ObterQuestoesRandomicas(questoesFiltradas, tela.Teste.QtdQuestoes);

                var resultadoValidacao = repositorioTeste.Inserir(tela.Teste);

                if (resultadoValidacao.IsValid == false)
                {
                    string erro = resultadoValidacao.Errors[0].ErrorMessage;

                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                }

                CarregarTeste();
            }

        }

        public override void Editar()
        {
            Teste TesteSelecionada = ObtemTesteSelecionada();

            if (TesteSelecionada == null)
            {
                MessageBox.Show("Selecione uma teste primeiro",
                "Edição de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<Materia> Materias = repositorioMateria.SelecionarTodos();
            TelaCadastroTesteForm tela = new TelaCadastroTesteForm(Materias);

            tela.Teste = TesteSelecionada;

            tela.GravarRegistro = repositorioTeste.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTeste();
            }
        }

        public override void Excluir()
        {
            Teste tarefaSelecionada = ObtemTesteSelecionada();

            if (tarefaSelecionada == null)
            {
                MessageBox.Show("Selecione uma Teste primeiro",
                "Exclusão de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a teste?",
                "Exclusão de Testes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTeste.Excluir(tarefaSelecionada);
                CarregarTeste();
            }
        }

        public override void Duplicar()
        {
            //
            Teste TesteSelecionada = ObtemTesteSelecionada();

            Teste novoTeste = new Teste();

            if (TesteSelecionada == null)
            {
                MessageBox.Show("Selecione uma teste primeiro",
                "Edição de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<Materia> Materias = repositorioMateria.SelecionarTodos();
            TelaCadastroTesteForm tela = new TelaCadastroTesteForm(Materias);

            tela.Teste = TesteSelecionada;

            tela.GravarRegistro = repositorioTeste.Inserir;
            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTeste();
            }
        }

        public override void GerarPDF()
        {

            Teste teste = ObtemTesteSelecionada();

            if (teste == null)
            {
                MessageBox.Show("Selecione um teste primeiro.",
                "Gerar PDF de teste", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pastaSelecioanda = saveFileDialog.FileName;

                    GeradorPDF geradorPdf = new GeradorPDF(pastaSelecioanda, teste);

                    geradorPdf.GerarPdf();
                }
            }
        }

        private void CarregarTeste()
        {
            List<Teste> Testes = repositorioTeste.SelecionarTodos();

            tabelaTestes.AtualizarRegistros(Testes);
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {Testes.Count}");
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaTestes == null)
                tabelaTestes = new TabelaTesteControl();

            CarregarTeste();

            return tabelaTestes;
        }

        private Teste ObtemTesteSelecionada()
        {
            int numero = (int)tabelaTestes.ObtemNumeroTesteSelecionado();

            return repositorioTeste.SelecionarPorNumero(numero);
        }

        private List<Questao> ObterListaQuestoesComFiltros(Teste Teste)
        {
            try
            {
                List<Questao> questaos = repositorioQuestao.SelecionarTodos();

                List<Questao> questaosPorDisciplina = questaos.FindAll(x => x.Materia.Disciplina == Teste.Disciplina);

                return questaosPorDisciplina;
            }
            catch (Exception e)
            {
                return new List<Questao>();
            }
        }

        private List<Questao> ObterQuestoesRandomicas(List<Questao> questoesFiltradas, int quantidadeQuestoes)
        {
            if (quantidadeQuestoes > questoesFiltradas.Count)
                quantidadeQuestoes = questoesFiltradas.Count;

            List<Questao> questaoRandomicas = new List<Questao>();

            Random numero = new Random();


            while (questaoRandomicas.Count != quantidadeQuestoes)
            {
                int ranNum = numero.Next(0, quantidadeQuestoes);

                if (!questaoRandomicas.Exists(x => x.Numero == questoesFiltradas[ranNum].Numero))
                    questaoRandomicas.Add(questoesFiltradas[ranNum]);
            }


            return questaoRandomicas;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
           return new ConfiguracaoToolboxTeste();
        }
    }
}
