using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace ChessModel
{
    public class PlayerState
    {
        public int Score { get; set; }
        public bool IsInPlay { get; set; }

        public PlayerState()
        {
            Score = 0;
            IsInPlay = true;
        }
    }
}
