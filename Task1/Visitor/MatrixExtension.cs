using Task1.Matrices;

namespace Task1.Visitor {
    public static class MatrixExtension {
            public static Matrix<T> SumWith<T>(this Matrix<T> matrix, Matrix<T> otherMatrix) {
                var visitor = new SumMatrixVisitor<T>(otherMatrix);
                matrix.Accept(visitor);
                return visitor.Result;
            }
        }
    }
