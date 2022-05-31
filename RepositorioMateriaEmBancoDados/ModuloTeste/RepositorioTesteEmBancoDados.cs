using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Testes.Dominio.Compartilhado;
using Testes.Dominio.ModuloTeste;
using System.Threading.Tasks;
using FluentValidation.Results;
using System.Data.SqlClient;
using Testes.Dominio.ModuloMateria;

namespace Testes.Infra.BancoDados.ModuloTeste
{
    public class RepositorioTesteEmBancoDados : IRepositorioTeste
    {
        private const string enderecoBanco =
              "Data Source=(LocalDB)\\MSSqlLocalDB;" +
              "Initial Catalog=geradorTesteDb;" +
              "Integrated Security=True;" +
              "Pooling=False";

        #region Sql Queries
        private const string sqlInserir =
            @"INSERT INTO [TBTeste] 
                (
                   [TITULO]
                  ,[QTDQUESTOES]
                  ,[TURMA]
                  ,[DISCIPLINA]
                  ,[MATERIA_NUMERO]
                )
	            VALUES
                (
                    @TITULO,
                    @QTDQUESTOES,
                    @TURMA,
                    @DISCIPLINA,
                    @MATERIA_NUMERO
                );SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
            @"UPDATE [TBTeste]	
		        SET
                   [TITULO] = @TITULO
                  ,[QTDQUESTOES] = @QTDQUESTOES
                  ,[TURMA] = @TURMA
                  ,[DISCIPLINA] = @DISCIPLINA
                  ,[MATERIA_NUMERO] = @MATERIA_NUMERO
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlExcluir =
            @"DELETE FROM [TBTeste]
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlSelecionarTodos =
            @"SELECT 
                     TBT.[TITULO]
                    ,TBT.[QTDQUESTOES]
                    ,TBT.[TURMA]
                    ,TBT.[DISCIPLINA]
                    ,TBT.[MATERIA_NUMERO]
	                ,TBM.[NOME]
               FROM 
                    [TBTeste] AS TBT INNER JOIN 
		            [TBMateria] AS TBM ON
		            TBT.[MATERIA_NUMERO] = TBM.[NUMERO]";

        private const string sqlSelecionarPorNumero =
            @"SELECT 
                     TBT.[TITULO]
                    ,TBT.[QTDQUESTOES]
                    ,TBT.[TURMA]
                    ,TBT.[DISCIPLINA]
                    ,TBT.[MATERIA_NUMERO]
	                ,TBM.[NOME]
               FROM 
                    [TBTeste] AS TBT INNER JOIN 
		            [TBMateria] AS TBM ON
		            TBT.[MATERIA_NUMERO] = TBM.[NUMERO]
		        WHERE
                    TBQ.[NUMERO] = @NUMERO";


        private void ConfigurarParametrosTeste(Teste teste, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", teste.Numero);
            comando.Parameters.AddWithValue("DISCIPLINA", teste.Disciplina);
            comando.Parameters.AddWithValue("TITULO", teste.Titulo);
            comando.Parameters.AddWithValue("QTDQUESTOES", teste.QtdQuestoes);
            comando.Parameters.AddWithValue("TURMA", teste.Turma);

            comando.Parameters.AddWithValue("MATERIA_NUMERO", teste.materia == null ? DBNull.Value : teste.materia.Numero);
        }

        

        private Teste ConverterParaTeste(SqlDataReader leitorCompromisso)
        {
            var numero = Convert.ToInt32(leitorCompromisso["NUMERO"]);
            var disciplina = Convert.ToInt32(leitorCompromisso["DISCIPLINA"]);
            var titulo = Convert.ToString(leitorCompromisso["TITULO"]);
            var qtdQuestoes = Convert.ToInt32(leitorCompromisso["QTDQUESTOES"]);
            var turma = Convert.ToString(leitorCompromisso["TURMA"]);

            Teste teste = new Teste();
            teste.Numero = numero;
            teste.Disciplina = (DisciplinaEnum)disciplina;
            teste.Titulo = titulo;
            teste.QtdQuestoes = qtdQuestoes;
            teste.Turma = turma;

            if (leitorCompromisso["MATERIA_NUMERO"] != DBNull.Value)
            {
                var numeroContato = Convert.ToInt32(leitorCompromisso["MATERIA_NUMERO"]);
                var serie = Convert.ToString(leitorCompromisso["SERIE"]);
                var nome = Convert.ToString(leitorCompromisso["NOME"]);

                teste.materia = new Materia
                {
                    Numero = numeroContato,
                    Nome = nome,
                    Serie = serie
                };
            }

            return teste;
        }
        #endregion
        public ValidationResult Editar(Teste registro)
        {
            var validador = new ValidadorTeste();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            ConfigurarParametrosTeste(registro, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Teste registro)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("NUMERO", registro.Numero);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Inserir(Teste novoRegistro)
        {
            var validador = new ValidadorTeste();

            var resultadoValidacao = validador.Validate(novoRegistro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosTeste(novoRegistro, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            novoRegistro.Numero = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public Teste SelecionarPorNumero(int numero)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();
            SqlDataReader leitorTeste = comandoSelecao.ExecuteReader();

            Teste teste = null;
            if (leitorTeste.Read())
                teste = ConverterParaTeste(leitorTeste);

            conexaoComBanco.Close();

            return teste;
        }

        public List<Teste> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorTeste = comandoSelecao.ExecuteReader();

            List<Teste> testes = new List<Teste>();

            while (leitorTeste.Read())
            {
                Teste teste = ConverterParaTeste(leitorTeste);

                testes.Add(teste);
            }

            conexaoComBanco.Close();

            return testes;
        }
    }
}
