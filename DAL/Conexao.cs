using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace FitRelatorio.DAL
{
    public class Conexao
    {
        private static SQLiteConnection connection;
        public static string ObterCaminhoDiscoPirncipal()
        {
            //obtem o caminho do executável da aplicação
            string caminho = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.ToString());//Application.StartupPath;
            //obtem o disco onde a aplicação está instalada
            string discoPrincipal = Path.GetPathRoot(caminho);

            return discoPrincipal;
        }

        public static bool ExisteDb()
        {
            string disco = ObterCaminhoDiscoPirncipal();

            if (!File.Exists("" + disco + "\\FitReportDB\\Data\\FitReportDB.db3"))
            {
                CriaDb();
                return true;
            }
            else return false;
        }

        //Método para cria o banco de dados
        private static void CriaDb()
        {
            try
            {
                string disco = ObterCaminhoDiscoPirncipal();

                if (!Directory.Exists("" + disco + "\\FitReportDB\\Data"))
                {
                    DirectoryInfo diretorio = Directory.CreateDirectory("" + disco + "\\FitReportDB\\Data");
                    diretorio.Attributes = FileAttributes.Hidden;
                }
                SQLiteConnection.CreateFile("" + disco + "\\FitReportDB\\Data\\FitReportDB.db3");
                SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + disco + "\\FitReportDB\\Data\\FitReportDB.db3");
                SQLiteCommand command = new SQLiteCommand(conn);
                string caminho = conn.DataSource;
                conn.Open();

                string sqlScript = "CREATE TABLE aluno (codAluno INTEGER PRIMARY KEY ASC AUTOINCREMENT UNIQUE NOT NULL, nome VARCHAR (70) NOT NULL, cpf VARCHAR (15) UNIQUE NOT NULL, dataNascimento DATE NOT NULL, sexo VARCHAR (1) NOT NULL);";
                sqlScript += "CREATE TABLE avaliacao (codAvaliacao INTEGER PRIMARY KEY ASC AUTOINCREMENT UNIQUE NOT NULL, codAluno INTEGER REFERENCES aluno (codAluno) NOT NULL, data DATE NOT NULL, peso DECIMAL (5, 2) NOT NULL, altura DECIMAL (3, 2) NOT NULL, imc DECIMAL (5, 2) NOT NULL, gorduraCorporal DECIMAL (5, 2) NOT NULL, massaMuscEsqueletica DECIMAL (5, 2) NOT NULL, metabolismoBasal INTEGER NOT NULL, idadeCorporal INTEGER NOT NULL, gorduraVisceral INTEGER NOT NULL, cintura DECIMAL (5, 2) NOT NULL, quadril DECIMAL (5, 2) NOT NULL, rcq DECIMAL (4, 2) NOT NULL, grauRisco VARCHAR (70) NOT NULL, idade INTEGER NOT NULL, classificacaoGorduraCorporal VARCHAR (70) NOT NULL);";

                command.CommandText = sqlScript;

                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao criar o Banco de Dados: " + e.Message);
            }
        }

        //Criar conexão SQLite
        private static SQLiteConnection CriarConexao()
        {
            string disco = ObterCaminhoDiscoPirncipal();
            return new SQLiteConnection(@"Data Source=" + disco + "\\FitReportDB\\Data\\FitReportDB.db3");
        }

        private static void FecharConexao()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        //Parametros que irão para o banco
        private static SQLiteParameterCollection sqlParameterCollection = new SQLiteCommand().Parameters;

        //Limpar parametros
        public static void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        //Adicionar parametros
        public static void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.Add(new SQLiteParameter(nomeParametro, valorParametro));
        }

        //Realizar consultas
        public static DataTable ExecutarConsulta(CommandType tipoComando, string nomeProcedureOuTextoSql)
        {
            using (connection = CriarConexao())
            {
                connection.Open();

                using (SQLiteCommand comandoSql = connection.CreateCommand())
                {
                    //Colocando as coisas dentro do comando
                    comandoSql.CommandType = tipoComando;
                    comandoSql.CommandText = nomeProcedureOuTextoSql;

                    //Adicionar os parametros no comando
                    foreach (SQLiteParameter sqlParameter in sqlParameterCollection)
                    {
                        comandoSql.Parameters.Add(new SQLiteParameter(sqlParameter.ParameterName, sqlParameter.Value));
                    }

                    //Criar um adaptador para carregar os grids nos forms
                    SQLiteDataAdapter adaptadorDeDados = new SQLiteDataAdapter(comandoSql);

                    //DataTable - cria uma tabela vazia para carregar os dados vindos do banco
                    DataTable tabelaDados = new DataTable();

                    //Mandar o comando ir até o banco buscar os dados e o adaptador preencher a tabela de dados (dataTable)
                    adaptadorDeDados.Fill(tabelaDados);

                    //Executar o comando. Mandar o comando até o banco                
                    return tabelaDados;
                }
            }
        }


        //Manipulação de dados - Inserir, Alterar, Excluir
        public static object ExecutarManipulacao(CommandType tipoComando, string nomeProcedureOuTextoSql)
        {
            using (connection = CriarConexao())
            {
                connection.Open();

                using (SQLiteCommand comandoSql = connection.CreateCommand())
                {
                    comandoSql.CommandType = tipoComando;
                    comandoSql.CommandText = nomeProcedureOuTextoSql;

                    //Adicionar os parametros no comando
                    foreach (SQLiteParameter sqlParameter in sqlParameterCollection)
                    {
                        comandoSql.Parameters.Add(new SQLiteParameter(sqlParameter.ParameterName, sqlParameter.Value));
                    }

                    //Executar o comando. Mandar o comando até o banco
                    return comandoSql.ExecuteScalar();
                }
            }
        }

        public static IDataReader BuscarRegistro(CommandType tipoComando, string nomeProcedureOuTextoSql)
        {
            connection = CriarConexao();

            connection.Open();
            SQLiteCommand comandoSql = connection.CreateCommand();

            //Colocando as coisas dentro do comando
            comandoSql.CommandType = tipoComando;
            comandoSql.CommandText = nomeProcedureOuTextoSql;

            //Adicionar os parametros no comando
            foreach (SQLiteParameter sqlParameter in sqlParameterCollection)
            {
                comandoSql.Parameters.Add(new SQLiteParameter(sqlParameter.ParameterName, sqlParameter.Value));
            }

            return comandoSql.ExecuteReader();
                        
        }

        public static int ContarRegistros(CommandType tipoComando, string nomeProcedureOuTextoSql)
        {
            using (connection = CriarConexao())
            {
                connection.Open();

                using (SQLiteCommand comandoSql = connection.CreateCommand())
                {
                    comandoSql.CommandType = tipoComando;
                    comandoSql.CommandText = nomeProcedureOuTextoSql;

                    //Adicionar os parametros no comando
                    foreach (SQLiteParameter sqlParameter in sqlParameterCollection)
                    {
                        comandoSql.Parameters.Add(new SQLiteParameter(sqlParameter.ParameterName, sqlParameter.Value));
                    }

                    //Executar o comando. Mandar o comando até o banco
                    int count = Convert.ToInt32(comandoSql.ExecuteScalar());
                    return count;
                }
            }
        }
    }
}
