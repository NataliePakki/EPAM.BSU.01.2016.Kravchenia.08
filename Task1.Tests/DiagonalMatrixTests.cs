using System;
using NUnit.Framework;
using Task1.Matrices;

namespace Task1.Tests {
    [TestFixture]
    public class DiagonalMatrixTests{
        private readonly int[] _rightDiogonalElements =  {1,2,3,4};
        private readonly int[][] _rightDiogonalElements2 = { new []{1,0,0}, new[] { 0, 1, 0 }, new[] { 0, 0, 1 } };
        private readonly int[][] _notRightDiogonalElements = { new[] { 1, 5, 0 }, new[] { 0, 1, 0 }, new[] { 0, 0, 1 } };


        [Test]
        public void CreateTest() {
            SquareMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(_rightDiogonalElements); 
        }
        [Test]
        public void CreateTest2(){
            SquareMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(_rightDiogonalElements2);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTest_Exception(){
            SquareMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(_notRightDiogonalElements);
        }


        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetElementTest_Exception(){
            SquareMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(_rightDiogonalElements); 
            diagonalMatrix[5,3] = 3;

        }
        [Test]
        public void SetElementTest() {
            SquareMatrix<int> diogonalSquareMatrix = new DiagonalMatrix<int>(_rightDiogonalElements); 
            diogonalSquareMatrix[0,0] = 3;
        }
        [Test]
        public void GetElementTest(){
            SquareMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(_rightDiogonalElements);
            Assert.AreEqual(diagonalMatrix[2, 2],3);
        }
        [Test]
        public void GetElementTest2(){
            SquareMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(_rightDiogonalElements);
            Assert.AreEqual(diagonalMatrix[1, 2], 0);
        }
    }

}
