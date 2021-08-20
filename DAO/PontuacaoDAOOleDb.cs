using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using Desafio___Tetris.Model;
using Desafio___Tetris.Conexoes;

public class PontuacaoDaoOleDb:AbsPontuacaoDao
{
    public PontuacaoDaoOleDb()
    {
    }
    public override void Insert(Pontuacao p)
    {
        MemoryStream ms = new MemoryStream();
        byte[] photoAray = new byte[ms.Length]; 
        Conexao conexao = new Conexao();

        p.Tabuleiro.Save(ms, ImageFormat.Jpeg);
        ms.Position = 0;
        ms.Read(photoAray, 0, photoAray.Length);
        try
        {
            OleDbDataReader result;
            DbConnection connection = conexao.DbConnection;
            conexao.VerifyDbConnection();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Clear()
                .AppendLine("USE TETRIS                         ")
                .AppendLine("INSERT INTO                        ")
                .AppendLine("   DBO.PONTUACAO                   ")
                .AppendLine("   (                               ")
                .AppendLine("   NOME,                           ")
                .AppendLine("   SCORE,                          ")
                .AppendLine("   NIVEL,                          ")
                .AppendLine("   TEMPO_JOGO,                     ")
                .AppendLine("   QTD_PECAS,                      ")
                .AppendLine("   DATA_SCORE,                     ")
                .AppendLine("   TABULEIRO)                      ")
                .AppendLine("   VALUES                          ")
                .AppendLine("   (?,                             ")
                .AppendLine("   ?,                              ")
                .AppendLine("   ?,                              ")
                .AppendLine("   ?,                              ")
                .AppendLine("   ?,                              ")
                .AppendLine("   ?,                              ")
                .AppendLine("   ?);                             ");

                using OleDbCommand command = (OleDbCommand)connection.CreateCommand();
                command.CommandText = stringBuilder.ToString();

                command.Parameters.AddWithValue("@NOME", p.Nome);
                command.Parameters.AddWithValue("@SCORE", p.Score);
                command.Parameters.AddWithValue("@NIVEL", p.Nivel);
                command.Parameters.AddWithValue("@TEMPO_JOGO", p.TempoJogo);
                command.Parameters.AddWithValue("@QTD_PECAS", p.QtdPecas);
                command.Parameters.AddWithValue("@DATA_SCORE", p.DataScore);
                command.Parameters.AddWithValue("@TABULEIRO", photoAray);

                result = command.ExecuteReader();
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            conexao.DbConnection.Close();
        }
    }
    public override Pontuacao ImagemPorId(int id)
    {
        Conexao conexao = new Conexao();
        try
        {
            DbConnection connection = conexao.DbConnection;
            conexao.VerifyDbConnection();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Clear()
                .AppendLine("USE TETRIS                         ")
                .AppendLine("SELECT                             ")
                .AppendLine("   NOME,                           ")
                .AppendLine("   DATA_SCORE,                     ")
                .AppendLine("   TABULEIRO                       ")
                .AppendLine("FROM                               ")
                .AppendLine("   DBO.PONTUACAO      WITH(NOLOCK) ")
                .AppendLine("   WHERE                           ")
                .AppendLine("   ID = ?                          ");

            using OleDbCommand command = (OleDbCommand)connection.CreateCommand();
            command.CommandText = stringBuilder.ToString();
            command.Parameters.AddWithValue("@ID", id);

            OleDbDataReader result = command.ExecuteReader();
            result.Read();
            MemoryStream ms = new MemoryStream((byte[])result["TABULEIRO"]);
            Pontuacao p = new Pontuacao
            {
                Id = id,
                Nome = result["NOME"].ToString(),
                DataScore = (DateTime)result["DATA_SCORE"],
                Tabuleiro = new Bitmap(ms)
            };
            return p;
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            conexao.DbConnection.Close();
        }
    }
    public override List<Pontuacao> ListaTodos()
    {
        Conexao conexao = new Conexao();
        List<Pontuacao> lp = new List<Pontuacao>();
        try
        {
            DbConnection connection = conexao.DbConnection;
            conexao.VerifyDbConnection();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Clear()
                .AppendLine("USE TETRIS                         ")
                .AppendLine("SELECT                             ")
                .AppendLine("   ID,                             ")
                .AppendLine("   NOME,                           ")
                .AppendLine("   SCORE,                          ")
                .AppendLine("   NIVEL,                          ")
                .AppendLine("   TEMPO_JOGO,                     ")
                .AppendLine("   QTD_PECAS,                      ")
                .AppendLine("   DATA_SCORE,                     ")
                .AppendLine("   TABULEIRO                       ")
                .AppendLine("FROM                               ")
                .AppendLine("   DBO.PONTUACAO      WITH(NOLOCK) ")
                .AppendLine("   ORDER BY                        ")
                .AppendLine("   SCORE                           ")
                .AppendLine("   DESC                            ");


            using OleDbCommand command = (OleDbCommand)connection.CreateCommand();
            command.CommandText = stringBuilder.ToString();

            OleDbDataReader result = command.ExecuteReader();
            while (result.Read())
            {
                MemoryStream ms = new MemoryStream((byte[])result["TABULEIRO"]);
                Pontuacao p = new Pontuacao()
                {
                    Id = (int)result["ID"],
                    Nome = result["NOME"].ToString(),
                    Score = (int)result["SCORE"],
                    Nivel = (int)result["NIVEL"],
                    TempoJogo = TimeSpan.Parse(result["TEMPO_JOGO"].ToString() ?? throw new InvalidOperationException()),
                    QtdPecas = (int)result["QTD_PECAS"],
                    DataScore = (DateTime)result["DATA_SCORE"],
                    Tabuleiro = new Bitmap(ms)
                };
                lp.Add(p);
            }

            return lp;
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            conexao.DbConnection.Close();
        }
    }
    public override List<Pontuacao> ListaTodosTlp()
    {
        Conexao conexao = new Conexao();
        List<Pontuacao> lp = new List<Pontuacao>();
        try
        {
            DbConnection connection = conexao.DbConnection;
            conexao.VerifyDbConnection();
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Clear()
            .AppendLine("USE TETRIS                         ")
            .AppendLine("SELECT                             ")
            .AppendLine("   ID,                             ")
            .AppendLine("   NOME,                           ")
            .AppendLine("   SCORE,                          ")
            .AppendLine("   NIVEL,                          ")
            .AppendLine("   TEMPO_JOGO,                     ")
            .AppendLine("   QTD_PECAS,                      ")
            .AppendLine("   DATA_SCORE                      ")
            .AppendLine("FROM                               ")
            .AppendLine("   DBO.PONTUACAO      WITH(NOLOCK) ")
            .AppendLine("   ORDER BY                        ")
            .AppendLine("   SCORE                           ")
            .AppendLine("   DESC                            ");
            using OleDbCommand command = (OleDbCommand)connection.CreateCommand();
            command.CommandText = stringBuilder.ToString();

            OleDbDataReader result = command.ExecuteReader();
            while (result.Read())
            {
                Pontuacao p = new Pontuacao()
                {
                    Id = (int)result["ID"],
                    Nome = result["NOME"].ToString(),
                    Score = (int)result["SCORE"],
                    Nivel = (int)result["NIVEL"],
                    TempoJogo = TimeSpan.Parse(result["TEMPO_JOGO"].ToString() ?? throw new InvalidOperationException()),
                    QtdPecas = (int)result["QTD_PECAS"],
                    DataScore = (DateTime)result["DATA_SCORE"],
                };
                lp.Add(p);
            }

            return lp;
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            conexao.DbConnection.Close();
        }
    }
}
