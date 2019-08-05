using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingCalculator
{
    public class BowlingGame
    {
        public int[][][] GameScores { get; set; }

        public BowlingGame(int numberOfPlayers)
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
            int[] playersScoredGame = new int[10];

            for (int i = 0; i < 10; i++)
            {
                playersScoredGame[i] = ScoreFrame(GameScores[playerNumber], i + 1);
            }

            return playersScoredGame;
        }

        public int ScoreFrame(int[][] playerGame, int frame)
        {
            int[] frameScores = playerGame[frame - 1];
            int frameScore;

            if (frame != 10)
            {
                if (frameScores[0] == 10)
                {
                    //strike
                    if (frame != 9)
                    {
                        if (playerGame[frame][0] != 10)
                        {
                            frameScore = 10 + playerGame[frame].Where(i => i != -1).Sum();
                        }
                        else
                        {
                            frameScore = 20 + playerGame[frame + 1][0];
                        }
                    }
                    else
                    {
                        frameScore = frameScores.Where(i => i != -1).Sum() + playerGame[9][0] + playerGame[9][1];
                    }
                }
                else if (frameScores.Where(i => i != -1).Sum() == 10)
                {
                    //Spare case

                    // Add the value of the first ball of player's next frame
                    frameScore = frameScores.Where(i => i != -1).Sum() + playerGame[frame][0];
                }
                else
                {
                    frameScore = frameScores.Where(i => i != -1).Sum();
                }
            }
            else
            {
                // 10th frame

                frameScore = playerGame[frame - 1].Where(i => i != -1).Sum();
            }

            return frameScore;
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
                else if (playerGame[i][0] == 10 && ((i != 9 && playerGame[i + 1][0] == -1) || (i < 8 && playerGame[i + 1][0] == 10 && playerGame[i + 2][0] == -1)))
                {
                    maxScore += 30;
                }
                else if(playerGame[i][0] != 10 && playerGame[i][0] + playerGame[i][1] == 10 && i < 9 && playerGame[i+1][0] == -1)
                {
                    maxScore += 20;
                }
                else
                {
                    maxScore += ScoreFrame(playerGame, i + 1);
                }
            }

            return maxScore;
        }
    }
}
