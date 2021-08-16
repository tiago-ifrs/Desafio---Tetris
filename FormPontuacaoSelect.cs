using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Desafio___Tetris
{
    public partial class FormPontuacaoSelect : Form
    {
        public FormPontuacaoSelect()
        {
            InitializeComponent();
        }

        private void FormScore_Load(object sender, EventArgs e)
        {
            AbsPontuacaoDao pd = new PontuacaoDao().AbsPontuacaoDao;
            List<Pontuacao> lp = pd.ListaTodos();
            bSPontuacao.DataSource = lp;
            dataGridView1.DataSource = bSPontuacao;
        }
    }
}
