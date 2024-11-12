using ChessClient.MVVM.ViewModel.Commands;
using ChessModel;

namespace ChessClient.MVVM.View.Controls
{
    public partial class PromotionControl : UserControl
    {
        public Action<PieceType> AcceptPromotion;
        private PlayerColor _color;
        
        public PromotionControl(PlayerColor color, Action<PieceType> command)
        {
            InitializeComponent();
            AcceptPromotion = command;
            _color = color;
            pb_Queen.Image = color.GetImage(PieceType.Queen);
            pb_Rook.Image = color.GetImage(PieceType.Rook);
            pb_Knight.Image = color.GetImage(PieceType.Knight);
            pb_Bishop.Image = color.GetImage(PieceType.Bishop);
            pb_Pawn.Image = color.GetImage(PieceType.Pawn);
        }

        private void Piece_Click(object sender, EventArgs e)
        {
            PieceType type = ((PictureBox)sender).Name switch
            {
                "pb_Queen" => PieceType.Queen,
                "pb_Rook" => PieceType.Rook,
                "pb_Knight" => PieceType.Knight,
                "pb_Bishop" => PieceType.Bishop,
                "pb_Pawn" => PieceType.Pawn
            };
            AcceptPromotion.Invoke(type);
        }
    }
}
