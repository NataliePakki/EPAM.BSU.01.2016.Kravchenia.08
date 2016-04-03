using NUnit.Framework;
using Task1.Matrices;
using Task1.Visitor;

namespace Task1.Tests {
    [TestFixture]
    public class MatrixTests {
        private readonly SquareMatrix<int> _squareMatrix =
            new SquareMatrix<int>(new[] {new[] {1, 2, 3}, new[] {4, 5, 6}, new[] {7, 8, 9}});

        private readonly DiagonalMatrix<int> _diogonalMatrix =
            new DiagonalMatrix<int>(new[] {new[] {1, 0, 0}, new[] {0, 3, 0}, new[] {0, 0, 56}});

        private readonly SymmetricMatrix<int> _symmMatrix =
            new SymmetricMatrix<int>(new[] {new[] {1, 45, 6}, new[] {45, 3, 8}, new[] {6, 8, 4}});

        [Test]
        public void SymmMatrixSumWithDiagonalMatrix_Test() {
            var result = new[] {new[] {2, 45, 6}, new[] {45, 6, 8}, new[] {6, 8, 60}};
            var matrixResult = MatrixFactory.GetMatrix(result, typeof(SquareMatrix<int>));
            Assert.AreEqual(matrixResult, _symmMatrix.SumWith(_diogonalMatrix));
        }
        [Test]
        public void DiogonalMatrixSumWithSymmMatrix_Test() {
            var result = new[] { new[] { 2, 45, 6 }, new[] { 45, 6, 8 }, new[] { 6, 8, 60 } };
            var matrixResult = MatrixFactory.GetMatrix(result, typeof(SquareMatrix<int>));
            Assert.AreEqual(matrixResult, _diogonalMatrix.SumWith(_symmMatrix));
        }
        [Test]
        public void SquareMatrixSumWithSymmetricMatrix_Test() {
            var result = new[] { new[] { 2, 47, 9 }, new[] { 49, 8, 14 }, new[] { 13, 16, 13 } };
            var matrixResult = MatrixFactory.GetMatrix(result, typeof(SquareMatrix<int>));
            Assert.AreEqual(matrixResult, _squareMatrix.SumWith(_symmMatrix));
        }
    }
}