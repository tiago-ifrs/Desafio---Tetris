using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public sealed class LabelNome : Label
{
    public int Id { get; set; }
    public LabelNome(int id)
    {
        this.Id = id;
        this.ForeColor = Color.Blue;
        Font = new Font(this.Font, FontStyle.Underline);
        Click += new EventHandler(NomePopup);
        MouseHover += new EventHandler(CursorEvento);
    }
    private void CursorEvento(object sender, EventArgs e)
    {
        ((Control) this).Cursor = Cursors.Hand;
    }
    private void NomePopup(object sender, EventArgs e)
    {
        Pontuacao p;
        AbsPontuacaoDao pd = new PontuacaoDao().AbsPontuacaoDao;
        p = pd.ImagemPorId(Id);

        PictureBox pictureBox = new PictureBox
        {
            AutoSize = true,
            Image = p.Tabuleiro
        };
        Form form = new Form
        {
            AutoSize = true,
            Text = p.Nome + " em " + p.DataScore.ToString(CultureInfo.CurrentCulture),
            TopMost = true
        };
        form.Controls.Add(pictureBox);
        form.ShowDialog();
    }
}
