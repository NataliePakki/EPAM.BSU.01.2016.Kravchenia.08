using NUnit.Framework;
using Task1.Matrices;
using Task1.Visitor;

namespace Task1.Tests {
    [TestFixture]
    public class MatrixTests {
        private readonly SquareMatrix<int> _squareMatrix =
            new SquareMatrix<int>(new[] {new[] {1, 2, 3}, new[] {4, 5, 6}, new[] {7, 8, 9}});

        private readonly DiagonalMatrix<int> _diogonalSquareMatrix =
            new DiagonalMatrix<int>(new []{1,2,3});

        private readonly SymmetricMatrix<int> _symmMatrix =
            new SymmetricMatrix<int>(new[] { new[] { 1, 2, 4 }, new[] { 2, 3, 5 }, new[] { 4, 5, 6 }});

        [Test]
        public void SymmMatrixSumWithDiagonalMatrix_Test() {
            var sumResult = _symmMatrix.SumWith(_diogonalSquareMatrix);
        }
        [Test]
        public void SymmMatrixSumWithSymmMatrix_Test() {
            var sumResult = _symmMatrix.SumWith(_symmMatrix);
        }
        [Test]
        public void DiagonalMatrixSumWithDiagonalMatrix_Test() {
            var result = new[] { 2,4,6 };
            var matrixResult = new DiagonalMatrix<int>(result);
            var sumResult = _diogonalSquareMatrix.SumWith(_diogonalSquareMatrix);
        }
    }

}
    
