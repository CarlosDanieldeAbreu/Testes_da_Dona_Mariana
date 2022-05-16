using Testes.Dominio.ModuloMateria;
using Testes.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Testes.WinApp.ModuloMateria
{
    public partial class TabelaMateriaControl : UserControl
    {
        public TabelaMateriaControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Descrição", HeaderText = "Descrição"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Série", HeaderText = "Série"},
           };

            return colunas;
        }

        public void AtualizarRegistros(List<Materia> materias)
        {
            grid.Rows.Clear();

            foreach (Materia materia in materias)
            {
                grid.Rows.Add(materia.Numero, materia.Nome, materia.Disciplina, materia.Serie);
            }
        }

        public int ObtemNumeroMateriaSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
