using System;

namespace Task1.Matrices {
    public class DiagonalMatrix<T> : SquareMatrix<T> {
       public DiagonalMatrix(int n) {
            if (n > 0) {
                N = n;
                Elements = new T[N];
            }
            else throw new ArgumentException("N must be positive.");
        }

        public DiagonalMatrix(T[] diagonal) {
            if(diagonal == null)
                throw new ArgumentNullException($"{nameof(diagonal)} is null.");
            N = diagonal.Length;
            Elements = new T[N];
            Array.Copy(diagonal, Elements, N);
        }
        public DiagonalMatrix(T[][] elements) {
            if (elements == null)
                throw new ArgumentNullException($"{nameof(elements)} is null.");
            if (!IsValid(elements)) {
                throw new ArgumentException("Matrix doesn't diagonal.");
            }
            N = elements.Length;
            Elements = new T[N];
            for (int i = 0; i < N; i ++)
                this[i,i] = elements[i][i];
        }


        public override T this[int i, int j] {
            get {
                if (i > N || j > N || i < 0 || j < 0)
                    throw new ArgumentOutOfRangeException();
                return i == j ? Elements[i] : default(T);
            }
            set {
                if (i > N || j > N || i < 0 || j < 0 || i != j)
                    throw new ArgumentOutOfRangeException();
                if (i == j) Elements[i] = value;
                OnElementChanged(i, j);

            }
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
