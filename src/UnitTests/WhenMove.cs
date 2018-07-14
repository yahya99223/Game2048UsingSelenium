
using Game2048;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WhenMove
    {
        private Board testBoard;
        private Board testBoard2;
        private Board upBoard;
        private Board downBoard;
        private Board rightBoard;
        private Board leftBoard;
        private DecisionAlgorithm algo;
        [SetUp]
        public void Setup()
        {
            algo = new DecisionAlgorithm();
            testBoard = new Board();
            upBoard = new Board();
            leftBoard = new Board();
            rightBoard = new Board();
            downBoard = new Board();
            testBoard2 = new Board();
            testBoard.Cells = new int[,] { { 0, 0, 2, 4 }, { 0, 2, 4, 8 }, { 2, 2, 16, 0 }, { 0, 0, 8, 8 } };
            testBoard2.Cells = new int[,] { { 0, 0, 2, 4 }, { 0, 0, 2, 4 }, { 0, 0, 2, 4 }, { 2, 0, 2, 4 } };
        }
        [Test]
        public void ThenMoveUpCorrectly()
        {
            upBoard.Cells = new int[,] { { 2, 4, 2, 4 }, { 0, 0, 4, 16 }, { 0, 0, 16, 0 }, { 0, 0, 8, 0 } };
            var result =new Board() { Cells = new int[,] { { 2, 0, 4, 8 }, { 0, 0, 4, 8 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } } };
            var result2 = new Board() { Cells = new int[,] { { 2, 0, 8, 16 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } } };
            Assert.IsTrue(compareBorads(algo.Move(testBoard, DecisionAlgorithm.Movement.Up), upBoard));
            Assert.IsTrue(compareBorads(algo.Move(upBoard, DecisionAlgorithm.Movement.Up), upBoard));
            Assert.IsTrue(compareBorads(algo.Move(testBoard2, DecisionAlgorithm.Movement.Up), result));
            Assert.IsTrue(compareBorads(algo.Move(result, DecisionAlgorithm.Movement.Up), result2));
        }
        [Test]
        public void ThenMoveDownCorrectly()
        {
            downBoard.Cells = new int[,] { { 0, 0, 2, 0 }, { 0, 0, 4, 0 }, { 0, 0, 16, 4 }, { 2, 4, 8, 16 } };
            Assert.IsTrue(compareBorads(algo.Move(testBoard, DecisionAlgorithm.Movement.Down), downBoard));
            Assert.IsTrue(compareBorads(algo.Move(downBoard, DecisionAlgorithm.Movement.Down), downBoard));
        }
        [Test]
        public void ThenMoveLeftCorrectly()
        {
            leftBoard.Cells = new int[,] { { 2, 4, 0, 0 }, { 2, 4, 8, 0 }, { 4, 16, 0, 0 }, { 16, 0, 0, 0 } };
            Assert.IsTrue(compareBorads(algo.Move(testBoard, DecisionAlgorithm.Movement.Left), leftBoard));
            Assert.IsTrue(compareBorads(algo.Move(leftBoard, DecisionAlgorithm.Movement.Left), leftBoard));
        }
        [Test]
        public void ThenMoveRightCorrectly()
        {
            rightBoard.Cells = new int[,] { { 0, 0, 2, 4 }, { 0, 2, 4, 8 }, { 0, 0, 4, 16 }, { 0, 0, 0, 16 } };
            Assert.IsTrue(compareBorads(algo.Move(testBoard, DecisionAlgorithm.Movement.Right), rightBoard));
            Assert.IsTrue(compareBorads(algo.Move(rightBoard, DecisionAlgorithm.Movement.Right), rightBoard));
        }

        bool compareBorads(Board board1, Board board2)
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (board1.Cells[row, col] != board2.Cells[row, col])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
