using Models;
using Models.Ships;
using System;

namespace Logic.Core.Generator
{
    public static class RuleGeneratorShip
    {
        public static bool CanPlaceShip(Board board, Ship ship, Direction dir, Square square)
        {
            if (board == null || ship == null || square == null)
                return false;

            switch (dir)
            {
                case Direction.Bottom:
                    return CanGenerateBottom(board,ship, square);
                case Direction.Left:
                    return CanGenerateLeft(board, ship, square);
                case Direction.Right:
                    return CanGenerateRight(board, ship, square);
                case Direction.Top:
                    return CanGenerateTop(board, ship, square);
            }

            return false;
        }

        private static bool CanGenerateTop(Board board, Ship ship, Square square)
        {
            // Проверка на то, что корабль не попадает на клетки, в которых уже стоят корабли
            try
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    if (board.Squares[square.X, square.Y + i].Ship != null)
                        return false;
                }
            }
            catch(IndexOutOfRangeException)
            {
                return false;
            }

            // Проверка на то, что корабль выдерживает расстояние между кораблями в 1 клетку
            for (int i = -1; i <= ship.Length; i++)
            {
                for (int j = -1; j <=1; j++)
                {
                    try
                    {
                        if (board.Squares[square.X + j, square.Y + i].Ship != null)
                            return false;
                    }
                    catch(IndexOutOfRangeException) { continue; }
                }
            }

            return true;
        }

        private static  bool CanGenerateRight(Board board, Ship ship, Square square)
        {
            // Проверка на то, что корабль не попадает на клетки, в которых уже стоят корабли
            try
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    if (board.Squares[square.X + i, square.Y].Ship != null)
                        return false;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }

            // Проверка на то, что корабль выдерживает расстояние между кораблями в 1 клетку
            for (int i = -1; i <= ship.Length; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    try
                    {
                        if (board.Squares[square.X + i, square.Y + j].Ship != null)
                            return false;
                    }
                    catch (IndexOutOfRangeException) { continue; }
                }
            }

            return true;
        }

        private static  bool CanGenerateLeft(Board board, Ship ship, Square square)
        {
            // Проверка на то, что корабль не попадает на клетки, в которых уже стоят корабли
            try
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    if (board.Squares[square.X - i, square.Y].Ship != null)
                        return false;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }

            // Проверка на то, что корабль выдерживает расстояние между кораблями в 1 клетку
            for (int i = -1; i <= ship.Length; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    try
                    {
                        if (board.Squares[square.X - i, square.Y + j].Ship != null)
                            return false;
                    }
                    catch (IndexOutOfRangeException) { continue; }
                }
            }

            return true;
        }

        private static bool CanGenerateBottom(Board board, Ship ship, Square square)
        {
            // Проверка на то, что корабль не попадает на клетки, в которых уже стоят корабли
            try
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    if (board.Squares[square.X, square.Y - i].Ship != null)
                        return false;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }

            // Проверка на то, что корабль выдерживает расстояние между кораблями в 1 клетку
            for (int i = -1; i <= ship.Length; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    try
                    {
                        if (board.Squares[square.X + j, square.Y - i].Ship != null)
                            return false;
                    }
                    catch (IndexOutOfRangeException) { continue; }
                }
            }

            return true;
        }
    }

    
}
