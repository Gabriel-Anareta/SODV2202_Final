using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessClient.MVVM.View.Boards.Controls
{
    public partial class GameOverControl : UserControl
    {
        public GameOverControl()
        {
            InitializeComponent();
        }

        public void SetTitleMessage(string message)
            => lbl_GameOver.Text = message;

        public void SetDetailsMessage(string message)
            => lbl_EndDetails.Text = message;
    }
}
