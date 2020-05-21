using Colorful;
using Logic.Core;
using Logic.Core.Generator;
using System;
using System.Drawing;
using System.Threading;
using Console = Colorful.Console;

namespace SeaBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var game = new Logic.Core.Game();
            var gameState = game.CheckedGameState();
            var styleSheet = CreateStyleSheet();

            while (gameState == GameState.Game)
            {
                Console.Clear();
                Console.WriteLineStyled(DrawBoard.Draw(game), styleSheet);

                if (game.CurrentPlayer.IsEnemy)
                {
                    Thread.Sleep(1000);
                    game.MakeMove(GeneratorBot.GeneratedMove(game.Player.Board));
                }
                else
                    game.MakeMove(GameInput.DoMove());
            }


            System.Console.WriteLine(gameState);
            Console.ReadLine();

        }

        private static StyleSheet CreateStyleSheet()
        {
            StyleSheet styleSheet = new StyleSheet(Color.Gray);
            styleSheet.AddStyle("X", Color.Red);
            styleSheet.AddStyle("K", Color.White);

            return styleSheet;
        }
    }
}
