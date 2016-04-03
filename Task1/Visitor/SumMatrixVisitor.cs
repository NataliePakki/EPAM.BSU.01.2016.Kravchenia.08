using System;
using Task1.Matrices;

namespace Task1.Visitor {
    public class SumMatrixVisitor<T> : IMatrixVisitor<T> {
        public Matrix<T> Result { get; private set; }
        public Matrix<T> Matrix { get; private set; }
        public Matrix<T> OtherMatrix { get; private set; }

        public SumMatrixVisitor(Matrix<T> matrix) {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));
            OtherMatrix = matrix;
        }

        public void Visit(DiagonalMatrix<T> diagonalMatrix) {
            Matrix = diagonalMatrix;
            if (!IsValid())
                throw new InvalidOperationException("Size of matrices is different.");
            var n = OtherMatrix.N;
            SquareMatrix<T> resultMatrix = new SquareMatrix<T>(OtherMatrix);

            for (int i = 0; i < n; i++)
                resultMatrix.SetElement(i, i, Matrix[i, i] + (dynamic)resultMatrix[i,i] );

            Result = resultMatrix;
        }

        public void Visit(SquareMatrix<T> squareMatrix) {
            Matrix = squareMatrix;
            if (!IsValid())
                throw new InvalidOperationException("Size of matrices is different.");
            var n = OtherMatrix.N;
            SquareMatrix<T> resultMatrix = new SquareMatrix<T>(Matrix);

            for (int i = 0; i < n; i++)
                for(int j = 0; j < n; j++)
                resultMatrix.SetElement(i, j, (dynamic)OtherMatrix[i, j] + resultMatrix[i, j]);

            Result = resultMatrix;
        }

        public void Visit(SymmetricMatrix<T> symmetricMatrix) {
            Matrix = symmetricMatrix;
            if (!IsValid())
                throw new InvalidOperationException("Size of matrices is different");
            var n = OtherMatrix.N;
            SquareMatrix<T> resultMatrix = new SquareMatrix<T>(OtherMatrix);
            for (int i = 0; i < n; i++)
                for (int j = 0; j <= i; j++) {
                    resultMatrix.SetElement(i, j, Matrix[i, j] + (dynamic)resultMatrix[i, j]);
                    if(i != j)
                        resultMatrix.SetElement(j, i, Matrix[j, i] + (dynamic)resultMatrix[j, i]);
                }

            Result = resultMatrix;
        }
        private bool IsValid() {
            return Matrix.N == OtherMatrix.N;
        }

    }
}

