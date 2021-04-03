using FitRelatorio.Auxiliar;
using FitRelatorio.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FitRelatorio.DAL
{
    public class AlunoDAL
    {
        public bool SalvarAluno(Aluno aluno, bool edit)
        {
            bool retorno = false;
            try
            {
                using (TransactionScope escopo = new TransactionScope())
                {
                    string sqlSalvarAluno;
                    Conexao.LimparParametros();
                    if (!edit)
                    {
                        sqlSalvarAluno = "INSERT INTO aluno (nome,cpf,dataNascimento,sexo) " +
                         "VALUES (@nome,@cpf,@dataNascimento,@sexo)";
                    }
                    else
                    {
                        sqlSalvarAluno = "UPDATE aluno SET nome = @nome, cpf = @cpf, dataNascimento = @dataNascimento, sexo = @sexo " +
                            "WHERE codAluno == @codAluno";
                        Conexao.AdicionarParametros("@codAluno", aluno.CodAluno);
                    }   
                    
                    Conexao.AdicionarParametros("@nome", aluno.Nome);
                    Conexao.AdicionarParametros("@cpf", aluno.Cpf);
                    Conexao.AdicionarParametros("@dataNascimento", aluno.DataNascimento);
                    Conexao.AdicionarParametros("@sexo", aluno.Sexo);

                    Conexao.ExecutarManipulacao(CommandType.Text, sqlSalvarAluno);                    
                    retorno = true;

                    escopo.Complete();
                }

            }
            catch (TransactionAbortedException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            return retorno;
        }

        //Listar todos
        public IEnumerable<Aluno> ListarAlunos(bool isSeletivo)
        {
            string sqlListarAluno;
            List<Aluno> listaAlunos = new List<Aluno>();

            try
            {                
                Conexao.LimparParametros();
                if (isSeletivo)
                {
                    sqlListarAluno = "WITH Avaliac AS " +
                   "(SELECT COUNT(*) AS ava_count,codAluno " +
                   "FROM avaliacao " +
                   "GROUP BY codAluno " +
                   "HAVING COUNT(*) >1) " +
                   "SELECT Avaliac.codAluno, Al.codAluno, Al.cpf, Al.nome, Al.dataNascimento, Al.sexo " +
                   "FROM Avaliac " +
                   "JOIN aluno AS Al ON Avaliac.codAluno = Al.codAluno " +
                   "ORDER BY Al.nome";
                }
                else
                {
                    sqlListarAluno = "SELECT codAluno, cpf, nome, dataNascimento, sexo FROM aluno ORDER BY nome";
                } 

                DataTable dataTable = Conexao.ExecutarConsulta(CommandType.Text, sqlListarAluno);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Aluno al = new Aluno
                    {
                        CodAluno = Convert.ToInt64(dataRow["codAluno"]),
                        Cpf = Convert.ToString(dataRow["cpf"]),
                        Nome = Convert.ToString(dataRow["nome"]),
                        DataNascimento = Convert.ToDateTime(dataRow["dataNascimento"]),
                        Sexo = Convert.ToString(dataRow["sexo"])
                    };

                    listaAlunos.Add(al);
                }

                return listaAlunos;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Aluno> FiltrarPorParametro(string campoFiltro, string valorFiltro)
        {
            string sqlListarAluno;
            List<Aluno> listaAlunos = new List<Aluno>();

            try
            {
                Conexao.LimparParametros();

                if (campoFiltro.Equals("rcq"))
                {
                    sqlListarAluno = "WITH UltimaAvaliacao AS " +
                     "(SELECT avaliacao.codAluno AS codAluno, " +
                     "avaliacao.grauRisco, " +
                     "MAX(avaliacao.data) " +
                     "FROM avaliacao " +
                     "GROUP BY codAluno) " +
                     "SELECT Al.codAluno, Al.cpf, Al.nome, Al.dataNascimento, Al.sexo " +
                     "FROM UltimaAvaliacao AS Aval " +
                     "JOIN aluno AS Al ON Aval.codAluno = Al.codAluno " +
                     "WHERE Aval.grauRisco == @grauRisco " +
                     "ORDER BY Al.codAluno";
                    Conexao.AdicionarParametros("@grauRisco", valorFiltro);
                }
                else
                {
                    sqlListarAluno = "WITH UltimaAvaliacao AS " +
                     "(SELECT avaliacao.codAluno AS codAluno, " +
                     "avaliacao.classificacaoGorduraCorporal, " +
                     "MAX(avaliacao.data) " +
                     "FROM avaliacao " +
                     "GROUP BY codAluno) " +
                     "SELECT Al.codAluno, Al.cpf, Al.nome, Al.dataNascimento, Al.sexo " +
                     "FROM UltimaAvaliacao AS Aval " +
                     "JOIN aluno AS Al ON Aval.codAluno = Al.codAluno " +
                     "WHERE Aval.classificacaoGorduraCorporal == @classificacaoGorduraCorporal " +
                     "ORDER BY Al.codAluno";
                    Conexao.AdicionarParametros("@classificacaoGorduraCorporal", valorFiltro);
                }

                DataTable dataTable = Conexao.ExecutarConsulta(CommandType.Text, sqlListarAluno);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Aluno al = new Aluno
                    {
                        CodAluno = Convert.ToInt64(dataRow["codAluno"]),
                        Cpf = Convert.ToString(dataRow["cpf"]),
                        Nome = Convert.ToString(dataRow["nome"]),
                        DataNascimento = Convert.ToDateTime(dataRow["dataNascimento"]),
                        Sexo = Convert.ToString(dataRow["sexo"])
                    };

                    listaAlunos.Add(al);
                }

                return listaAlunos;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Aluno BuscarAluno(string cpfOuId, bool isSeletivo)
        {
            try
            {
                Aluno aluno = new Aluno();

                string sqlBuscaAluno;
                Conexao.LimparParametros();
                string cpf = Validations.RemoverMascaraCpf(cpfOuId);
                if (cpf.All(char.IsDigit) && cpf.Length == 11)
                {
                    Conexao.AdicionarParametros("@cpf", cpfOuId);
                    if (isSeletivo)
                    {
                        sqlBuscaAluno = "WITH Avaliac AS " +
                        "(SELECT COUNT(*) AS ava_count,codAluno " +
                        "FROM avaliacao " +
                        "GROUP BY codAluno " +
                        "HAVING COUNT(*) >1) " +
                        "SELECT Avaliac.codAluno, Al.codAluno, Al.cpf, Al.nome, Al.dataNascimento, Al.sexo " +
                        "FROM Avaliac " +
                        "JOIN aluno AS Al ON Avaliac.codAluno = Al.codAluno AND Al.cpf == @cpf";
                    }
                    else
                    {
                        sqlBuscaAluno = "SELECT codAluno, cpf, nome, dataNascimento, sexo FROM aluno WHERE cpf == @cpf";
                    } 
                   
                }
                else
                {
                    long id = long.Parse(cpfOuId);
                    Conexao.AdicionarParametros("@cod", id);

                    if (isSeletivo)
                    {
                        sqlBuscaAluno = "WITH Avaliac AS " +
                        "(SELECT COUNT(*) AS ava_count,codAluno " +
                        "FROM avaliacao " +
                        "GROUP BY codAluno " +
                        "HAVING COUNT(*) >1) " +
                        "SELECT Avaliac.codAluno, Al.codAluno, Al.cpf, Al.nome, Al.dataNascimento, Al.sexo " +
                        "FROM Avaliac " +
                        "JOIN aluno AS Al ON Avaliac.codAluno = Al.codAluno AND Al.codAluno == @cod";
                    }
                    else
                    {
                        sqlBuscaAluno = "SELECT codAluno, cpf, nome, dataNascimento, sexo FROM aluno WHERE codAluno == @cod";
                    }

                }   

                using (IDataReader leitor = Conexao.BuscarRegistro(CommandType.Text, sqlBuscaAluno))
                {
                    while (leitor.Read())
                    {
                        aluno.CodAluno = Convert.ToInt64(leitor["codAluno"]);
                        aluno.Nome = Convert.ToString(leitor["nome"]);
                        aluno.Cpf = Convert.ToString(leitor["cpf"]);
                        aluno.DataNascimento = Convert.ToDateTime(leitor["dataNascimento"]);
                        aluno.Sexo = Convert.ToString(leitor["sexo"]);
                    }

                    return aluno;
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Aluno> BuscarAlunoPorNome(string nome, bool isSeletivo)
        {
            List<Aluno> listaAlunos = new List<Aluno>();
            try
            {
                string sqlBuscaAluno;
                Conexao.LimparParametros();
                Conexao.AdicionarParametros("@nome", nome.ToUpper() + "%");

                if (isSeletivo)
                {
                    sqlBuscaAluno = "WITH Avaliac AS " +
                    "(SELECT COUNT(*) AS ava_count,codAluno " +
                    "FROM avaliacao " +
                    "GROUP BY codAluno " +
                    "HAVING COUNT(*) >1) " +
                    "SELECT Avaliac.codAluno, Al.codAluno, Al.cpf, Al.nome, Al.dataNascimento, Al.sexo " +
                    "FROM Avaliac " +
                    "JOIN aluno AS Al ON Avaliac.codAluno = Al.codAluno AND Al.nome LIKE @nome";
                }
                else
                {
                    sqlBuscaAluno = "SELECT codAluno, cpf, nome, dataNascimento, sexo FROM aluno WHERE nome LIKE @nome";
                }                

                DataTable dataTable = Conexao.ExecutarConsulta(CommandType.Text, sqlBuscaAluno);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Aluno al = new Aluno
                    {
                        CodAluno = Convert.ToInt64(dataRow["codAluno"]),
                        Cpf = Convert.ToString(dataRow["cpf"]),
                        Nome = Convert.ToString(dataRow["nome"]),
                        DataNascimento = Convert.ToDateTime(dataRow["dataNascimento"]),
                        Sexo = Convert.ToString(dataRow["sexo"])
                    };

                    listaAlunos.Add(al);
                }

                return listaAlunos;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ContarPorSexo()
        {
            try
            {
                string sqlContarSexo = "SELECT CASE sexo WHEN 'F' THEN 'Feminino' ELSE 'Masculino' END Sexo FROM aluno";

                return Conexao.ExecutarConsulta(CommandType.Text, sqlContarSexo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ContarPorFaixaEtaria()
        {
            try
            {
                string sql = "WITH AgeData as " +
                                        "(SELECT dataNascimento, " +
                                        "(strftime('%Y', 'now') - strftime('%Y', dataNascimento)) - (strftime('%m-%d', 'now') " +
                                        "< strftime('%m-%d', dataNascimento)) AS IDADE FROM aluno), " +
                                        "GroupAge AS (" +
                                        "SELECT CASE " +
                                        "WHEN IDADE <= 29 THEN '-29' " +
                                        "WHEN IDADE BETWEEN 30 AND 39 THEN '30 - 39' " +
                                        "WHEN IDADE BETWEEN 40 AND 49 THEN '40 - 49' " +
                                        "WHEN IDADE BETWEEN 50 AND 59 THEN '50 - 59' " +
                                        "WHEN IDADE > 59 THEN 'acima de 59' " +
                                        "END AS AgeGroups " +
                                        "FROM AgeData) " +
                                        "SELECT AgeGroups AS Grupo FROM GroupAge";

                return Conexao.ExecutarConsulta(CommandType.Text, sql);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
