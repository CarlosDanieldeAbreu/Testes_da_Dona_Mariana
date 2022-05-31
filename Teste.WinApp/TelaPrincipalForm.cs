using System;
using System.Collections.Generic;
using Testes.WinApp.Compartilhado;
using Testes.WinApp.ModuloMateria;
using Testes.Infra.Arquivos;
using Testes.Infra.BancoDados.ModuloMateria;
using Testes.Infra.BancoDados.ModuloQuestao;
using Testes.Infra.Arquivos.ModuloTeste;
using Testes.WinApp.ModuloQuestão;
using Testes.WinApp.ModuloTeste;
using Testes.Infra.Arquivos.ModuloQuestão;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Testes.Infra.BancoDados.ModuloTeste;

namespace Testes.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;
        private DataContext contextoDados;

        public TelaPrincipalForm(DataContext contextoDados)
        {
            InitializeComponent();

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;

            this.contextoDados = contextoDados;

            InicializarControladores();
        }
        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void materiaMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void ConfigurarTelaPrincipal(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            controlador = controladores[tipo];

            ConfigurarToolbox();

            ConfigurarListagem();
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            panelPrincipal.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelPrincipal.Controls.Add(listagemControl);
        }

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolStrip.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
            //btnFiltrar.Enabled = configuracao.FiltrarHabilitado;
            //btnAgrupar.Enabled = configuracao.AgruparHabilitado;
        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
            //btnFiltrar.ToolTipText = configuracao.TooltipFiltrar;
            //btnAgrupar.ToolTipText = configuracao.TooltipAgrupar;
        }

        private void testeMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void questaoMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void InicializarControladores()
        {
            var repositorioMateria = new RepositorioMateriaEmBancoDados();
            var repositorioQuestao = new RepositorioQuestaoEmBancoDados();
            var repositorioTeste = new RepositorioTesteEmBancoDados();

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Matéria", new ControladorMateria(repositorioMateria));
            controladores.Add("Questão", new ControladorQuestao(repositorioQuestao, repositorioMateria));
            controladores.Add("Teste", new ControladorTeste(repositorioTeste, repositorioMateria, repositorioQuestao));
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }
    }
}
