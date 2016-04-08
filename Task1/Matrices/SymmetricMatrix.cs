using System;

namespace Task1.Matrices {
    public class SymmetricMatrix<T> : AbstractSquareMatrix<T> {
        public SymmetricMatrix(int n): base(n) { }

        public SymmetricMatrix(T[][] elements) : base(elements) { }
      
        protected override void SetElement(int i, int j, T value) {
            if (j <= i)
                Elements[(1 + i) * i / 2 + j] = value;
            else Elements[(1 + j) * j / 2 + i] = value;
            OnElementChanged(j, i);
        }

        protected override T GetElement(int i, int j) {
             return j <= i ? Elements[(1 + i) * i / 2 + j] : Elements[(1 + j) * j / 2 + i];
        }

        protected override void Init(int n) {
            N = n;
            Elements = new T[(N * N + N) / 2];
        }

        protected override void InitElements(T[][] elements) {
            if (!IsValid(elements))
                throw new ArgumentException("Array doesn't symmetric.");
            Init(elements.Length);
            for (int i = 0; i < N; i++)
                for (int j = 0; j <= i; j++)
                    this[i, j] = elements[i][j];
        }

        private new bool IsValid(T[][] elements) {
            if (!base.IsValid(elements)) return false;
            for (int i = 0; i < N; i++)
                for (int j = 0; j < i; j++)
                    if (!elements[i][j].Equals(elements[j][i]))
                        return false;
            return true;
        }
    }

}