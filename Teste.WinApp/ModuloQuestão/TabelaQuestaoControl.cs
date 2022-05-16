using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Testes.Dominio.ModuloQuestão;
using Testes.WinApp.Compartilhado;

namespace Testes.WinApp.ModuloQuestão
{
    public partial class TabelaQuestaoControl : UserControl
    {
        public TabelaQuestaoControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina", HeaderText = "Disciplina"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Matéria", HeaderText = "Matéria"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Enunciado da questão", HeaderText = "Enunciado da questão"},
            };

            return colunas;
        }

        public void AtualizarRegistros(List<Questao> questoes)
        {
            grid.Rows.Clear();

            foreach (Questao questao in questoes)
            {
                grid.Rows.Add(questao.Numero, questao.Disciplina, questao.Materia.Nome, questao.Pergunta);
            }
        }

        public int ObtemNumeroQuestaoSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
