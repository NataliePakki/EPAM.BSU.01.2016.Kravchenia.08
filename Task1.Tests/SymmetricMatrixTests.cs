using System;
using NUnit.Framework;
using Task1.Matrices;

namespace Task1.Tests{
    [TestFixture]
    class SymmetricMatrixTests {
        private readonly int[][] _rightSymmElements = { new [] {1,2,4}, new [] {2,3,5}, new []{4,5,6}};

        [Test]
        public void CreateTest(){
            SquareMatrix<int> symmetricMatrix = new SymmetricMatrix<int>(_rightSymmElements);
        }
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetElementTest_Exception() {
            SquareMatrix<int> symmetricMatrix = new SymmetricMatrix<int>(_rightSymmElements);
            symmetricMatrix[3, 5] =  3;
            Assert.AreEqual(symmetricMatrix[3,5], 3);
        }
        [Test]
        public void SetElementTest() {
            SquareMatrix<int> symmetricMatrix = new SymmetricMatrix<int>(_rightSymmElements);
            symmetricMatrix[0,2] =  3;
            Assert.AreEqual(symmetricMatrix[2,0], 3);
        }


    }
}
