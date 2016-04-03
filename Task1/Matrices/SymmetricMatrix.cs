using System;
using Task1.Validator;

namespace Task1.Matrices {
    public class SymmetricMatrix<T> : Matrix<T> {
        public SymmetricMatrix(int n, ValidatorList<T> validatorList): base(n, n, validatorList){}
        public SymmetricMatrix(int n): base(n, n) { }
        public SymmetricMatrix(T[][] elements) : base(elements) { }
        public SymmetricMatrix(T[][] elements, ValidatorList<T> validatorList) : base(elements, validatorList) { }
        protected override void InitValidatorList() {
            base.InitValidatorList();
            ValidationList.Add(new SquareMatrixValidator<T>());
            ValidationList.Add(new SymmetricMatrixValidator<T>());
        }

        public override void SetElement(int i, int j, T element) {
            if (i >= N || j >= N || i < 0 || j < 0)
                throw new InvalidOperationException("");
            Elements[i][j] = element;
            Elements[j][i] = element;
            OnElementChanged(i, j);
            OnElementChanged(j, i);
        }
    }
}