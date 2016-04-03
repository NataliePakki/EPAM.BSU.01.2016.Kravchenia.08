using System;
using Task1.Validator;

namespace Task1.Matrices {
    public class DiagonalMatrix<T> : Matrix<T> {
        public DiagonalMatrix(int n, ValidatorList<T> validatorList) : base(n, n, validatorList) {}
        public DiagonalMatrix(int n) : base(n, n) { }
        public DiagonalMatrix(T[][] elements): base(elements){ }
        public DiagonalMatrix(T[][] elements, ValidatorList<T> validatorList) : base(elements, validatorList) { }

        protected override void InitValidatorList() {
            base.InitValidatorList();
            ValidationList.Add(new DiagonalValidator<T>());
            ValidationList.Add(new SquareMatrixValidator<T>());
        }

        public override void SetElement(int i, int j, T element) {
            if (i != j || i >= N || j >= N || i < 0 || j < 0)
                throw new InvalidOperationException("");
            Elements[i][i] = element;
            OnElementChanged(i, i);
        }
    }
}
