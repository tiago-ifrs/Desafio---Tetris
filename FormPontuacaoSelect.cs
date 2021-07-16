using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            List<Pontuacao> lp;
            PontuacaoDAO pd = new PontuacaoDAO();
            lp = pd.ListaTodos();
            bSPontuacao.DataSource = lp;
            dataGridView1.DataSource = bSPontuacao;
        }
    }
}
