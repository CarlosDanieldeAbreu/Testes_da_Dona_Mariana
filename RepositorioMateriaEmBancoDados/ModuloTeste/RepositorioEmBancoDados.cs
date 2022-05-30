using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Testes.Dominio.Compartilhado;
using Testes.Dominio.ModuloTeste;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Testes.Infra.BancoDados.ModuloTeste
{
    public class RepositorioEmBancoDados : IRepositorioTeste
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
                    @QUESTAO_NUMERO
                );SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
            @"UPDATE [TBTeste]	
		        SET
                   [DISCIPLINA] = @DISCIPLINA
                  ,[PERGUNTA] = @PERGUNTA
                  ,[RESPOSTA] = @RESPOSTA
                  ,[MATERIA_NUMERO] = @MATERIA_NUMERO
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlExcluir =
            @"DELETE FROM [TBTeste]
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
                    [TBTeste] AS TBQ INNER JOIN 
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
                    [TBTeste] AS TBQ INNER JOIN 
		            [TBMateria] AS TBM ON
		            TBQ.[MATERIA_NUMERO] = TBM.[NUMERO]
		        WHERE
                    TBQ.[NUMERO] = @NUMERO";
        #endregion
        public ValidationResult Editar(Teste registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(Teste registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Inserir(Teste novoRegistro)
        {
            throw new NotImplementedException();
        }

        public Teste SelecionarPorNumero(int numero)
        {
            throw new NotImplementedException();
        }

        public List<Teste> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
