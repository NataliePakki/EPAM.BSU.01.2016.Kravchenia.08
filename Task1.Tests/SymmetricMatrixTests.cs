
using System;
using System.Linq;
using NUnit.Framework;
using Task1.Matrices;
using Task1.Validator;
using Task1.Visitor;

namespace Task1.Tests{
    [TestFixture]
    class SymmetricMatrixTests {
        private readonly int[][] _rightSymmElements = { new[] { 1, 45, 6 }, new[] { 45, 3, 8 }, new[] { 6, 8, 4 } };
        private readonly int[][] _rightSymmElements2 = { new[] { 4, 45, 6 }, new[] { 45, 6, 8 }, new[] { 6, 8, 4 } };
        private readonly int[][] _notRightSymmElements1 = { new[] { 1, 5, 0, 4 }, new[] { 0, 1, 0, 3 }, new[] { 0, 0, 3, 7 } };
        private readonly int[][] _notRightSymmElements2 = { new[] { 1, 5, 0 }, new[] { 0, 0, 3 }, new[] { 0, 3, 7 } };
        private readonly int[][] _notRightElements3 = { new[] { 1, 5 }, new[] { 0, 1, 0 }, new[] { 0 } };
        private class TestValidator : IValidatorMatrix<int> {
            public bool IsValid(int[][] elements) {
                return elements.All(t => t.All(x => x > 3));
            }

            public string Message => "Elements must more then 3";
        }

        [Test]
        public void CreateTest(){
            Matrix<int> symmetricMatrix = new SymmetricMatrix<int>(_rightSymmElements);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTest_Exception1() {
            Matrix<int> symmetricMatrix = new SymmetricMatrix<int>(_notRightSymmElements1);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTest_Exception2() {
            Matrix<int> symmetricMatrix = new SymmetricMatrix<int>(_notRightSymmElements2);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTest_Exception3() {
            Matrix<int> symmetricMatrix = new SymmetricMatrix<int>(_notRightElements3);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTest_TestValidator_Exception() {
            Matrix<int> symmMatrix = new SymmetricMatrix<int>(_rightSymmElements,
                new ValidatorList<int>() { new TestValidator() });
        }
        [Test]
        public void CreateTest_TestValidator() {
            Matrix<int> symmMatrix = new SymmetricMatrix<int>(_rightSymmElements2,
                new ValidatorList<int>() { new TestValidator() });
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetElementTest_Exception() {
            Matrix<int> symmetricMatrix = new SymmetricMatrix<int>(_rightSymmElements);
            symmetricMatrix.SetElement(3, 5, 3);

        }
        [Test]
        public void SetElementTest() {
            Matrix<int> symmetricMatrix = new SymmetricMatrix<int>(_rightSymmElements);
            symmetricMatrix.SetElement(0, 2, 3);
        }


    }
}
