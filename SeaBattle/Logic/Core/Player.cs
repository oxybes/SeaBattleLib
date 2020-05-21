using Models;
using System.Linq;

namespace Logic.Core
{
    public class Player
    {
        public bool IsEnemy { get; set; } = false;
        public Board Board { get; }

        public Player(Board board)
        {
            Board = board;
        }

        public BoardState CheckedBoardState()
        {
            if (Board.Ships.Where(s => s.IsExterminate).Count() == Board.Ships.Count)
                return BoardState.GameOver;

            return BoardState.Normal;
        }

        public ShootState Shoot(Move move)
        {
            return Board.CanMove(move);
        }
    }

    public enum BoardState
    {
        Normal, 
        GameOver
    }
}
