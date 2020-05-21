using System.Collections.Generic;
using System.Linq;

namespace Models.Ships
{
    public abstract class Ship
    {
        public List<Square> Squares { get; set; }
        public int Length { get; protected set; }
        public bool IsExterminate => Squares?.Where(sq => sq.IsExterminate).Count() == Length;
        public Direction Direction { get; set; }

        protected Ship(List<Square> squares)
        {
            Squares = squares;
        }

        protected Ship()
        {
            Squares = new List<Square>();
        }

        public void FillSquares(Board board, Square sqr)
        {
            switch (Direction)
            {
                case Direction.Bottom:
                    FillSqrBottom(board, sqr);
                    break;
                case Direction.Left:
                    FillSqrLeft(board, sqr);
                    break;
                case Direction.Right:
                    FillSqrRight(board, sqr);
                    break;
                case Direction.Top:
                    FillSqrTop(board, sqr);
                    break;
            }
        }

        private void FillSqrLeft(Board board, Square sqr)
        {
            for (int i = 0; i < Length; i++)
            {
                Squares.Add(board.Squares[sqr.X - i, sqr.Y]);
                board.Squares[sqr.X - i, sqr.Y].Ship = this;
            }
        }

        private void FillSqrRight(Board board, Square sqr)
        {
            for (int i = 0; i < Length; i++)
            {
                Squares.Add(board.Squares[sqr.X + i, sqr.Y]);
                board.Squares[sqr.X + i, sqr.Y].Ship = this;
            }
        }

        private void FillSqrTop(Board board, Square sqr)
        {
            for (int i = 0; i < Length; i++)
            {
                Squares.Add(board.Squares[sqr.X, sqr.Y + i]);
                board.Squares[sqr.X, sqr.Y + i].Ship = this;
            }
        }

        private void FillSqrBottom(Board board, Square sqr)
        {
            for (int i = 0; i < Length; i++)
            {
                Squares.Add(board.Squares[sqr.X, sqr.Y - i]);
                board.Squares[sqr.X, sqr.Y - i].Ship = this;
            }

        }

    }

    public enum Direction
    {
        Top,
        Bottom,
        Left,
        Right
    }
}
