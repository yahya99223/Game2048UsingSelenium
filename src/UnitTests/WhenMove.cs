using Game2048;
using NUnit.Framework;
using Shared.Core;

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
            Assert.IsTrue(compareBorads(algo.Play(testBoard, MovementDirection.Up), upBoard));
            Assert.IsTrue(compareBorads(algo.Play(upBoard, MovementDirection.Up), upBoard));
            Assert.IsTrue(compareBorads(algo.Play(testBoard2, MovementDirection.Up), result));
            Assert.IsTrue(compareBorads(algo.Play(result, MovementDirection.Up), result2));
        }
        [Test]
        public void ThenMoveDownCorrectly()
        {
            downBoard.Cells = new int[,] { { 0, 0, 2, 0 }, { 0, 0, 4, 0 }, { 0, 0, 16, 4 }, { 2, 4, 8, 16 } };
            Assert.IsTrue(compareBorads(algo.Play(testBoard, MovementDirection.Down), downBoard));
            Assert.IsTrue(compareBorads(algo.Play(downBoard, MovementDirection.Down), downBoard));
        }
        [Test]
        public void ThenMoveLeftCorrectly()
        {
            leftBoard.Cells = new int[,] { { 2, 4, 0, 0 }, { 2, 4, 8, 0 }, { 4, 16, 0, 0 }, { 16, 0, 0, 0 } };
            Assert.IsTrue(compareBorads(algo.Play(testBoard, MovementDirection.Left), leftBoard));
            Assert.IsTrue(compareBorads(algo.Play(leftBoard, MovementDirection.Left), leftBoard));
        }
        [Test]
        public void ThenMoveRightCorrectly()
        {
            rightBoard.Cells = new int[,] { { 0, 0, 2, 4 }, { 0, 2, 4, 8 }, { 0, 0, 4, 16 }, { 0, 0, 0, 16 } };
            Assert.IsTrue(compareBorads(algo.Play(testBoard, MovementDirection.Right), rightBoard));
            Assert.IsTrue(compareBorads(algo.Play(rightBoard, MovementDirection.Right), rightBoard));
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
