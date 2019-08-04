using System;
using System.Linq;

namespace BowlingCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Game bowlingGame = new Game(1);

            bowlingGame.ScoreFrame(0, 1, 7, 2);
            Console.WriteLine(bowlingGame.GetPlayersMaxScore(0));
            bowlingGame.ScoreFrame(0, 2, 10);
            Console.WriteLine(bowlingGame.GetPlayersMaxScore(0));
            bowlingGame.ScoreFrame(0, 3, 10);
            Console.WriteLine(bowlingGame.GetPlayersMaxScore(0));
            bowlingGame.ScoreFrame(0, 4, 7, 2);
            Console.WriteLine(bowlingGame.GetPlayersMaxScore(0));
            bowlingGame.ScoreFrame(0, 5, 7, 2);
            Console.WriteLine(bowlingGame.GetPlayersMaxScore(0));
            bowlingGame.ScoreFrame(0, 6, 7, 2);
            Console.WriteLine(bowlingGame.GetPlayersMaxScore(0));
            bowlingGame.ScoreFrame(0, 7, 7, 2);
            Console.WriteLine(bowlingGame.GetPlayersMaxScore(0));
            bowlingGame.ScoreFrame(0, 8, 7, 2);
            Console.WriteLine(bowlingGame.GetPlayersMaxScore(0));
            bowlingGame.ScoreFrame(0, 9, 7, 2);
            Console.WriteLine(bowlingGame.GetPlayersMaxScore(0));
            bowlingGame.ScoreFrame(0, 10, 7, 3, 10);
            Console.WriteLine(bowlingGame.GetPlayersMaxScore(0));

            Console.WriteLine($"Final score: {bowlingGame.GetPlayersScoredGame(0).Sum()}");
        }


    }

    class Game
    {
        public int[][][] GameScores { get; set; }

        public Game(int numberOfPlayers)
        {
            GameScores = new int[numberOfPlayers][][];

            // Give all players 10 frames
            for (int i = 0; i < numberOfPlayers; i++)
            {
                GameScores[i] = new int[10][];

                //initialize game to -1
                for (int j = 0; j < 10; j++)
                {
                    GameScores[i][j] = new int[3];
                    GameScores[i][j][0] = -1;                    
                }

                GameScores[i][9][2] = -1;
            }
        }

        public void ScoreFrame(int playerNumber, int frameNumber, int firstBall, int? secondBall = null, int? thirdBall = null)
        {
            //subtract 1 to make it 0-based
            frameNumber--;
            
            GameScores[playerNumber][frameNumber][0] = firstBall;

            if (secondBall != null)
                GameScores[playerNumber][frameNumber][1] = Convert.ToInt32(secondBall);

            if (thirdBall != null)
                GameScores[playerNumber][frameNumber][2] = Convert.ToInt32(thirdBall);
        }

        public int[] GetPlayersScoredGame(int playerNumber)
        {
            int[][] playerGame = GameScores[playerNumber];
            int[] playersScoredGame = new int[10];

            for (int i = 0; i < 10; i++)
            {
                int[] frameScores = playerGame[i];

                if (i != 9)
                {
                    if (frameScores[0] == 10)
                    {
                        //strike
                        if (i != 8)
                        {
                            if (playerGame[i + 1][0] != 10)
                            {
                                playersScoredGame[i] = frameScores.Sum() + playerGame[i + 1][0] + playerGame[i + 1][1];
                            }
                            else
                            {
                                playersScoredGame[i] = frameScores.Sum() + playerGame[i + 1][0] + playerGame[i + 2][0];
                            }
                        }
                        else
                        {
                            playersScoredGame[i] = frameScores.Sum() + playerGame[9][0] + playerGame[9][1];
                        }
                    }
                    else if (frameScores.Sum() == 10)
                    {
                        //Spare case

                        // Add the value of the first ball of player's next frame
                        playersScoredGame[i] = frameScores.Sum() + playerGame[i + 1][0];
                    }
                    else
                    {
                        playersScoredGame[i] = frameScores.Sum();
                    }
                }
                else
                {
                    playersScoredGame[i] = frameScores.Sum();
                }
            }

            return playersScoredGame;
        }

        public int GetPlayersMaxScore(int playerNumber)
        {
            int[][] playerGame = GameScores[playerNumber];

            int maxScore = 0;

            for (int i = 0; i < 10; i++)
            {
                if (playerGame[i][0] == -1)
                {
                    maxScore += 30;
                }
                else if (playerGame[i][0] == 10 && i != 9 && playerGame[i+1][0] == -1)
                {
                    maxScore += 30;
                }
                else if (playerGame[i][0] + playerGame[i][1] == 10 && (i != 9 || playerGame[9][2] == -1))
                {
                    maxScore += 20;
                }
                else
                {
                    maxScore += playerGame[i].Sum();
                }
            }

            return maxScore;
        }
    }
}
