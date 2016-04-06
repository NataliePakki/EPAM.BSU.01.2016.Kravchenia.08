using System;
using NUnit.Framework;
using Task1.Matrices;

namespace Task1.Tests{
    [TestFixture]
    public class SquareMatrixTests {
        private readonly int[][] _rightSquareElements = { new[] { 1, 45, 5 }, new[] { 4, 6, 7 }, new[] { 7, 8, 3 } };

        [Test]
        public void CreateTest() {
            SquareMatrix<int> squareSquareMatrix = new SquareMatrix<int>(_rightSquareElements);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetElementTest_Exception() {
            SquareMatrix<int> squareSquareMatrix = new SquareMatrix<int>(_rightSquareElements);
            squareSquareMatrix[4,1] = 3;

        }
        [Test]
        public void SetElementTest() {
            SquareMatrix<int> squareSquareMatrix = new SquareMatrix<int>(_rightSquareElements);
            squareSquareMatrix[0,0] = 3;
        }
        [Test]
        public void GetElementTest() {
            SquareMatrix<int> squareSquareMatrix = new SquareMatrix<int>(_rightSquareElements);
            Assert.AreEqual(squareSquareMatrix[1, 1],6);
        }

    }
}
