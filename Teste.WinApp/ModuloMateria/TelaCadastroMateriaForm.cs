using Testes.Dominio.Compartilhado;
using Testes.Dominio.ModuloMateria;
using FluentValidation.Results;
using System;
using System.Windows.Forms;

namespace Testes.WinApp.ModuloMateria
{
    public partial class TelaCadastroMateriaForm : Form
    {
        public TelaCadastroMateriaForm()
        {
            InitializeComponent();
            CarregarDisciplinas();
        }

        private Materia materia;

        public Func<Materia, ValidationResult> GravarRegistro { get; set; }

        public Materia Materia
        {
            get
            {
                return materia;
            }
            set
            {
                materia = value;

                txtNumero.Text = materia.Numero.ToString();
                txtNome.Text = materia.Nome;
                comboBoxDisciplina.SelectedItem = materia.Disciplina;
                comboBoxSerie.SelectedItem = materia.Serie;
            }
        }
        private void CarregarDisciplinas()
        {
            var disciplinas = Enum.GetValues(typeof(DisciplinaEnum));

            foreach (var item in disciplinas)
            {
                comboBoxDisciplina.Items.Add(item);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            materia.Nome = txtNome.Text;
            materia.Disciplina = (DisciplinaEnum)comboBoxDisciplina.SelectedItem;
            materia.Serie = comboBoxSerie.SelectedItem.ToString();

            ValidationResult resultadoValidacao = GravarRegistro(materia);

            if (resultadoValidacao.IsValid == false)
            {
                string primeiroErro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
