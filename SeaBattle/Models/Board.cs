using System.Collections.Generic;
using Models.Ships;

namespace Models
{
    public class Board
    {
        public int Size { get; }
        public Square[,] Squares { get; }
        public List<Ship> Ships { get; set; }
        public Board (int size = 10)
        {
            Size = size;
            Ships = new List<Ship>(10);

            Squares = new Square[Size, Size];
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    Squares[i, j] = new Square(this, i, j);
            
        }
        public Square this[Square sq]
        {
            get
            {
                return Squares[sq.X, sq.Y];
            }
        }

        public ShootState CanMove(Move move)
        {
            if (IsMoveVald(move) == false)
                return ShootState.None;

            return this[move.Square].Exterminate();
        }

        internal void ExterminateSquareAroundShip(Ship ship)
        {
            for (int i = 0; i < ship.Squares.Count; i++)
            {
                var shipSqr = ship.Squares[i];
                int x = shipSqr.X;
                int y = shipSqr.Y;

                if (x + 1 < this.Size)
                {
                    this.Squares[x + 1, y].IsExterminate = true;

                    if (y + 1 < this.Size)
                        this.Squares[x + 1, y + 1].IsExterminate = true;
                    
                    if (y - 1 > 0)
                        this.Squares[x + 1, y - 1].IsExterminate = true;
                }

                if (y + 1 < this.Size)
                {
                    this.Squares[x, y + 1].IsExterminate = true;

                    if (x + 1 < this.Size)
                        this.Squares[x + 1, y + 1].IsExterminate = true;
                    if (x - 1 > 0)
                        this.Squares[x - 1, y + 1].IsExterminate = true;

                }

                if (y - 1 >= 0)
                {
                    this.Squares[x, y - 1].IsExterminate = true;

                    if (x + 1 < this.Size)
                        this.Squares[x + 1, y - 1].IsExterminate = true;
                    if (x - 1 > 0)
                        this.Squares[x - 1, y - 1].IsExterminate = true;
                }


                if (x - 1 >= 0)
                {
                    this.Squares[x - 1, y].IsExterminate = true;
                    
                    if (y + 1 < this.Size)
                        this.Squares[x - 1, y + 1].IsExterminate = true;

                    if (y - 1 > 0)
                        this.Squares[x - 1, y - 1].IsExterminate = true;
                }
            }
        }

        public bool IsMoveVald(Move move)
        {
            try
            {
                if (this[move.Square].IsExterminate)
                    return false;

                return true;
            }
            catch { return false; }
        }
    }
}
