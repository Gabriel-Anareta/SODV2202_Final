using ChessClient.MVVM.View.Menu.Controls;
using ChessClient.MVVM.View.ViewUtils;
using System.Windows.Forms;

namespace ChessClient.MVVM.View.Menu
{
    public partial class MainMenuView : Form
    {
        public Action<BoardType> CreateGame;
        
        private MainMenuControl mainMenuControl;
        private GameCollection gameCollection;
        private Button testButton;

        private int _drawOffset;
        private int _tileSize;

        public MainMenuView()
        {
            InitializeComponent();

            this.ClientSize = new Size(1000, 500);
            this.DoubleBuffered = true;
            this.Paint += DrawBackground;

            Size size = this.ClientSize;
            _tileSize = size.Width / 10;
            _drawOffset = 0;

            mainMenuControl = new MainMenuControl();
            mainMenuControl.StartClicked += OpenGameCollection;
            mainMenuControl.HelpClicked += OpenInfoPage;
            mainMenuControl.Dock = DockStyle.Fill;
            SetEnabled(mainMenuControl, true);

            gameCollection = new GameCollection();
            gameCollection.OptionSelected += CreateGameLobby;
            gameCollection.Left = (this.ClientSize.Width - gameCollection.Width) / 2;
            gameCollection.Top = (this.ClientSize.Height - gameCollection.Height) / 2;
            //gameCollection.Margin = new Padding(50);
            SetEnabled(gameCollection, false);
        }

        private void DrawBackground(object? sender, PaintEventArgs e)
        {
            Size size = this.ClientSize;
            _tileSize = size.Width / 10;
            Color light = Color.FromArgb(0xFF, 0xFF, 0xCF, 0x9F);
            Color Dark = Color.FromArgb(0xFF, 0xD2, 0x8C, 0x45);
            SolidBrush brushWhite = new SolidBrush(light);
            SolidBrush brushBlack = new SolidBrush(Dark);
            for (int file = 0; file < 24; file++)
            {
                for (int rank = 0; rank < 12; rank++)
                {
                    Rectangle rect = new Rectangle();
                    rect.Size = new Size(_tileSize, _tileSize);
                    rect.Location = new Point(size.Width - _tileSize * (file + 1) + _drawOffset, size.Width - _tileSize * (rank + 1) + _drawOffset);
                    if ((file + rank) % 2 == 0)
                        e.Graphics.FillRectangle(brushBlack, rect);
                    else
                        e.Graphics.FillRectangle(brushWhite, rect);
                }
            }
            brushBlack.Dispose();
            brushWhite.Dispose();
        }

        private void MainMenuView_Load(object sender, EventArgs e)
        {
            Controls.Add(mainMenuControl);
            Controls.Add(gameCollection);
            offsetTimer.Start();
        }

        private void OpenInfoPage()
        {
            SetEnabled(mainMenuControl, false);
        }

        private void OpenGameCollection()
        {
            SetEnabled(mainMenuControl, false);
            SetEnabled(gameCollection, true);
        }

        private void CreateGameLobby(BoardType type)
        {
            CreateGame.Invoke(type);
        }

        private void offsetTimer_Tick(object sender, EventArgs e)
        {
            _drawOffset = _drawOffset != _tileSize ? _drawOffset + 1 : 0;
            this.Refresh();
        }

        private void SetEnabled(Control control, bool state)
        {
            control.Enabled = state;
            control.Visible = state;
        }
    }
}
