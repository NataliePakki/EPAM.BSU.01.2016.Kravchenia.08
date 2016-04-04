using System;
using NUnit.Framework;
using Task1.Matrices;
using Task1.Validator;

namespace Task1.Tests {
    [TestFixture]
    public class DiagonalMatrixTests{
        private readonly int[][] _rightDiogonalElements = {new[] {1,0,0}, new[] {0,1,0}, new[] {0,0,3}};
        private readonly int[][] _rightDiogonalElements2 = { new[] { 4, 0, 0 }, new[] { 0, 6, 0 }, new[] { 0, 0, 7 } };
        private readonly int[][] _notRightDiogonalElements = {new[] {1, 5, 0}, new[] {0, 1, 0}, new[] {0, 0, 3}};
        private readonly int[][] _notRightElements = { new[] { 1, 5 }, new[] { 0, 1, 0 }, new[] { 0, 0, 3 } };
        private class TestValidator : IValidatorMatrix<int> {
            public bool IsValid(int[][] elements) {
                for(int i = 0; i < elements.Length; i++)
                    for(int j = 0; j < elements[i].Length; j++)
                        if (i == j && elements[i][j] < 3)
                            return false;
                return true;
            }
            public string Message => "Elements must more then 3";
        }

        [Test]
        public void CreateTest() {
            Matrix<int> diagonalMatrix = new DiagonalMatrix<int>(_rightDiogonalElements); 
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTest_Exception1() {
            Matrix<int> diagonalMatrix = new DiagonalMatrix<int>(_notRightDiogonalElements);  
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTest_Exception2() {
            Matrix<int> diagonalMatrix = new DiagonalMatrix<int>(_notRightElements); 
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTest_TestValidator_Exception() {
            Matrix<int> diogonalMatrix = new DiagonalMatrix<int>(_rightDiogonalElements,
                new ValidatorList<int>() { new TestValidator() });
        }
        [Test]
        public void CreateTest_TestValidator() {
            Matrix<int> diagonalMatrix = new DiagonalMatrix<int>(_rightDiogonalElements2,
                new ValidatorList<int>() { new TestValidator() });
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetElementTest_Exception(){
            Matrix<int> diogonalMatrix = new DiagonalMatrix<int>(_rightDiogonalElements); 
            diogonalMatrix.SetElement(3, 3, 3);

        }
        [Test]
        public void SetElementTest() {
            Matrix<int> diogonalMatrix = new DiagonalMatrix<int>(_rightDiogonalElements); 
            diogonalMatrix.SetElement(0, 0, 3);
        }
    }

}
