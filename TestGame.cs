using Game1;

namespace TestsGame1
{
    [TestClass]
    public class TestScore
    {

        [TestMethod]
        public void IncreaseScore_IncreaseScoreBy10_Plus10Return()
        {
            Score score = new Score();

            score.IncreaseScore(10);

            Assert.AreEqual(10, score.ScoreSnake);
        }

        [TestMethod]
        public void IncreaseScore_IncreaseScoreBy5_Plus5IsNotValueIncreaseScore()
        {

            Score score = new Score();

            score.IncreaseScore(10);

            Assert.AreNotEqual(5, score.ScoreSnake);
        }
    }

    [TestClass]
    public class TestDirection
    {
        [TestMethod]
        public void Enum_DirectionInside_TrueReturn()
        {
            Assert.IsTrue(Enum.IsDefined(typeof(Direction), Direction.LEFT));
            Assert.IsTrue(Enum.IsDefined(typeof(Direction), Direction.RIGHT));
            Assert.IsTrue(Enum.IsDefined(typeof(Direction), Direction.UP));
            Assert.IsTrue(Enum.IsDefined(typeof(Direction), Direction.DOWN));
        }
    }
    [TestClass]
    public class TestDot
    {
        [TestMethod]
        public void Compare_2Dot_IsEquality()
        {
            int x = 10;
            int y = 20;

            Dot dot1 = new Dot(x, y, 'A');
            Dot dot2 = new Dot(x, y, 'A');

            Assert.AreEqual(dot1, dot2);
        }

        [TestMethod]
        public void Compare_2Dot_IsNotEquality()
        {
            int x1 = 10;
            int y1 = 20;

            int x2 = 22;
            int y2 = 23;

            Dot dot1 = new Dot(x1, y1, 'A');
            Dot dot2 = new Dot(x2, y2, 'A');

            Assert.AreNotEqual(dot1, dot2);
        }
    }
}