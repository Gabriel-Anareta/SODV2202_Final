using ChessClient.MVVM.ViewModel.Commands;
using ChessModel;

namespace ChessClient.MVVM.View.Controls
{
    public partial class PromotionControl : UserControl
    {
        public RelayCommand AcceptPromotion;
        private PlayerColor _color;
        
        public PromotionControl(PlayerColor color)
        {
            InitializeComponent();
            _color = color;
            pb_Queen.Image = color.GetImage(PieceType.Queen);
            pb_Rook.Image = color.GetImage(PieceType.Rook);
            pb_Knight.Image = color.GetImage(PieceType.Knight);
            pb_Bishop.Image = color.GetImage(PieceType.Bishop);
            pb_Pawn.Image = color.GetImage(PieceType.Pawn);
        }

        private void Piece_Click(object sender, EventArgs e)
        {
            AcceptPromotion.Execute(((PictureBox)sender).Name switch
            {
                "pb_Queen" => new Queen(_color),
                "pb_Rook" => new Rook(_color),
                "pb_Knight" => new Knight(_color),
                "pb_Bishop" => new Bishop(_color),
                "pb_Pawn" => new Pawn(_color)
            });
        }
    }
}
