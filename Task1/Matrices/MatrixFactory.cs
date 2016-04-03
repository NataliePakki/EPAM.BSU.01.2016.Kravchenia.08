using System;

namespace Task1.Matrices {
    public static class MatrixFactory {
        public static Matrix<T> GetMatrix<T>(T[][] values, Type type) {
            if (type == typeof(DiagonalMatrix<T>))
                return new DiagonalMatrix<T>(values);
            if (type == typeof(SymmetricMatrix<T>))
                return new SymmetricMatrix<T>(values);
            return new SquareMatrix<T>(values);
        }
    }
}
