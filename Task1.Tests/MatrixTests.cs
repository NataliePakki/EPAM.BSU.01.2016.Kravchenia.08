using NUnit.Framework;
using Task1.Matrices;
using Task1.Visitor;

namespace Task1.Tests {

    [TestFixture]
    public class MatrixTests {
        public struct Point {
            private int _x;
            private int _y;

            public Point(int x, int y) {
                _x = x;
                _y = y;
            }
            public static Point operator +(Point p1, Point p2) {
                Point result;
                result._x = p1._x + p2._x;
                result._y = p1._y + p2._y;
                return result;
            }
        }
        public struct Book {
            private string _name;
            private int _price;

            public Book(string name, int price) {
                _name = name;
                _price = price;

            }
        }
        private readonly SquareMatrix<int> _squareMatrix =
            new SquareMatrix<int>(new[] {new[] {1, 2, 3}, new[] {4, 5, 6}, new[] {7, 8, 9}});

        private readonly DiagonalMatrix<int> _diogonalSquareMatrix =
            new DiagonalMatrix<int>(new []{1,2,3});

        private readonly SymmetricMatrix<int> _symmMatrix =
            new SymmetricMatrix<int>(new[] { new[] { 1, 2, 4 }, new[] { 2, 3, 5 }, new[] { 4, 5, 6 }});
        private readonly DiagonalMatrix<Point> _diagonalPointMatrix  = 
            new DiagonalMatrix<Point>(new[] {
                new[] {new Point(1,1), new Point(), new Point()},
                new[] { new Point(), new Point(1, 1), new Point(0, 0)},
                 new[] { new Point(), new Point(), new Point(1, 1)}});
        private readonly DiagonalMatrix<Book> _diagonalBookMatrix =
            new DiagonalMatrix<Book>(new[] {
                new[] {new Book("Name",100), new Book(), new Book()},
                new[] { new Book(), new Book("Name", 100), new Book()},
                 new[] { new Book(), new Book(), new Book("Name", 100) }});
        [Test]
        public void SymmMatrixSumWithDiagonalMatrix_Test() {
            var sumResult = _symmMatrix.SumWith(_diogonalSquareMatrix);
        }
        [Test]
        public void DiagonalPointMatrixDiagonalMatrix_Test() {
            var sumResult = _diagonalPointMatrix.SumWith(_diagonalPointMatrix);
        }
        [Test]
        [ExpectedException(typeof(SumMatrixException))]
        public void DiagonalBookMatrixDiagonalMatrix_Test() {
            var sumResult = _diagonalBookMatrix.SumWith(_diagonalBookMatrix);
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
    
