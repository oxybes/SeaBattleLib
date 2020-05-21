using Models;
using Models.Ships;
using System;
using System.Linq;

namespace Logic.Core.Generator
{
    public class GeneratorBot
    {
        
        static Random rnd = new Random();

        public static Move GeneratedMove(Board board)
        {
            
            Move move = null;
            bool moveValid = false;

            var exterminatedSquares = (from ship in board.Ships
                                       from squareShip in ship.Squares
                                       where squareShip.IsExterminate == true && ship.IsExterminate == false
                                       select squareShip).ToList();

            if (exterminatedSquares == null || exterminatedSquares?.Count == 0)
            {
                 
                do
                {
                    move = new Move(new Coordinate(
                                                       rnd.Next(0, board.Size), rnd.Next(0, board.Size)));

                    moveValid = board.IsMoveVald(move);
                }
                while (moveValid == false);

                return move;
            }

            if (exterminatedSquares.Count == 1)
            {

                do
                {
                    move = GetRandomMoveWithOneSquare(exterminatedSquares[0]);
                    moveValid = board.IsMoveVald(move);
                    
                }
                while (moveValid == false);

                return move;
            }

            if (exterminatedSquares[0].Ship.Direction == Direction.Bottom ||
                exterminatedSquares[0].Ship.Direction == Direction.Top)
            {
                var sqrMin = (from sqr in exterminatedSquares
                              where sqr.Y == exterminatedSquares.Min(s => s.Y)
                              select sqr).FirstOrDefault();

                var sqrMax = (from sqr in exterminatedSquares
                              where sqr.Y == exterminatedSquares.Max(s => s.Y)
                              select sqr).FirstOrDefault();


                do
                {
                    var numb = rnd.Next(0, 2);

                    if (numb == 0)
                    {
                        move = new Move(new Coordinate(sqrMin.X, sqrMin.Y - 1));

                    }
                    else
                    {
                        move = new Move(new Coordinate(sqrMax.X, sqrMax.Y + 1));
                    }

                    moveValid = board.IsMoveVald(move);
                }
                while (moveValid == false);

                return move;
            }

            else
            {
                var sqrMin = (from sqr in exterminatedSquares
                              where sqr.X == exterminatedSquares.Min(s => s.X)
                              select sqr).FirstOrDefault();

                var sqrMax = (from sqr in exterminatedSquares
                              where sqr.X == exterminatedSquares.Max(s => s.X)
                              select sqr).FirstOrDefault();


                do
                {
                    var numb = rnd.Next(0, 2);

                    if (numb == 0)
                    {
                        move = new Move(new Coordinate(sqrMin.X - 1, sqrMin.Y));

                    }
                    else
                    {
                        move = new Move(new Coordinate(sqrMax.X + 1, sqrMax.Y));
                    }

                    moveValid = board.IsMoveVald(move);
                }
                while (moveValid == false);

                return move;
            }


        }

        private static Move GetRandomMoveWithOneSquare(Square square)
        {
            var numb = rnd.Next(0, 4);

            if (numb == 0)
                return new Move(new Coordinate(square.X + 1, square.Y));
            else if (numb == 1)
                return new Move(new Coordinate(square.X - 1, square.Y));
            else if (numb == 2)
                return new Move(new Coordinate(square.X, square.Y + 1));
            else
                return new Move(new Coordinate(square.X, square.Y - 1));
        }
    }
}
