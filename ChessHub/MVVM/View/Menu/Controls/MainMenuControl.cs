namespace ChessClient.MVVM.View.Menu.Controls
{
    public partial class MainMenuControl : UserControl
    {
        public Action StartClicked { get; set; }
        public Action HelpClicked { get; set; }

        public MainMenuControl()
        {
            InitializeComponent();
            lbl_Start.MouseHover += HighlightText;
            lbl_Help.MouseHover += HighlightText;
            lbl_Start.MouseLeave += UnhighlightText;
            lbl_Help.MouseLeave += UnhighlightText;
        }

        private void HighlightText(object? sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Font = new Font(lbl.Font, FontStyle.Underline);
            lbl.ForeColor = Color.LightBlue;
            Cursor = Cursors.Hand;
        }

        private void UnhighlightText(object? sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Font = new Font(lbl.Font, FontStyle.Regular);
            lbl.ForeColor = Color.FromArgb(254, 254, 254);
            Cursor = Cursors.Default;
        }

        private void lbl_Start_Click(object sender, EventArgs e)
            => StartClicked?.Invoke();

        private void lbl_Help_Click(object sender, EventArgs e)
            => HelpClicked?.Invoke();
    }
}
