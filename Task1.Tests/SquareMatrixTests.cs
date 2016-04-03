using System;
using System.Linq;
using NUnit.Framework;
using Task1.Matrices;
using Task1.Validator;

namespace Task1.Tests{
    [TestFixture]
    public class SquareMatrixTests {
        private readonly int[][] _rightSquareElements = { new[] { 1, 45, 5 }, new[] { 4, 6, 7 }, new[] { 7, 8, 3 } };
        private readonly int[][] _rightSquareElements2 = { new[] { 4, 45, 5 }, new[] { 4, 6, 7 }, new[] { 7, 8, 7 } };
        private readonly int[][] _notRightSquareElements = { new[] { 1, 5, 0, 4 }, new[] { 0, 1, 0, 3}, new[] { 0, 0, 3, 7 } };
        private readonly int[][] _notRightElements = {new[] {1, 5}, new[] {0, 1, 0}, new[] {0}};
        private class TestValidator: IValidatorMatrix<int> {
            public bool IsValid(int[][] elements) {
                return elements.All(t => t.All(x => x > 3));
            }
            public string Message => "Elements must more then 3";
        }

        [Test]
        public void CreateTest() {
            Matrix<int> squareMatrix = MatrixFactory.GetMatrix(_rightSquareElements, typeof(SquareMatrix<int>)); 
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTest_Exception1() {
            Matrix<int> squareMatrix = MatrixFactory.GetMatrix(_notRightSquareElements, typeof(SquareMatrix<int>)); 
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTest_Exception2() {
            Matrix<int> squareMatrix = MatrixFactory.GetMatrix(_notRightElements, typeof(SquareMatrix<int>));
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void CreateTest_TestValidator_Exception() {
            Matrix<int> squareMatrix = new SquareMatrix<int>(_rightSquareElements,
                new ValidatorList<int>() {new TestValidator()});
        }
        [Test]
        public void CreateTest_TestValidator() {
            Matrix<int> squareMatrix = new SquareMatrix<int>(_rightSquareElements2,
                new ValidatorList<int>() { new TestValidator() });
        }


        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetElementTest_Exception() {
            Matrix<int> squareMatrix = MatrixFactory.GetMatrix(_rightSquareElements, typeof(SquareMatrix<int>));
            squareMatrix.SetElement(3, 1, 3);

        }
        [Test]
        public void SetElementTest() {
            Matrix<int> squareMatrix = MatrixFactory.GetMatrix(_rightSquareElements, typeof(SquareMatrix<int>));
            squareMatrix.SetElement(0, 0, 3);
        }
    
}
}
