using Desafio___Tetris;
using System.Windows.Forms;

public class Tela
{
    public int Larg { get; }
    public int Alt { get; }
    public Panel LayoutPanel { get; }
    public Tela(Panel layoutPanel)
	{
        this.LayoutPanel = layoutPanel;
        this.Larg = layoutPanel.Width;
        this.Alt = layoutPanel.Height;
    }
}
