using FitRelatorio.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace FitRelatorio.DAL
{
    public class AvaliacaoDAL
    {
        public bool SalvarAvaliacao(Avaliacao avaliacao, bool edit)
        {
            bool retorno = false;
            try
            {
                using (TransactionScope escopo = new TransactionScope())
                {
                    string sqlSalvarAvaliacao;
                    Conexao.LimparParametros();
                    if (!edit)
                    {
                        sqlSalvarAvaliacao = "INSERT INTO avaliacao (codAluno," +
                            "data," +
                            "peso," +
                            "altura," +
                            "imc," +
                            "gorduraCorporal," +
                            "massaMuscEsqueletica," +
                            "metabolismoBasal," +
                            "idadeCorporal," +
                            "gorduraVisceral," +
                            "cintura," +
                            "quadril," +
                            "rcq," +
                            "grauRisco," +
                            "idade," +
                            "classificacaoGorduraCorporal) " +
                         "VALUES (@codAluno," +
                         "@data," +
                         "@peso," +
                         "@altura," +
                         "@imc," +
                         "@gorduraCorporal," +
                         "@massaMuscEsqueletica," +
                         "@metabolismoBasal," +
                         "@idadeCorporal," +
                         "@gorduraVisceral," +
                         "@cintura," +
                         "@quadril," +
                         "@rcq," +
                         "@grauRisco," +
                         "@idade," +
                         "@classificacaoGorduraCorporal)";
                    }
                    else
                    {
                        sqlSalvarAvaliacao = "UPDATE avaliacao SET " +
                            "codAluno = @codAluno, " +
                            "data = @data, " +
                            "peso = @peso, " +
                            "altura = @altura, " +
                            "imc = @imc, " +
                            "gorduraCorporal = @gorduraCorporal, " +
                            "massaMuscEsqueletica = @massaMuscEsqueletica, " +
                            "metabolismoBasal = @metabolismoBasal, " +
                            "idadeCorporal = @idadeCorporal, " +
                            "gorduraVisceral = @gorduraVisceral, " +
                            "cintura = @cintura, " +
                            "quadril = @quadril, " +
                            "rcq = @rcq, " +
                            "grauRisco = @grauRisco, " +
                            "idade = @idade, " +
                            "classificacaoGorduraCorporal = @classificacaoGorduraCorporal " +
                            "WHERE codAvaliacao == @codAvaliacao";
                        Conexao.AdicionarParametros("@codAvaliacao", avaliacao.CodAvaliacao);
                    }

                    Conexao.AdicionarParametros("@codAluno", avaliacao.CodAluno);
                    Conexao.AdicionarParametros("@data", avaliacao.Data);
                    Conexao.AdicionarParametros("@peso", avaliacao.Peso);
                    Conexao.AdicionarParametros("@altura", avaliacao.Altura);
                    Conexao.AdicionarParametros("@imc", avaliacao.Imc);
                    Conexao.AdicionarParametros("@gorduraCorporal", avaliacao.GorduraCorporal);
                    Conexao.AdicionarParametros("@massaMuscEsqueletica", avaliacao.MassaMuscEsqueletica);
                    Conexao.AdicionarParametros("@metabolismoBasal", avaliacao.MetabolismoBasal);
                    Conexao.AdicionarParametros("@idadeCorporal", avaliacao.IdadeCorporal);
                    Conexao.AdicionarParametros("@gorduraVisceral", avaliacao.GorduraVisceral);
                    Conexao.AdicionarParametros("@cintura", avaliacao.Cintura);
                    Conexao.AdicionarParametros("@quadril", avaliacao.Quadril);
                    Conexao.AdicionarParametros("@rcq", avaliacao.Rcq);
                    Conexao.AdicionarParametros("@grauRisco", avaliacao.GrauRisco);
                    Conexao.AdicionarParametros("@idade", avaliacao.Idade);
                    Conexao.AdicionarParametros("@classificacaoGorduraCorporal", avaliacao.ClassificacaoGorduraCorporal);

                    Conexao.ExecutarManipulacao(CommandType.Text, sqlSalvarAvaliacao);
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
        public IEnumerable<Avaliacao> ListarAvaliacoes(long codAluno)
        {
            List<Avaliacao> listaAvaliacoes = new List<Avaliacao>();
            try
            {
                Conexao.LimparParametros();
                Conexao.AdicionarParametros("@codAluno", codAluno);
                string sqlListarAvaliacao = "SELECT codAvaliacao," +
                    "codAluno," +
                    "data," +
                    "peso," +
                    "altura," +
                    "imc," +
                    "gorduraCorporal," +
                    "massaMuscEsqueletica," +
                    "metabolismoBasal," +
                    "idadeCorporal," +
                    "gorduraVisceral," +
                    "cintura," +
                    "quadril," +
                    "rcq," +
                    "grauRisco," +
                    "idade," +
                    "classificacaoGorduraCorporal" +
                    " FROM avaliacao WHERE codAluno == @codAluno ORDER BY data DESC";

                DataTable dataTable = Conexao.ExecutarConsulta(CommandType.Text, sqlListarAvaliacao);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Avaliacao av = new Avaliacao
                    {
                        CodAvaliacao = Convert.ToInt64(dataRow["codAvaliacao"]),
                        CodAluno = Convert.ToInt64(dataRow["codAluno"]),
                        Data = Convert.ToDateTime(dataRow["data"]),
                        Peso = Convert.ToDecimal(dataRow["peso"]),
                        Altura = Convert.ToDecimal(dataRow["altura"]),
                        Imc = Convert.ToDecimal(dataRow["imc"]),
                        GorduraCorporal = Convert.ToDecimal(dataRow["gorduraCorporal"]),
                        MassaMuscEsqueletica = Convert.ToDecimal(dataRow["massaMuscEsqueletica"]),
                        MetabolismoBasal = Convert.ToInt32(dataRow["metabolismoBasal"]),
                        IdadeCorporal = Convert.ToInt32(dataRow["idadeCorporal"]),
                        GorduraVisceral = Convert.ToInt32(dataRow["gorduraVisceral"]),
                        Cintura = Convert.ToDecimal(dataRow["cintura"]),
                        Quadril = Convert.ToDecimal(dataRow["quadril"]),
                        Rcq = Convert.ToDecimal(dataRow["rcq"]),
                        GrauRisco = Convert.ToString(dataRow["grauRisco"]),
                        Idade = Convert.ToInt32(dataRow["idade"]),
                        ClassificacaoGorduraCorporal = Convert.ToString(dataRow["classificacaoGorduraCorporal"])
                    };

                    listaAvaliacoes.Add(av);
                }

                return listaAvaliacoes;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ExcluirAvaliacao(long codAvaliacao)
        {
            bool sucesso;
            try
            {
                Conexao.LimparParametros();
                Conexao.AdicionarParametros("@codAvaliacao", codAvaliacao);
                string sql = "DELETE FROM avaliacao WHERE codAvaliacao = @codAvaliacao";
                Conexao.ExecutarManipulacao(CommandType.Text, sql);
                sucesso = true;
            }
            catch (Exception)
            {
                throw;
            }
            return sucesso;
        }

        public IEnumerable<ObjetoAuxiliar> GetInfoGrafico(long codAluno, string infoGrafico)
        {
            List<ObjetoAuxiliar> auxiliars = new List<ObjetoAuxiliar>();

            try
            {
                Conexao.LimparParametros();
                Conexao.AdicionarParametros("@codAluno", codAluno);
                string sqlListarInfo = "SELECT codAvaliacao," +
                    "codAluno," +
                    "data," +
                    "peso," +
                    "altura," +
                    "imc," +
                    "gorduraCorporal," +
                    "massaMuscEsqueletica," +
                    "metabolismoBasal," +
                    "idadeCorporal," +
                    "gorduraVisceral," +
                    "cintura," +
                    "quadril" +
                    "rcq," +
                    "grauRisco," +
                    "idade," +
                    " FROM avaliacao WHERE codAluno == @codAluno ORDER BY data ASC";

                DataTable dataTable = Conexao.ExecutarConsulta(CommandType.Text, sqlListarInfo);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    ObjetoAuxiliar oa = new ObjetoAuxiliar();
                    oa.Data = Convert.ToDateTime(dataRow["data"]);
                    if (infoGrafico.Equals(InfoGrafico.TaxaGordura))
                    {
                        oa.Valor = Convert.ToDecimal(dataRow["gorduraCorporal"]);
                    }
                    else if (infoGrafico.Equals(InfoGrafico.MassaMuscular))
                    {
                        oa.Valor = Convert.ToDecimal(dataRow["massaMuscEsqueletica"]);
                    }
                    else if (infoGrafico.Equals(InfoGrafico.Peso))
                    {
                        oa.Valor = Convert.ToDecimal(dataRow["peso"]);
                    }
                    else if (infoGrafico.Equals(InfoGrafico.RelacaoQuadrilCintura))
                    {
                        oa.Valor = Convert.ToDecimal(dataRow["rcq"]);//Math.Round(Convert.ToDecimal(dataRow["cintura"])/ Convert.ToDecimal(dataRow["quadril"]), 2);
                    }
                    else if (infoGrafico.Equals(InfoGrafico.Metabolismo))
                    {
                        oa.Valor = Convert.ToInt32(dataRow["metabolismoBasal"]);
                    }
                    

                    auxiliars.Add(oa);
                }

                return auxiliars;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetVariacaoFisicaPorFaixaEtaria(int ano, string campoAvaliacao)
        {
            try
            {
                string anoStr = Convert.ToString(ano); 
                string sql = "WITH AgeData AS " +
                                        "(SELECT dataNascimento, " +
                                        "[codAluno]," +
                                        "(strftime('%Y', 'now') - strftime('%Y', dataNascimento)) - (strftime('%m-%d', 'now') " +
                                        "< strftime('%m-%d', dataNascimento)) AS IDADE FROM aluno), " +

                                        "GroupAge AS (" +
                                        "SELECT [codAluno], " +
                                        "CASE " +
                                        "WHEN IDADE <= 29 THEN '-29' " +
                                        "WHEN IDADE BETWEEN 30 AND 39 THEN '30 - 39' " +
                                        "WHEN IDADE BETWEEN 40 AND 49 THEN '40 - 49' " +
                                        "WHEN IDADE BETWEEN 50 AND 59 THEN '50 - 59' " +
                                        "WHEN IDADE > 59 THEN 'acima de 59' " +
                                        "END AS AgeGroups " +
                                        "FROM AgeData), " +

                                        "AvaliacaoInicial AS " +
                                        "(SELECT [codAluno], [" + campoAvaliacao + "], MIN(data) AS minDate " +
                                        "FROM avaliacao " +
                                        "WHERE strftime('%s',data) BETWEEN strftime('%s', '" + anoStr + "-01-01') AND strftime('%s', '" + anoStr + "-12-31') " +
                                        "GROUP BY [codAluno]), " +

                                        "AvaliacaoFinal AS " +
                                        "(SELECT [codAluno], [" + campoAvaliacao + "], MAX(data) AS maxDate " +
                                        "FROM avaliacao " +
                                        "WHERE strftime('%s',data) BETWEEN strftime('%s', '" + anoStr + "-01-01') AND strftime('%s', '" + anoStr + "-12-31') " +
                                        "GROUP BY [codAluno]), " +

                                        "DifAvaliacao AS " +
                                        "(SELECT ai.codAluno, " +
                                        "(((af." + campoAvaliacao + " *100) / ai." + campoAvaliacao + ")-100) AS variacaoAvaliacao " +
                                        "FROM AvaliacaoInicial AS ai " +
                                        "JOIN AvaliacaoFinal AS af " +
                                        "ON ai.codAluno = af.codAluno " +
                                        "GROUP BY af.codAluno) " +

                                        "SELECT ga.AgeGroups AS Grupo, " +
                                        "AVG(da.variacaoAvaliacao) AS VariacaoAvaliacao " +
                                        "FROM GroupAge AS ga " +
                                        "JOIN DifAvaliacao AS da " +
                                        "ON ga.codAluno = da.codAluno AND da.variacaoAvaliacao != 0 " +
                                        "GROUP BY Grupo";

                return Conexao.ExecutarConsulta(CommandType.Text, sql);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetVariacaoRcqPorFaixaEtaria(int ano)
        {
            try
            {
                string anoStr = Convert.ToString(ano);
                string sql = "WITH AgeData AS " +
                                        "(SELECT dataNascimento, [codAluno], " +
                                        "(strftime('%Y', 'now') - strftime('%Y', dataNascimento)) - (strftime('%m-%d', 'now') " +
                                        "< strftime('%m-%d', dataNascimento)) AS IDADE FROM aluno), " +

                                        "GroupAge AS " +
                                        "(SELECT [codAluno], " +
                                        "CASE " +
                                        "WHEN IDADE <= 29 THEN '-29' " +
                                        "WHEN IDADE BETWEEN 30 AND 39 THEN '30 - 39' " +
                                        "WHEN IDADE BETWEEN 40 AND 49 THEN '40 - 49' " +
                                        "WHEN IDADE BETWEEN 50 AND 59 THEN '50 - 59' " +
                                        "WHEN IDADE > 59 THEN 'acima de 59' " +
                                        "END AS AgeGroups " +
                                        "FROM AgeData), " +

                                        "AvaliacaoInicial AS " +
                                        "(SELECT [codAluno],[rcq] AS rcqInit, MIN(data) AS minDate " +
                                        "FROM avaliacao " +
                                        "WHERE strftime('%s',data) BETWEEN strftime('%s', '" + anoStr + "-01-01') AND strftime('%s', '" + anoStr + "-12-31') " +
                                        "GROUP BY [codAluno]), " +

                                        "AvaliacaoFinal AS " +
                                        "(SELECT [codAluno],[rcq] AS rcqFinal, MAX(data) AS maxDate " +
                                        "FROM avaliacao " +
                                        "WHERE strftime('%s',data) BETWEEN strftime('%s', '" + anoStr + "-01-01') AND strftime('%s', '" + anoStr + "-12-31') " +
                                        "GROUP BY [codAluno]) " +
                                        
                                        "SELECT GA.AgeGroups AS Grupo, " +
                                        "AVG(AI.cinturaInit) AS cintMediaInit, " +
                                        "AVG(AI.quadrilInit) AS quadrilMedioInit," +
                                        "AVG(AF.cinturaFinal) AS cintMediaFinal," +
                                        "AVG(AF.quadrilFinal) AS quadrilMedioFinal " +
                                        "FROM GroupAge AS GA " +
                                        "JOIN AvaliacaoInicial AS AI ON GA.codAluno = AI.codAluno " +
                                        "JOIN AvaliacaoFinal AS AF ON GA.codAluno = AF.codAluno " +
                                        "GROUP BY Grupo";

                return Conexao.ExecutarConsulta(CommandType.Text, sql);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetVariacaoFisicaPorSexoFaixaEtaria(int ano, string campoAvaliacao)
        {
            try
            {
                string anoStr = Convert.ToString(ano);
                string sql = "WITH AgeData AS " +
                                        "(SELECT dataNascimento, " +
                                        "[codAluno]," +
                                        "(strftime('%Y', 'now') - strftime('%Y', dataNascimento)) - (strftime('%m-%d', 'now') " +
                                        "< strftime('%m-%d', dataNascimento)) AS IDADE FROM aluno), " +

                                        "GroupAge AS " +
                                        "(SELECT [codAluno], " +
                                        "CASE " +
                                        "WHEN IDADE <= 29 THEN '-29' " +
                                        "WHEN IDADE BETWEEN 30 AND 39 THEN '30 - 39' " +
                                        "WHEN IDADE BETWEEN 40 AND 49 THEN '40 - 49' " +
                                        "WHEN IDADE BETWEEN 50 AND 59 THEN '50 - 59' " +
                                        "WHEN IDADE > 59 THEN 'acima de 59' " +
                                        "END AS AgeGroups " +
                                        "FROM AgeData), " +

                                        "SexGroup AS " +
                                        "(SELECT [codAluno], " +
                                        "CASE " +
                                        "WHEN sexo = 'M' THEN 'Masc' " +
                                        "WHEN sexo = 'F' THEN 'Fem' " +
                                        "END AS SEXO " +
                                        "FROM aluno), " +

                                        "AvaliacaoInicial AS " +
                                        "(SELECT [codAluno], [" + campoAvaliacao + "], MIN(data) AS minDate " +
                                        "FROM avaliacao " +
                                        "WHERE strftime('%s',data) BETWEEN strftime('%s', '" + anoStr + "-01-01') AND strftime('%s', '" + anoStr + "-12-31') " +
                                        "GROUP BY [codAluno]), " +

                                        "AvaliacaoFinal AS " +
                                        "(SELECT [codAluno], [" + campoAvaliacao + "], MAX(data) AS maxDate " +
                                        "FROM avaliacao " +
                                        "WHERE strftime('%s',data) BETWEEN strftime('%s', '" + anoStr + "-01-01') AND strftime('%s', '" + anoStr + "-12-31') " +
                                        "GROUP BY [codAluno]) " +

                                        "SELECT GA.AgeGroups AS Grupo, SG.SEXO AS Sexo, " +
                                        "AVG(AI." + campoAvaliacao + ") AS Inicial, " +
                                        "AVG(AF." + campoAvaliacao + ") AS Atual " +
                                        "FROM GroupAge AS GA " +
                                        "JOIN AvaliacaoInicial AS AI ON GA.codAluno = AI.codAluno " +
                                        "JOIN AvaliacaoFinal AS AF ON GA.codAluno = AF.codAluno AND AI.minDate != AF.maxDate " +
                                        "JOIN SexGroup AS SG ON GA.codAluno = SG.codAluno " +
                                        "GROUP BY GA.codAluno " +
                                        "ORDER BY Grupo";

                return Conexao.ExecutarConsulta(CommandType.Text, sql);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RiscoRcq> GetVariacaoRcqPorSexoFaixaEtaria(int ano)
        {
            try
            {
                List<RiscoRcq> riscos = new List<RiscoRcq>();

                string anoStr = Convert.ToString(ano);
                string sql = "WITH AgeData AS " +
                                        "(SELECT dataNascimento, " +
                                        "[codAluno]," +
                                        "(strftime('%Y', 'now') - strftime('%Y', dataNascimento)) - (strftime('%m-%d', 'now') " +
                                        "< strftime('%m-%d', dataNascimento)) AS IDADE FROM aluno), " +

                                        "GroupAge AS " +
                                        "(SELECT [codAluno], " +
                                        "CASE " +
                                        "WHEN IDADE <= 29 THEN '-29' " +
                                        "WHEN IDADE BETWEEN 30 AND 39 THEN '30 - 39' " +
                                        "WHEN IDADE BETWEEN 40 AND 49 THEN '40 - 49' " +
                                        "WHEN IDADE BETWEEN 50 AND 59 THEN '50 - 59' " +
                                        "WHEN IDADE > 59 THEN 'acima de 59' " +
                                        "END AS AgeGroups " +
                                        "FROM AgeData), " +

                                        "SexGroup AS " +
                                        "(SELECT [codAluno], " +
                                        "CASE " +
                                        "WHEN sexo = 'M' THEN 'Masc' " +
                                        "WHEN sexo = 'F' THEN 'Fem' " +
                                        "END AS SEXO " +
                                        "FROM aluno), " +

                                        "AvaliacaoInicial AS " +
                                        "(SELECT [codAluno], [rcq] AS rcqInit, MIN(data) AS minDate " +
                                        "FROM avaliacao " +
                                        "WHERE strftime('%s',data) BETWEEN strftime('%s', '" + anoStr + "-01-01') AND strftime('%s', '" + anoStr + "-12-31') " +
                                        "GROUP BY [codAluno]), " +

                                        "AvaliacaoFinal AS " +
                                        "(SELECT [codAluno], [rcq] AS rcqFinal, MAX(data) AS maxDate " +
                                        "FROM avaliacao " +
                                        "WHERE strftime('%s',data) BETWEEN strftime('%s', '" + anoStr + "-01-01') AND strftime('%s', '" + anoStr + "-12-31') " +
                                        "GROUP BY [codAluno]) " +

                                        "SELECT GA.AgeGroups AS Grupo, SG.SEXO AS Sexo, " +
                                        "AI.rcqInit, " +
                                        "AF.rcqFinal " +
                                        "FROM GroupAge AS GA " +
                                        "JOIN AvaliacaoInicial AS AI ON GA.codAluno = AI.codAluno " +
                                        "JOIN AvaliacaoFinal AS AF ON GA.codAluno = AF.codAluno " +
                                        "JOIN SexGroup AS SG ON GA.codAluno = SG.codAluno " +
                                        "GROUP BY GA.codAluno " +
                                        "ORDER BY Grupo";

                DataTable dataTable = Conexao.ExecutarConsulta(CommandType.Text, sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    RiscoRcq risco = new RiscoRcq
                    {
                        Sexo = Convert.ToString(row["Sexo"]),
                        FaixaEtaria = Convert.ToString(row["Grupo"]),
                        RcqInit = (Convert.ToDecimal(row["rcqInit"])),
                        RcqAtual = (Convert.ToDecimal(row["rcqFinal"]))
                    };
                    risco.RiscoInicial = RiscoRcq.GetRiscosRcq(risco.Sexo, risco.FaixaEtaria, risco.RcqInit);
                    risco.RiscoAtual = RiscoRcq.GetRiscosRcq(risco.Sexo, risco.FaixaEtaria, risco.RcqAtual);
                    riscos.Add(risco);
                }

                return riscos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ComparativoAvaliacoes GetAvaliacaoSeletiva(long codAluno)
        {
            try
            {
                Conexao.LimparParametros();
                Conexao.AdicionarParametros("@codAluno", codAluno);
                ComparativoAvaliacoes auxiliar = new ComparativoAvaliacoes();

                string sql = "WITH AvaliacaoInit AS " +
                                 "(SELECT " +
                                     "[codAluno], [gorduraCorporal] AS gorduraInit, [massaMuscEsqueletica] AS musculoInit, " +
                                     "[cintura] AS cinturaInit, [quadril] As quadrilInit, MIN(data) AS minDate " +
                                 "FROM avaliacao WHERE codAluno = @codAluno), " +

                                 "AvaliacaoAtual AS " +
                                     "(SELECT " +
                                         "[codAluno], [gorduraCorporal] AS gorduraAtual, [massaMuscEsqueletica] AS musculoAtual, " +
                                         "[cintura] AS cinturaAtual, [quadril] As quadrilAtual, MAX(data) AS maxDate " +
                                 "FROM avaliacao WHERE codAluno = @codAluno) " +

                                 "SELECT " +
                                    "AI.codAluno, " +
                                    "AI.gorduraInit, " +
                                    "AI.musculoInit, " +
                                    "AI.cinturaInit, " +
                                    "AI.quadrilInit, " +
                                    "AA.gorduraAtual, " +
                                    "AA.musculoAtual, " +
                                    "AA.cinturaAtual, " +
                                    "AA.quadrilAtual " +
                                  "FROM AvaliacaoInit AS AI " +
                                  "JOIN AvaliacaoAtual AS AA ON AA.codAluno = AI.codAluno AND AI.minDate != AA.maxDate";

                using (IDataReader leitor = Conexao.BuscarRegistro(CommandType.Text, sql))
                {
                    while (leitor.Read())
                    {
                        auxiliar.CodAluno = Convert.ToInt64(leitor["codAluno"]);
                        auxiliar.GorduraInit = Convert.ToDecimal(leitor["gorduraInit"]);
                        auxiliar.MusculoInit = Convert.ToDecimal(leitor["musculoInit"]);
                        auxiliar.CinturaInit = Convert.ToDecimal(leitor["cinturaInit"]);
                        auxiliar.QuadrilInit = Convert.ToDecimal(leitor["quadrilInit"]);
                        auxiliar.GorduraAtual = Convert.ToDecimal(leitor["gorduraAtual"]);
                        auxiliar.MusculoAtual = Convert.ToDecimal(leitor["musculoAtual"]);
                        auxiliar.CinturaAtual = Convert.ToDecimal(leitor["cinturaAtual"]);
                        auxiliar.QuadrilAtual = Convert.ToDecimal(leitor["quadrilAtual"]);
                    }

                    return auxiliar;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ContarAvaliacoes(int ano)
        {
            DateTime dateInit = Convert.ToDateTime("01/01/"+ ano);
            DateTime dateFinal = Convert.ToDateTime("31/12/" + ano);

            try
            {
                Conexao.LimparParametros();
                Conexao.AdicionarParametros("@dataInit", dateInit);
                Conexao.AdicionarParametros("@dataFinal", dateFinal);

                string sql = "SELECT COUNT(codAvaliacao) FROM avaliacao WHERE data BETWEEN @dataInit AND @dataFinal";

                return Conexao.ContarRegistros(CommandType.Text, sql);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
