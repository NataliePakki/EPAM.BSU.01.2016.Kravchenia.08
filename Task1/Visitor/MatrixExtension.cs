using Task1.Matrices;

namespace Task1.Visitor {
    public static class MatrixExtension {
            public static dynamic SumWith<T>(this SquareMatrix<T> matrix, SquareMatrix<T> otherMatrix) {
                var visitor = new SumMatrixVisitor<T>(otherMatrix);
                matrix.Accept(visitor);
                return visitor.Result;
            }
        }
    }
    
