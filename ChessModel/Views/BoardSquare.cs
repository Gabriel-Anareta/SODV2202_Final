using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ChessModel.Views
{
    public partial class BoardSquare : UserControl
    {
        public ICommand Command { get; set; }

        public BoardSquare(BindingSource source)
        {
            InitializeComponent();
            pb_Img.DataBindings.Add("Image", source, "Image", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void pb_Img_Click(object sender, EventArgs e)
        {
            Command.Execute(this);
        }
    }
}
