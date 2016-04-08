using System;

namespace Task1.Matrices {
    public class SquareMatrix<T> : AbstractSquareMatrix<T> {
        public SquareMatrix(int n) : base(n) {}
        public SquareMatrix(T[][] elements) : base(elements) {}

        protected override void SetElement(int i, int j, T value) {
            Elements[i*N + j] = value;
        }

        protected override T GetElement(int i, int j) {
            return Elements[i*N + j];
        }

        protected override void Init(int n) {
            N = n;
            Elements = new T[N * N];
        }
        protected override void InitElements(T[][] elements) {
            if (!IsValid(elements))
                throw new ArgumentException("Array doesn't sqaure.");
            Init(elements.Length);
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++) {
                    this[i, j] = elements[i][j];
                }
        }
    }
}


