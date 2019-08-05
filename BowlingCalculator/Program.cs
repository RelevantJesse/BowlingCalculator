using System;
using System.Linq;

namespace BowlingCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            BowlingGame bowlingGame = new BowlingGame(1);

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

            Console.WriteLine($"Final score: {bowlingGame.GetPlayersScoredGame(0).Where(i => i != -1).Sum()}");
        }


    }
}
