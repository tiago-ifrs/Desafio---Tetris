using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Text;

public class PontuacaoDAO
{
    /*
     * USE [tetris]
GO

INSERT INTO [dbo].[pontuacao]
           ([id]
           ,[nome]
           ,[score]
           ,[nivel]
           ,[tempo_jogo]
           ,[qtd_pecas]
           ,[data_score]
           ,[tabuleiro])
     VALUES
           (<id, int,>
           ,<nome, nvarchar(50),>
           ,<score, int,>
           ,<nivel, int,>
           ,<tempo_jogo, time(7),>
           ,<qtd_pecas, int,>
           ,<data_score, datetime,>
           ,<tabuleiro, image,>)
GO


     */
    public void Insert(Pontuacao p) 
    {
        OleDbConnection connection = null;
        try
        {
            connection = Conexao.Abre();
            Conexao.VerifyDBConnection(ref connection);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Clear()
                .AppendLine("INSERT INTO                        ")
                .AppendLine("   DBO.PONTUACAO                   ")
                .AppendLine("   (ID,                            ")
                //.AppendLine("   (                            ")
                .AppendLine("   NOME,                           ")
                .AppendLine("   SCORE,                          ")
                .AppendLine("   NIVEL,                          ")
                .AppendLine("   TEMPO_JOGO,                     ")
                .AppendLine("   QTD_PECAS,                      ")
                .AppendLine("   DATA_SCORE,                     ")
                .AppendLine("   TABULEIRO)                      ")
                .AppendLine("   VALUES                             ")
                .AppendLine("   (@ID,                           ")
                //.AppendLine("   (                           ")
                .AppendLine("   @NOME,                          ")
                .AppendLine("   @SCORE,                         ")
                .AppendLine("   @NIVEL,                         ")
                .AppendLine("   @TEMPO_JOGO,                    ")
                .AppendLine("   @QTD_PECAS,                     ")
                .AppendLine("   @DATA_SCORE,                    ")
                .AppendLine("   @TABULEIRO)                  ");
                //.AppendLine("   GO                              ");

            /*
            .AppendLine("WHERE                              ")
            .AppendLine("   ESTACAO = ?                     ")
            .AppendLine("   AND LINHA_MONTAGEM = ?          ");
            */
            List<OleDbParameter> st = new List<OleDbParameter>();
            using (OleDbCommand command = connection.CreateCommand())
            {
                command.CommandText = stringBuilder.ToString();

                st.Add(command.Parameters.AddWithValue("@Id", 0));
                st.Add(command.Parameters.AddWithValue("@NOME", p.Nome));
                st.Add(command.Parameters.AddWithValue("@SCORE", p.Score));
                st.Add(command.Parameters.AddWithValue("@NIVEL", p.Nivel));
                st.Add(command.Parameters.AddWithValue("@TEMPO_JOGO", p.TempoJogo));
                st.Add(command.Parameters.AddWithValue("@QTD_PECAS", p.QtdPecas));
                st.Add(command.Parameters.AddWithValue("@DATA_SCORE", p.DataScore));
                st.Add(command.Parameters.AddWithValue("@TABULEIRO", p.Tabuleiro));

                object result = command.ExecuteReader();
            }
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
            //userControlRastreabilidade.SetDisplayTela("Falha ao retornar WorkCenter", exception.Message, sqoAlarmes.Prioridade.Alarme, true);
            
        }
        finally
        {
            Conexao.CloseDBConnection(ref connection);
        }
    }

    public PontuacaoDAO()
    {
    }
    public Pontuacao popula()
    {
        OleDbConnection connection = null;
        try
        {
            connection = Conexao.Abre();
            Conexao.VerifyDBConnection(ref connection);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Clear()
                .AppendLine("SELECT                              ")
                .AppendLine("   ID,                             ")
                .AppendLine("   NOME,                           ")
                .AppendLine("   SCORE,                          ")
                .AppendLine("   NIVEL,                          ")
                .AppendLine("   TEMPO_JOGO,                     ")
                .AppendLine("   QTD_PECAS,                      ")
                .AppendLine("   DATA_SCORE,                     ")
                .AppendLine("   TABULEIRO                      ")
                .AppendLine("FROM                               ")
                .AppendLine("   DBO.PONTUACAO      WITH(NOLOCK) ");
            /*
            .AppendLine("WHERE                              ")
            .AppendLine("   ESTACAO = ?                     ")
            .AppendLine("   AND LINHA_MONTAGEM = ?          ");
            */

            using (OleDbCommand command = connection.CreateCommand())
            {
                command.CommandText = stringBuilder.ToString();

                /*
                command.Parameters.AddWithValue("@ESTACAO", station);
                command.Parameters.AddWithValue("@LINHA_MOTNAGEM", assemblyline);
                */

                var result = command.ExecuteReader();

                if (result != null)
                {
                    result.Read();

                    return new Pontuacao()
                    {
                        Id = (int)result["ID"],
                        Nome = result["NOME"].ToString(),
                        Score = (int)result["SCORE"],
                        Nivel = (int)result["NIVEL"],
                        //TempoJogo = result["TEMPO_JOGO"],
                        QtdPecas = (int)result["QTD_PECAS"],
                        //DataScore = result["DATA_SCORE"],
                        Tabuleiro = (Bitmap)result["TABULEIRO"]

                    };
                }
            }

            return new Pontuacao();
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
            //userControlRastreabilidade.SetDisplayTela("Falha ao retornar WorkCenter", exception.Message, sqoAlarmes.Prioridade.Alarme, true);
            //return new Pontuacao();
        }
        finally
        {
            Conexao.CloseDBConnection(ref connection);
        }
    }
}
