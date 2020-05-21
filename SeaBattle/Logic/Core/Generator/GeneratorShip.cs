using Models;
using Models.Ships;
using System;

namespace Logic.Core.Generator
{
    public class GeneratorShip
    {
        static Random rnd = new Random();

        public static void GenerateBoard(Board board)
        {
            GenerateShipFour(board, 1);
            GenerateShipThree(board, 2);
            GenerateShipTwo(board, 3);
            GenerateShipOne(board, 4);
        }

        private static void GenerateShipOne(Board board, int count)
        {
            for (int i = 0; i < count; i++)
            {
                while (true)
                {
                    Direction dir = GetRandomDirection();
                    Square sqr = GetRandomSquare(board.Size);
                    ShipOne ship = new ShipOne();

                    if (RuleGeneratorShip.CanPlaceShip(board, ship, dir, sqr))
                    {
                        ship.Direction = dir;
                        board.Ships.Add(ship);
                        board[sqr].Ship = ship;
                        ship.FillSquares(board, sqr);
                        break;
                    }
                }
            }
        }

        private static void GenerateShipTwo(Board board, int count)
        {
            for (int i = 0; i < count; i++)
            {
                while (true)
                {
                    Direction dir = GetRandomDirection();
                    Square sqr = GetRandomSquare(board.Size);
                    ShipTwo ship = new ShipTwo();

                    if (RuleGeneratorShip.CanPlaceShip(board, ship, dir, sqr))
                    {
                        ship.Direction = dir;
                        board.Ships.Add(ship);
                        board[sqr].Ship = ship;
                        ship.FillSquares(board, sqr);
                        break;
                    }
                }
            }
        }

        private static void GenerateShipThree(Board board, int count)
        {
            for (int i = 0; i < count; i++)
            {
                while (true)
                {
                    Direction dir = GetRandomDirection();
                    Square sqr = GetRandomSquare(board.Size);
                    ShipThree ship = new ShipThree();

                    if (RuleGeneratorShip.CanPlaceShip(board, ship, dir, sqr))
                    {
                        ship.Direction = dir;
                        board.Ships.Add(ship);
                        board[sqr].Ship = ship;
                        ship.FillSquares(board, sqr);
                        break;
                    }
                }
            }
        }

        private static void GenerateShipFour(Board board, int count)
        {
            for (int i = 0; i < count; i++)
            {
                while (true)
                {
                    Direction dir = GetRandomDirection();
                    Square sqr = GetRandomSquare(board.Size);
                    ShipFour ship = new ShipFour();

                    if (RuleGeneratorShip.CanPlaceShip(board, ship, dir, sqr))
                    {
                        ship.Direction = dir;
                        board.Ships.Add(ship);
                        board[sqr].Ship = ship;
                        ship.FillSquares(board, sqr);
                        break;
                    }
                }
            }
        }

        private static Direction GetRandomDirection()
        {
            int x = rnd.Next(0, 4);
            switch(x)
            {
                case 0:
                    return Direction.Bottom;
                case 1:
                    return Direction.Left;
                case 2:
                    return Direction.Right;
                case 3:
                    return Direction.Top;
            }

            return Direction.Top;
                
        }
        private static Square GetRandomSquare(int size)
        {
            int x = rnd.Next(0, size);
            int y = rnd.Next(0, size);

            return new Square(x, y);
        }
    }
}
