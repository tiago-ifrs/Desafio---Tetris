using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Desafio___Tetris.Model
{
    public class Pontuacao
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome não pode ser nulo"), Display(Name = "Digite seu nome")]
        public string Nome { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        public int Nivel { get; set; }
        [Required]
        public TimeSpan TempoJogo { get; set; }
        [Required]
        public int QtdPecas { get; set; }
        [Required]
        public DateTime DataScore { get; set; }
        [Required]
        public Bitmap Tabuleiro { get; set; }
        public Pontuacao()
        {
        }
    }
}
