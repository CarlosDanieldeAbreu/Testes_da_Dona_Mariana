using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.Dominio.Compartilhado;
using Testes.Dominio.ModuloQuestão;
using Testes.Dominio.ModuloMateria;

namespace Testes.Infra.BancoDados.ModuloQuestao
{
    public class RepositorioQuestaoEmBancoDados : IRepositorioQuestao
    {
        private const string enderecoBanco =
              "Data Source=(LocalDB)\\MSSqlLocalDB;" +
              "Initial Catalog=geradorTesteDb;" +
              "Integrated Security=True;" +
              "Pooling=False";

        #region Sql Queries
        private const string sqlInserir =
            @"INSERT INTO [TBQuestao] 
                (
                   [DISCIPLINA]
                  ,[PERGUNTA]
                  ,[RESPOSTA]
                  ,[MATERIA_NUMERO]
	            )
	            VALUES
                (
                    @DISCIPLINA,
                    @PERGUNTA,
                    @RESPOSTA,
                    @MATERIA_NUMERO
                );SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
            @"UPDATE [TBQuestao]	
		        SET
                   [DISCIPLINA] = @DISCIPLINA
                  ,[PERGUNTA] = @PERGUNTA
                  ,[RESPOSTA] = @RESPOSTA
                  ,[MATERIA_NUMERO] = @MATERIA_NUMERO
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlExcluir =
            @"DELETE FROM [TBQuestao]
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlSelecionarTodos =
            @"SELECT 
                     TBQ.[NUMERO]
                    ,TBQ.[DISCIPLINA]
                    ,TBQ.[PERGUNTA]
                    ,TBQ.[RESPOSTA]
                    ,TBQ.[MATERIA_NUMERO]
	                ,TBM.[NOME]
               FROM 
                    [TBQuestao] AS TBQ INNER JOIN 
		            [TBMateria] AS TBM ON
		            TBQ.[MATERIA_NUMERO] = TBM.[NUMERO]";

        private const string sqlSelecionarPorNumero =
            @"SELECT 
                     TBQ.[NUMERO]
                    ,TBQ.[DISCIPLINA]
                    ,TBQ.[PERGUNTA]
                    ,TBQ.[RESPOSTA]
                    ,TBQ.[MATERIA_NUMERO]
	                ,TBM.[NOME]
               FROM 
                    [TBQuestao] AS TBQ INNER JOIN 
		            [TBMateria] AS TBM ON
		            TBQ.[MATERIA_NUMERO] = TBM.[NUMERO]
		        WHERE
                    TBQ.[NUMERO] = @NUMERO";

        private const string sqlSelecionarAlternativa =
            @"SELECT 
	            [NUMERO],
                [ALTERNATIVA],
                [QUESTAO_NUMERO]
              FROM 
	            [TBAlternativa]
              WHERE 
	            [QUESTAO_NUMERO] = @QUESTAO_NUMERO";

        private const string sqlInserirAlternativa =
            @"INSERT INTO [DBO].[TBAlternativa]
                (
                    [ALTERNATIVA],
                    [QUESTAO_NUMERO]
	            )
                 VALUES
                (
		            @ALTERNATIVA   
                    @QUESTAO_NUMERO
	            ); SELECT SCOPE_IDENTITY();";

        private const string sqlEditarAlternativaQuestao =
           @"UPDATE [TBAlternativa]	
		        SET
			        [ALTERNATIVA]
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlExcluirAlternativaQuestao =
            @"DELETE FROM [TBAlternativa]
		        WHERE
			        [QUESTAO_NUMERO] = @QUESTAO_NUMERO";
        #endregion

        public List<Questao> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorQuestao = comandoSelecao.ExecuteReader();

            List<Questao> questoes = new List<Questao>();

            while (leitorQuestao.Read())
            {
                Questao questao =  ConverterParaQuestao(leitorQuestao);

                questoes.Add(questao);
            }

            conexaoComBanco.Close();

            return questoes;
        }

        
        public ValidationResult Inserir(Questao novaQuestao)
        {
            var validador = new ValidadorQuestao();

            var resultadoValidacao = validador.Validate(novaQuestao);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosQuestao(novaQuestao, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            novaQuestao.Numero = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Editar(Questao questao)
        {
            var validador = new ValidadorQuestao();

            var resultadoValidacao = validador.Validate(questao);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            ConfigurarParametrosQuestao(questao, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Questao questao)
        {
            ExcluirAlternativasQuestao(questao);

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("NUMERO", questao.Numero);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        Questao IRepositorio<Questao>.SelecionarPorNumero(int numero)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();
            SqlDataReader leitorContato = comandoSelecao.ExecuteReader();

            Questao questao = null;
            if (leitorContato.Read())
                questao = ConverterParaQuestao(leitorContato);

            conexaoComBanco.Close();
            CarregarAlternativasQuestao(questao);

            return questao;
        }
        public void AdicionarAlternativas(Questao questaoSelecionada, List<AlternativaQuestao> alternativas)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            foreach (var item in alternativas)
            {
                bool alternativaAdicionada = questaoSelecionada.AdicionarAlternativa(item);

                if (alternativaAdicionada)
                {
                    SqlCommand comandoInsercao = new SqlCommand(sqlInserirAlternativa, conexaoComBanco);

                    ConfigurarParametrosAlternativaQuestao(item, comandoInsercao);
                    var id = comandoInsercao.ExecuteScalar();
                    item.Numero = Convert.ToInt32(id);
                }
            }

            conexaoComBanco.Close();

            Editar(questaoSelecionada);
        }

        #region Métodos Privados
        private void CarregarAlternativasQuestao(Questao questao)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarAlternativa, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("QUESTAO_NUMERO", questao.Numero);

            conexaoComBanco.Open();
            SqlDataReader leitorAlternativaQuestao = comandoSelecao.ExecuteReader();

            //List<ItemTarefa> itensTarefa = new List<ItemTarefa>();

            while (leitorAlternativaQuestao.Read())
            {
                AlternativaQuestao alternativaQuestao = ConverterParaAlternativaQuestao(leitorAlternativaQuestao);

                questao.AdicionarAlternativa(alternativaQuestao);
                //itensTarefa.Add(itemTarefa);
            }

            conexaoComBanco.Close();
        }
        private void ExcluirAlternativasQuestao(Questao questao)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluirAlternativaQuestao, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("QUESTAO_NUMERO", questao.Numero);

            conexaoComBanco.Open();
            comandoExclusao.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        private void ConfigurarParametrosAlternativaQuestao(AlternativaQuestao alternativaQuestao, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", alternativaQuestao.Numero);
            comando.Parameters.AddWithValue("ALTERNATIVA", alternativaQuestao.Alternativa);
            comando.Parameters.AddWithValue("QUESTAO_NUMERO", alternativaQuestao.Questao);
        }

        private AlternativaQuestao ConverterParaAlternativaQuestao(SqlDataReader leitorAlternativaQuestao)
        {
            var numero = Convert.ToInt32(leitorAlternativaQuestao["NUMERO"]);
            var alternativa = Convert.ToString(leitorAlternativaQuestao["ALTERNATIVA"]);

            var alternativaQuestao = new AlternativaQuestao
            {
                Numero = numero,
                Alternativa = alternativa,
            };

            return alternativaQuestao;
        }

        private static Questao ConverterParaQuestao(SqlDataReader leitorQuestao)
        {
            int numero = Convert.ToInt32(leitorQuestao["NUMERO"]);
            int disciplina = Convert.ToInt32(leitorQuestao["DISCIPLINA"]);
            string pergunta = Convert.ToString(leitorQuestao["PERGUNTA"]);
            string resposta = Convert.ToString(leitorQuestao["RESPOSTA"]);
            int materia = Convert.ToInt32(leitorQuestao["MATERIA_NUMERO"]);
            string nome = Convert.ToString(leitorQuestao["NOME"]);

            var questao = new Questao
            {
                Numero = numero,
                Disciplina = (DisciplinaEnum)disciplina,
                Pergunta = pergunta,
                Resposta = resposta,
                Materia = new Materia
                {
                    Nome = nome,
                    Numero = materia,
                }
            };

            return questao;
        }

        private static void ConfigurarParametrosQuestao(Questao novoQuestao, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", novoQuestao.Numero);
            comando.Parameters.AddWithValue("DISCIPLINA", novoQuestao.Disciplina);
            comando.Parameters.AddWithValue("PERGUNTA", novoQuestao.Pergunta);
            comando.Parameters.AddWithValue("RESPOSTA", novoQuestao.Resposta);
            comando.Parameters.AddWithValue("MATERIA_NUMERO", novoQuestao.Materia.Numero);
            comando.Parameters.AddWithValue("NOME", novoQuestao.Materia.Nome);
        }
        #endregion
    }
}
