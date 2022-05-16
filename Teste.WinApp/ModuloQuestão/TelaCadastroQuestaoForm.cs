using System;
using Testes.Dominio.Compartilhado;
using Testes.Dominio.ModuloMateria;
using Testes.Dominio.ModuloQuestão;
using Testes.Infra.Arquivos;
using Testes.Infra.Arquivos.ModuloMateria;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FluentValidation.Results;

namespace Testes.WinApp.ModuloQuestão
{
    public partial class TelaCadastroQuestaoForm : Form
    {
        private Questao questao;
        private List<Materia> materia;

        public TelaCadastroQuestaoForm(List<Materia> materia)
        {
            InitializeComponent();
            CarregarDisciplinas();
            this.materia = materia;
            questao = new Questao();
        }

        public Func<Questao, ValidationResult> GravarRegistro { get; set; }

        public Questao Questao
        {
            get 
            { 
                return questao; 
            }
            set
            {
                questao = value;

                txtNumero.Text = questao.Numero.ToString();
                comboBoxDisciplina.SelectedItem = questao.Disciplina;
                comboBoxMateria.SelectedItem = questao.Materia;
                textBoxPergunta.Text = questao.Pergunta;
                txtResposta.Text = questao.Resposta;
                CarregarLixBoxAlternativas();

            }
        }

        public void CarregarLixBoxAlternativas()
        {
            foreach (AlternativaQuestao alternativa in questao.Alternativas)
            {
                listItensRespostas.Items.Add(alternativa);
            }
        }
        private void CarregarDisciplinas()
        {
            comboBoxDisciplina.Items.Clear();
            var disciplinas = Enum.GetValues(typeof(DisciplinaEnum));

            foreach (var item in disciplinas)
            {
                comboBoxDisciplina.Items.Add(item);
            }
        }

        public List<AlternativaQuestao> AlternativasAdicionadas
        {
            get
            {
                return listItensRespostas.Items.Cast<AlternativaQuestao>().ToList();
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            questao.Materia = (Materia)comboBoxMateria.SelectedItem;
            questao.Disciplina = (DisciplinaEnum)comboBoxDisciplina.SelectedItem;
            questao.Pergunta = textBoxPergunta.Text;
            questao.Resposta = txtResposta.Text;

            ValidationResult resultadoValidacao = GravarRegistro(questao);

            if (resultadoValidacao.IsValid == false)
            {
                string primeiroErro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            List<string> alternativas = AlternativasAdicionadas.Select(x => x.Alternativa).ToList();

            if (alternativas.Count == 0 || alternativas.Contains(txtResposta.Text) == false)
            {
                AlternativaQuestao alternativaQuestao = new AlternativaQuestao();

                alternativaQuestao.Alternativa = txtResposta.Text;

                listItensRespostas.Items.Add(alternativaQuestao);
                questao.Alternativas.Add(alternativaQuestao);
            }
            txtResposta.Clear();
        }

        private void TelaCadastroQuestaosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroQuestoesForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void comboBoxDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManipularComboBoxMateria();
        }

        private void ManipularComboBoxMateria()
        {
            DisciplinaEnum disciplinaSelecionada = (DisciplinaEnum)comboBoxDisciplina.SelectedItem;
            List<Materia> materiasFiltradasPorDisciplina = materia.FindAll(x => x.Disciplina == disciplinaSelecionada);
            comboBoxMateria.Items.Clear();
            foreach(var item in materiasFiltradasPorDisciplina)
                comboBoxMateria.Items.Add(item);
        }
    }
}
