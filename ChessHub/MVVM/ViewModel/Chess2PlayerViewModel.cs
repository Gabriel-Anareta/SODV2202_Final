﻿using ChessClient.MVVM.ViewModel.Commands;
using ChessModel;

namespace ChessClient.MVVM.ViewModel
{
    public class Chess2PlayerViewModel : ChessViewModel
    {
        public Chess2PlayerViewModel(PlayerColor color)
        {
            GameState = new GameState2Player(new Board2Player().InitialState(), PlayerColor.White);
            MoveCache = new Dictionary<Position, Move>();
            SelectedPos = null;
            CurrentMove = null;
            ClientColor = color;

            PieceSelectedCommand = new RelayCommand(
                obj => PieceSelected(obj),
                obj => ClientColor == GameState.CurrentPlayer
            );

            PromotionSelected = piece =>
            {
                MenuOnScreen = false;
                ConfirmPromotion.Invoke();
                HandleMove(new PawnPromotion(CurrentMove.From, CurrentMove.To, piece));
            };
        }
    }
}
