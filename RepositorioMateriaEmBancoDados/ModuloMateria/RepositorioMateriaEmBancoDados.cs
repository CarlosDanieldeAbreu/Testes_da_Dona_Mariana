using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testes.Dominio.ModuloMateria;
using Testes.Dominio.Compartilhado;

namespace Testes.Infra.BancoDados.ModuloMateria
{
    public class RepositorioMateriaEmBancoDados : IRepositorioMateria
    {
        private const string enderecoBanco =
              "Data Source=(LocalDB)\\MSSqlLocalDB;" +
              "Initial Catalog=geradorTesteDb;" +
              "Integrated Security=True;" +
              "Pooling=False";

        #region Sql Queries
        private const string sqlInserir =
            @"INSERT INTO [TBMateria] 
                (
                    [NOME],
                    [SERIE],
                    [DISCIPLINA]
	            )
	            VALUES
                (
                    @NOME,
                    @SERIE,
                    @DISCIPLINA
                );SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
            @"UPDATE [TBMateria]	
		        SET
			        [NOME] = @NOME,
			        [SERIE] = @SERIE,
			        [DISCIPLINA] = @DISCIPLINA
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlExcluir =
            @"DELETE FROM [TBMateria]
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlSelecionarTodos =
            @"SELECT 
                    [NUMERO],
		            [NOME],
                    [SERIE],
                    [DISCIPLINA]
	            FROM 
		            [TBMateria]";

        private const string sqlSelecionarPorNumero =
            @"SELECT
                    [NUMERO],
		            [NOME],
                    [SERIE],
                    [DISCIPLINA]
	            FROM 
		            [TBMateria]
		        WHERE
                    [NUMERO] = @NUMERO";

        #endregion
        public ValidationResult Editar(Materia materia)
        {
            var validador = new ValidadorMateria();

            var resultadoValidacao = validador.Validate(materia);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            ConfigurarParametrosMateria(materia, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Materia materia)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("NUMERO", materia.Numero);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Inserir(Materia novaMateria)
        {
            var validador = new ValidadorMateria();

            var resultadoValidacao = validador.Validate(novaMateria);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosMateria(novaMateria, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            novaMateria.Numero = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public Materia SelecionarPorNumero(int numero)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();
            SqlDataReader leitorContato = comandoSelecao.ExecuteReader();

            Materia materia = null;
            if (leitorContato.Read())
                materia = ConverterParaMateria(leitorContato);

            conexaoComBanco.Close();

            return materia;
        }

        public List<Materia> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            List<Materia> materias = new List<Materia>();

            while (leitorMateria.Read())
            {
                Materia materia = ConverterParaMateria(leitorMateria);

                materias.Add(materia);
            }

            conexaoComBanco.Close();

            return materias;
        }

        private static Materia ConverterParaMateria(SqlDataReader leitorMateria)
        {
            int numero = Convert.ToInt32(leitorMateria["NUMERO"]);
            string nome = Convert.ToString(leitorMateria["NOME"]);
            string serie = Convert.ToString(leitorMateria["SERIE"]);
            int disciplina = Convert.ToInt32(leitorMateria["DISCIPLINA"]);

            var materia = new Materia
            {
                Numero = numero,
                Nome = nome,
                Serie = serie,
                Disciplina = (DisciplinaEnum)disciplina
            };

            return materia;
        }

        private static void ConfigurarParametrosMateria(Materia novoMateria, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", novoMateria.Numero);
            comando.Parameters.AddWithValue("NOME", novoMateria.Nome);
            comando.Parameters.AddWithValue("SERIE", novoMateria.Serie);
            comando.Parameters.AddWithValue("DISCIPLINA", novoMateria.Disciplina);
        }
    }
}
