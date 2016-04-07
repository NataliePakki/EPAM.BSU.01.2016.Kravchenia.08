using System;
using Task1.Matrices;

namespace Task1.Visitor {
    public class SumMatrixVisitor<T> : IMatrixVisitor<T> {
        public dynamic Result { get; private set; }
        public dynamic Matrix { get; private set; }
        public dynamic OtherMatrix { get; private set; }

        public SumMatrixVisitor(dynamic matrix) {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));
            OtherMatrix = matrix;
        }

        public void Visit(DiagonalMatrix<T> diagonalMatrix) {
            Matrix = diagonalMatrix;
            Validate();
            Result = OtherMatrix;
            try {
                for (int i = 0; i < Matrix.N; i++)
                        Result[i, i] = Result[i, i] + Matrix[i, i];
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException) {
                throw new SumMatrixException("Type of matrixs' elements doesn't support operator +.");
            }
           
        }

        public void Visit(SquareMatrix<T> squareMatrix) {
            Matrix = squareMatrix;
            Validate();
            Result = Matrix;
            try {
                for (int i = 0; i < Matrix.N; i++)
                    for (int j = 0; j < Matrix.N; j++) {
                        Result[i, j] = Result[i, j] + Matrix[i, j];
                    }
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException) {
                throw new SumMatrixException("Type of matrixs' elements doesn't support operator +.");
            }
        }

        public void Visit(SymmetricMatrix<T> symmetricMatrix) { 
            Matrix = symmetricMatrix;
            Validate();
            if (OtherMatrix.GetType() != typeof(SymmetricMatrix<T>)) {
                dynamic temp = OtherMatrix;
                OtherMatrix = symmetricMatrix;
                Visit(temp);
                return;
            }
            Result = OtherMatrix;
            try {
                for (int i = 0; i < Matrix.N; i++)
                    for (int j = 0; j <= i; j++) {
                        Result[i, j] = Result[i, j] + Matrix[i, j];
                    }
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException) {
                throw new SumMatrixException("Type of matrixs' elements doesn't support operator +.");
            }

        }
        private bool IsValid() {
            return Matrix.N == OtherMatrix.N;
        }

        private void Validate() {
            if (!IsValid())
                throw new InvalidOperationException("Size of matrices is different");
        }
     }
    
}

