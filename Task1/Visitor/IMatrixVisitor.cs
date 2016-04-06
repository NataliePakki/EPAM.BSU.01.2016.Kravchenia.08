using Task1.Matrices;

namespace Task1.Visitor {
    public interface IMatrixVisitor<T> {
        void Visit(SquareMatrix<T> otherMatrix);
        void Visit(DiagonalMatrix<T> otherMatrix);
        void Visit(SymmetricMatrix<T> otherMatrix);
    }
}