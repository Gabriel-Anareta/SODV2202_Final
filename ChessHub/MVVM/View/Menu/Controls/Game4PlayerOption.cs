using ChessClient.MVVM.View.ViewUtils;
using ChessModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessClient.MVVM.View.Menu.Controls
{
    public partial class Game4PlayerOption : UserControl
    {
        public Action<BoardType> Selected { get; set; }

        public Game4PlayerOption()
        {
            InitializeComponent();

            lbl_Title.MouseEnter += lbl_Title_MouseEnter;
            lbl_Title.MouseLeave += lbl_Title_MouseLeave;
            this.DoubleBuffered = true;
        }

        private void lbl_Title_MouseEnter(object? sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            lbl_Title.Font = new Font(lbl_Title.Font, FontStyle.Underline | FontStyle.Bold);
        }

        private void lbl_Title_MouseLeave(object? sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            lbl_Title.Font = new Font(lbl_Title.Font, FontStyle.Bold);
        }

        private void panel_BoardDisplay_Paint(object sender, PaintEventArgs e)
        {
            Size size = ((Panel)sender).Size;
            int tileSize = size.Width / 14;
            Color light = Color.FromArgb(0xFF, 0xFF, 0xCF, 0x9F);
            Color Dark = Color.FromArgb(0xFF, 0xD2, 0x8C, 0x45);
            SolidBrush brushWhite = new SolidBrush(light);
            SolidBrush brushBlack = new SolidBrush(Dark);
            for (int file = 0; file < 14; file++)
            {
                for (int rank = 0; rank < 14; rank++)
                {
                    Rectangle rect = new Rectangle();
                    rect.Size = new Size(tileSize, tileSize);
                    rect.Location = new Point(size.Width - tileSize * (file + 1), size.Width - tileSize * (rank + 1));

                    if (PositionInDeadSpace(file, rank))
                        continue;

                    if ((file + rank) % 2 == 0)
                        e.Graphics.FillRectangle(brushBlack, rect);
                    else
                        e.Graphics.FillRectangle(brushWhite, rect);
                }
            }
            brushBlack.Dispose();
            brushWhite.Dispose();
        }

        private bool PositionInDeadSpace(int file, int rank)
        {
            if (NumInRange(file, 0, 2) || NumInRange(file, 11, 13))
                if (NumInRange(rank, 0, 2) || NumInRange(rank, 11, 13))
                    return true;

            return false;
        }

        private bool NumInRange(int num, int checkLeft, int checkRight)
            => num >= checkLeft && num <= checkRight;

        private void lbl_Title_Click(object sender, EventArgs e)
            => Selected.Invoke(BoardType.Board4Player);
    }
}
