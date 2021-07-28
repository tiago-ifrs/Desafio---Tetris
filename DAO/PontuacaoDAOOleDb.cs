﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

public class PontuacaoDAOOleDb:AbsPontuacaoDAO
{
    public PontuacaoDAOOleDb()
    {
    }
    public override void Insert(Pontuacao p)
    {
        object result;
        MemoryStream ms = new MemoryStream();
        byte[] photo_aray;
        Conexao conexao = new Conexao();

        p.Tabuleiro.Save(ms, ImageFormat.Jpeg);
        photo_aray = new byte[ms.Length];
        ms.Position = 0;
        ms.Read(photo_aray, 0, photo_aray.Length);
        try
        {
            DbConnection Connection = conexao.Abre();
            conexao.VerifyDBConnection();
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

                using OleDbCommand command = (OleDbCommand)Connection.CreateCommand();
                command.CommandText = stringBuilder.ToString();

                command.Parameters.AddWithValue("@NOME", p.Nome);
                command.Parameters.AddWithValue("@SCORE", p.Score);
                command.Parameters.AddWithValue("@NIVEL", p.Nivel);
                command.Parameters.AddWithValue("@TEMPO_JOGO", p.TempoJogo);
                command.Parameters.AddWithValue("@QTD_PECAS", p.QtdPecas);
                command.Parameters.AddWithValue("@DATA_SCORE", p.DataScore);
                command.Parameters.AddWithValue("@TABULEIRO", photo_aray);

                result = command.ExecuteReader();
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
            //userControlRastreabilidade.SetDisplayTela("Falha ao retornar WorkCenter", exception.Message, sqoAlarmes.Prioridade.Alarme, true);
        }
        finally
        {
            conexao.CloseDBConnection();
        }
    }
    public override Pontuacao ImagemPorId(int id)
    {
        DbConnection connection = null;
        Conexao conexao = new Conexao();
        Pontuacao p = null;
        try
        {
            connection = conexao.Abre();
            conexao.VerifyDBConnection();
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

                using (OleDbCommand command = (OleDbCommand)connection.CreateCommand())
                {
                    command.CommandText = stringBuilder.ToString();
                    command.Parameters.AddWithValue("@ID", id);

                    OleDbDataReader result = command.ExecuteReader();
                    result.Read();
                    MemoryStream ms = new MemoryStream((byte[])result["TABULEIRO"]);
                    p = new Pontuacao
                    {
                        Id = id,
                        Nome = result["NOME"].ToString(),
                        DataScore = (DateTime)result["DATA_SCORE"],
                        Tabuleiro = new Bitmap(ms)
                    };
                }
                return p;
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
            //userControlRastreabilidade.SetDisplayTela("Falha ao retornar WorkCenter", exception.Message, sqoAlarmes.Prioridade.Alarme, true);
        }
        finally
        {
            conexao.CloseDBConnection();
        }
    }
    public override List<Pontuacao> ListaTodos()
    {
        DbConnection connection = null;
        Conexao conexao = new Conexao();
        List<Pontuacao> lp = new List<Pontuacao>();
        try
        {
            connection = conexao.Abre();
            conexao.VerifyDBConnection();
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

            
                using (OleDbCommand command = (OleDbCommand)connection.CreateCommand())
                {
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
                            TempoJogo = TimeSpan.Parse(result["TEMPO_JOGO"].ToString()),
                            QtdPecas = (int)result["QTD_PECAS"],
                            DataScore = (DateTime)result["DATA_SCORE"],
                            Tabuleiro = new Bitmap(ms)
                        };
                        lp.Add(p);
                    }
                }
                return lp;
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
            //userControlRastreabilidade.SetDisplayTela("Falha ao retornar WorkCenter", exception.Message, sqoAlarmes.Prioridade.Alarme, true);
        }
        finally
        {
            conexao.CloseDBConnection();
        }
    }
    public override List<Pontuacao> ListaTodosTLP()
    {
        DbConnection connection;
        Conexao conexao = new Conexao();
        List<Pontuacao> lp = new List<Pontuacao>();
        try
        {
            connection = conexao.Abre();
            conexao.VerifyDBConnection();
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
            using (OleDbCommand command = (OleDbCommand)connection.CreateCommand())
            {
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
                        TempoJogo = TimeSpan.Parse(result["TEMPO_JOGO"].ToString()),
                        QtdPecas = (int)result["QTD_PECAS"],
                        DataScore = (DateTime)result["DATA_SCORE"],
                    };
                    lp.Add(p);
                }
            }
            return lp;
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
            //userControlRastreabilidade.SetDisplayTela("Falha ao retornar WorkCenter", exception.Message, sqoAlarmes.Prioridade.Alarme, true);
        }
        finally
        {
            conexao.CloseDBConnection();
        }
    }
}