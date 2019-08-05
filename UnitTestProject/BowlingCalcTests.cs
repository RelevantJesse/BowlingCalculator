using BowlingCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FinalScoreTest()
        {
            BowlingGame bowlingGame = new BowlingGame(1);

            bowlingGame.ScoreFrame(0, 1, 7, 2);
            bowlingGame.ScoreFrame(0, 2, 10);
            bowlingGame.ScoreFrame(0, 3, 10);
            bowlingGame.ScoreFrame(0, 4, 7, 2);
            bowlingGame.ScoreFrame(0, 5, 7, 2);
            bowlingGame.ScoreFrame(0, 6, 7, 2);
            bowlingGame.ScoreFrame(0, 7, 7, 2);
            bowlingGame.ScoreFrame(0, 8, 7, 2);
            bowlingGame.ScoreFrame(0, 9, 7, 2);
            bowlingGame.ScoreFrame(0, 10, 7, 3, 10);

            Assert.AreEqual(129, bowlingGame.GetPlayersScoredGame(0).Where(i => i != -1).Sum());

            bowlingGame = new BowlingGame(1);

            bowlingGame.ScoreFrame(0, 1, 7, 2);
            bowlingGame.ScoreFrame(0, 2, 10);
            bowlingGame.ScoreFrame(0, 3, 10);
            bowlingGame.ScoreFrame(0, 4, 7, 2);
            bowlingGame.ScoreFrame(0, 5, 7, 2);
            bowlingGame.ScoreFrame(0, 6, 7, 3);
            bowlingGame.ScoreFrame(0, 7, 7, 2);
            bowlingGame.ScoreFrame(0, 8, 7, 2);
            bowlingGame.ScoreFrame(0, 9, 7, 2);
            bowlingGame.ScoreFrame(0, 10, 7, 3, 10);

            Assert.AreEqual(137, bowlingGame.GetPlayersScoredGame(0).Where(i => i != -1).Sum());
        }

        [TestMethod]
        public void GetMaxScoreTest()
        {
            BowlingGame bowlingGame = new BowlingGame(1);

            bowlingGame.ScoreFrame(0, 1, 7, 2);
            bowlingGame.ScoreFrame(0, 2, 10);
            bowlingGame.ScoreFrame(0, 3, 10);
            bowlingGame.ScoreFrame(0, 4, 7, 2);

            Assert.AreEqual(244, bowlingGame.GetPlayersMaxScore(0));

            bowlingGame = new BowlingGame(1);

            bowlingGame.ScoreFrame(0, 1, 7, 2);
            bowlingGame.ScoreFrame(0, 2, 10);
            bowlingGame.ScoreFrame(0, 3, 10);
            bowlingGame.ScoreFrame(0, 4, 7, 3);

            Assert.AreEqual(256, bowlingGame.GetPlayersMaxScore(0));
        }
    }
}
