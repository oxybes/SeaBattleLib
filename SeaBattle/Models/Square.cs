using Models.Ships;
using System;
using System.Linq;

namespace Models
{
    public class Square
    {
        static public event EventHandler<ShootState> LoggingShip;
        public Ship Ship { get; set; }
        public Board Board { get; set; }
        public int X => Coordinate.X;
        public int Y => Coordinate.Y;
        public Coordinate Coordinate;

        public bool IsExterminate { get; set; }

        public Square(Board board, int x, int y)
        {
            Board = board;
            Coordinate = new Coordinate(x, y);
        }

        public Square( int x, int y)
        {
            Board = null;
            Coordinate = new Coordinate(x, y);
        }

        public ShootState Exterminate()
        {
            IsExterminate = true;

            if (Ship != null)
            {

                if (Ship.Squares.Where(s => s.IsExterminate == true).Count() == Ship.Squares.Count)
                {
                    LoggingShip(this, ShootState.Exterminate);
                    Board.ExterminateSquareAroundShip(Ship);
                    return ShootState.Exterminate;
                }
                else
                {
                    LoggingShip(this, ShootState.Got);
                    return ShootState.Got;
                }
            }
            else
            {
                LoggingShip(this, ShootState.Beside);
                return ShootState.Beside;
            }
        }
    }

    public enum ShootState
    {
        Exterminate,
        Got,
        Beside,
        None
    }
}
