using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Desafio___Tetris.DAO;
using Desafio___Tetris.Model;

namespace Desafio___Tetris
{
    public partial class FormPontuacaoTlp : Form
    {
        public FormPontuacaoTlp()
        {
            InitializeComponent();
        }
        private void FormPontuacaoTLP_Load(object sender, EventArgs e)
        {
            
            AbsPontuacaoDao pd = new PontuacaoDao().AbsPontuacaoDao;
            List<Pontuacao> lp = pd.ListaTodosTlp();

            foreach(Pontuacao p in lp) 
            {
                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutPanel1.Controls.Add(new LabelNome(p.Id) { Text = p.Nome }, 0, tableLayoutPanel1.RowCount);                
                tableLayoutPanel1.Controls.Add(new Label() { Text = p.Score.ToString() }, 1, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new Label() { Text = p.Nivel.ToString() }, 2, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new Label() { Text = p.TempoJogo.ToString() }, 3, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new Label() { Text = p.QtdPecas.ToString() }, 4, tableLayoutPanel1.RowCount);
                tableLayoutPanel1.Controls.Add(new Label() { Text = p.DataScore.ToString(CultureInfo.CurrentCulture), AutoSize=true }, 5, tableLayoutPanel1.RowCount);
            }
        }        
    }
}
