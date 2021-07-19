using System;
using System.Drawing;
using System.Windows.Forms;

public class LabelNome : Label
{
    public int Id { get; set; }
    public LabelNome(int id)
    {
        this.Id = id;
        this.ForeColor = Color.Blue;
        Font = new Font(this.Font, FontStyle.Underline);
        Click += new EventHandler(nomePopup);
        MouseHover += new EventHandler(cursor);
    }
    private void cursor(object sender, EventArgs e)
    {
        this.Cursor = Cursors.Hand;
    }
    private void nomePopup(object sender, EventArgs e)
    {
        Pontuacao p;
        PontuacaoDAO pd = new PontuacaoDAO();
        p = pd.ImagemPorId(Id);

        PictureBox pictureBox = new PictureBox
        {
            AutoSize = true,
            Image = p.Tabuleiro
        };
        Form form = new Form
        {
            AutoSize = true,
            Text = p.Nome + " em " + p.DataScore.ToString(),
            TopMost = true
        };
        form.Controls.Add(pictureBox);
        form.ShowDialog();
    }
}
