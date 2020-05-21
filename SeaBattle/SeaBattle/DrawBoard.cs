using Models;
using System;
using System.Collections.Generic;

namespace SeaBattle
{
    public static class DrawBoard
    {
        public static string Draw(Logic.Core.Game game)
        {
            string result = "";

            DrawLogo(ref result);
            DrawName(ref result);
            DrawMarking(ref result, game.Player.Board);
            DrawField(ref result, game.Player.Board, game.EnemyPlayer.Board, game.Log);
           
            return result;
        }

        private static void DrawName(ref string result)
        {
            result += "\n";
            result += "          Player                               Enemy";
            result += "\n";
            result += "\n";
        }

        private static void DrawRow(Board board, Coordinate coord, ref string result, bool isEnemy = false)
        {
            var sq = board.Squares[coord.X, coord.Y];

            if (sq.Ship != null && sq.IsExterminate == false && isEnemy == true)
                result += "☐";
            else if (sq.Ship == null && sq.IsExterminate == false)
                result += "☐";
            else if (sq.Ship != null && sq.IsExterminate == false)
                result += "K";
            else if (sq.Ship == null && sq.IsExterminate == true)
                result += ".";
            else
                result += "X";

            result += " ";
            
        }

        private static void DrawMarking(ref string result, Board board)
        {
            result += "    ";
            for (int i = 0; i < board.Size; i++)
            {
                result += i + " ";
            }

            result += "               ";

            for (int i = 0; i < board.Size; i++)
            {
                result += i + " ";
            }

            result += "                   Лог:";
            result += "\n";
        }

        private static void DrawLogo(ref string result)
        {
            result += "                ";
            result += @"
░██████╗███████╗░█████╗░  ██████╗░░█████╗░████████╗████████╗██╗░░░░░███████╗
██╔════╝██╔════╝██╔══██╗  ██╔══██╗██╔══██╗╚══██╔══╝╚══██╔══╝██║░░░░░██╔════╝
╚█████╗░█████╗░░███████║  ██████╦╝███████║░░░██║░░░░░░██║░░░██║░░░░░█████╗░░
░╚═══██╗██╔══╝░░██╔══██║  ██╔══██╗██╔══██║░░░██║░░░░░░██║░░░██║░░░░░██╔══╝░░
██████╔╝███████╗██║░░██║  ██████╦╝██║░░██║░░░██║░░░░░░██║░░░███████╗███████╗
╚═════╝░╚══════╝╚═╝░░╚═╝  ╚═════╝░╚═╝░░╚═╝░░░╚═╝░░░░░░╚═╝░░░╚══════╝╚══════╝";
            result += "\n\n\n\n";
        }

        private static void DrawField(ref string result, Board playerBoard, Board enemyBoard, List<string> log)
        {
            for (int i = 0; i < playerBoard.Size; i++)
            {

                result += "|" + Convert.ToChar(i + 65) + "| ";

                for (int j = 0; j < playerBoard.Size; j++)
                {
                    DrawRow(playerBoard, new Coordinate(i, j), ref result);
                }

                result += "           ";

                result += "|" + Convert.ToChar(i + 65) + "| ";

                for (int j = 0; j < enemyBoard.Size; j++)
                {
                    DrawRow(enemyBoard, new Coordinate(i, j), ref result, true);
                }

                DrawLog(ref result, log, i);

                result += "\n";
            }
        }

        private static void DrawLog(ref string result, List<string> log, int index)
        {
            result += "                       ";

            if (index >= log.Count)
                return;

            result += log[index];
        }
    }
}
