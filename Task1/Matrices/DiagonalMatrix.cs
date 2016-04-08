using System;

namespace Task1.Matrices {
    public class DiagonalMatrix<T> : AbstractSquareMatrix<T> {
       public DiagonalMatrix(int n) : base(n){ }

        public DiagonalMatrix(T[] diagonal) : base(diagonal.Length) {
            Array.Copy(diagonal, Elements, N);
        }
        public DiagonalMatrix(T[][] elements) : base(elements){ }

        protected override void SetElement(int i, int j, T value) {
            if (i != j)
                throw new IndexOutOfRangeException();
            Elements[i] = value;
        }

        protected override T GetElement(int i, int j) {
            return i != j ? default(T) : Elements[i];
        }

        protected override void Init(int n) {
            N = n;
            Elements = new T[N];
        }
        protected override void InitElements(T[][] elements) {
            if (!IsValid(elements)) {
                throw new ArgumentException("Matrix doesn't diagonal."); }
            Init(elements.Length);
            for (int i = 0; i < N; i++)
                this[i, i] = elements[i][i];
        }

        private new bool IsValid(T[][] elements) {
            if (!base.IsValid(elements)) return false;
            for (int i = 0; i < elements.Length; i++)
                for (int j = 0; j < elements[i].Length; j++)
                    if (i != j && !elements[i][j].Equals(default(T)))
                        return false;
            return true;
        }
    }
}
