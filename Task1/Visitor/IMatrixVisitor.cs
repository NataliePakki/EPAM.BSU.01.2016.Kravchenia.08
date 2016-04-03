using Task1.Matrices;

namespace Task1.Visitor {
    public interface IMatrixVisitor<T> {
        void Visit(DiagonalMatrix<T> diagonalMatrix);
        void Visit(SquareMatrix<T> squareMatrix);
        void Visit(SymmetricMatrix<T> symmetricMatrix);
    }
}