using System;
using Task1.Validator;

namespace Task1.Matrices {
    public class SquareMatrix<T> : Matrix<T> {
        public SquareMatrix(int n) : base(n, n) { }
        public SquareMatrix(int n, ValidatorList<T> validatorList) : base(n, n, validatorList){ }
        public SquareMatrix(T[][] elements) : base(elements) { }
        public SquareMatrix(T[][] elements, ValidatorList<T> validatorList) : base(elements,validatorList) { }

        public SquareMatrix(Matrix<T> matrix) : this(matrix.N) {
                for (int i = 0; i < N; i++)
                    for(int j = 0; j < N; j++)
                        Elements[i][j] = matrix[i,j];
        }

        protected override void InitValidatorList() {
            base.InitValidatorList();
            ValidationList.Add(new SquareMatrixValidator<T>());
        }

        public override void SetElement(int i, int j, T element) {
            if (i >= N || j >= N || i < 0 || j < 0)
                throw new InvalidOperationException("");
            Elements[i][j] = element;
            OnElementChanged(i, j);
        }
    }
}
