using Models;
using System;
using System.Collections.Generic;


namespace Logic.Core
{
    public class Game
    {
        public Player CurrentPlayer { get; private set; }
        public Player Player { get; private set; }
        public Player EnemyPlayer { get; private set; }
        public List<string> Log { get; private set; }

        public Game()
        {
            var BoardPlayer = new Board();
            var BoardEnemy = new Board();

            Player = new Player(BoardPlayer) { IsEnemy = false };
            EnemyPlayer = new Player(BoardEnemy) { IsEnemy = true };

            CurrentPlayer = Player;
            Log = new List<string>();

            Square.LoggingShip += Logger;

            Generator.GeneratorShip.GenerateBoard(Player.Board);
            Generator.GeneratorShip.GenerateBoard(EnemyPlayer.Board);
        }

        public void MakeMove(Move move)
        {
            ShootState shootState;

            if (CurrentPlayer.IsEnemy)
                shootState = Player.Shoot(move);
            else
                shootState = EnemyPlayer.Shoot(move);

             AssignPlayer(shootState);
        }

        private void AssignPlayer(ShootState state)
        {
            if (state == ShootState.Beside)
            {
                if (CurrentPlayer.IsEnemy)
                    CurrentPlayer = Player;
                else
                    CurrentPlayer = EnemyPlayer;
            }
        }

        public GameState CheckedGameState()
        {
            if (EnemyPlayer.CheckedBoardState() == BoardState.GameOver)
                return GameState.Win;
            else if (Player.CheckedBoardState() == BoardState.GameOver)
                return GameState.GameOver;
            else
                return GameState.Game;
        }

        private void Logger(object sender, ShootState state)
        {
            string result = "";
            var sqr = (Square)sender;
            if (sqr.Board == Player.Board)
                result += $"[{DateTime.Now:mm:ss}] Enemy: {state}!";
            else
                result += $"[{DateTime.Now:mm:ss}] Player: {state}!";

            if (Log.Count == 10)
            {
                for (int i = 0; i < Log.Count - 1; i++)
                {
                    Log[i] = Log[i + 1];
                }
                Log[9] = result;
            }

            else
                Log.Add(result);

        }

    }
    public enum GameState
    {
        Win,
        GameOver,
        Game
    }
}
