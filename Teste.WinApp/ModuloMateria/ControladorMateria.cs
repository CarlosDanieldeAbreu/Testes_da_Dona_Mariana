using Testes.Dominio.ModuloMateria;
using Testes.WinApp.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Testes.WinApp.ModuloMateria
{
  

    internal class ControladorMateria : ControladorBase
    {
        private readonly IRepositorioMateria repositorioMateria;
        private TabelaMateriaControl tabelaMateria;
        public ControladorMateria(IRepositorioMateria repositorioMateria)
        {
            this.repositorioMateria = repositorioMateria;
        }

        public override void Inserir()
        {
            TelaCadastroMateriaForm tela = new TelaCadastroMateriaForm();
            tela.Materia = new Materia();

            tela.GravarRegistro = repositorioMateria.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarMateria();
            }
        }

        public override void Editar()
        {
            Materia materiaSelecionado = ObtemMateriaSelecionado();

            if (materiaSelecionado == null)
            {
                MessageBox.Show("Selecione uma matéria primeiro",
                "Edição de Matéria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroMateriaForm tela = new TelaCadastroMateriaForm();

            tela.Materia = materiaSelecionado;

            tela.GravarRegistro = repositorioMateria.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarMateria();
            }
        }

        public override void Excluir()
        {
            Materia materiaSelecionada = ObtemMateriaSelecionado();

            if (materiaSelecionada == null)
            {
                MessageBox.Show("Selecione uma matéria primeiro",
                "Exclusão de Matérias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a matéria?",
                "Exclusão de Matéria", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioMateria.Excluir(materiaSelecionada);
                CarregarMateria();
            }
        }

        public override UserControl ObtemListagem()
        {
            //if (tabelaContatos == null)
            tabelaMateria = new TabelaMateriaControl();

            CarregarMateria();

            return tabelaMateria;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxMateria();
        }

        private Materia ObtemMateriaSelecionado()
        {
            var numero = tabelaMateria.ObtemNumeroMateriaSelecionada();

            return repositorioMateria.SelecionarPorNumero(numero);
        }

        private void CarregarMateria()
        {
            List<Materia> materia = repositorioMateria.SelecionarTodos();

            tabelaMateria.AtualizarRegistros(materia);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {materia.Count} matéria(s)");
        }
    }
}
