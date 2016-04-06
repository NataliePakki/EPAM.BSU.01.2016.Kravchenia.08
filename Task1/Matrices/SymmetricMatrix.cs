using System;

namespace Task1.Matrices {
    public class SymmetricMatrix<T> : SquareMatrix<T> {
        public SymmetricMatrix(int n) {
            if (n > 0) {
                N = n;
                Elements = new T[(n * n + n) / 2];
            }
            else throw new ArgumentException("N must be positive.");
        }

        public SymmetricMatrix(T[][] elements) {
            if (elements == null)
                throw new ArgumentNullException($"{nameof(elements)} is null.");
            if(!IsValid(elements))
                throw new ArgumentException("Matrix doesn't symmetric.");
            N = elements.Length;
            Elements = new T[(N * N + N) / 2];
            for (int i = 0; i < N; i++)
                for (int j = 0; j <= i; j++)
                        this[i,j] = elements[i][j];
        }
        public override T this[int i, int j] {
            get {
                if (i > N || j > N || i < 0 || j < 0)
                    throw new ArgumentOutOfRangeException();
                return j <= i ? Elements[(1 + i)*i/2 + j] : Elements[(1 + j)*j/2 + i];
            }
            set{
                if (i > N || j > N || i < 0 || j < 0)
                    throw new ArgumentOutOfRangeException();
                if (j <= i)
                    Elements[(1 + i)*i / 2 + j] = value;
                else Elements[(1 + j)*j / 2 + i] = value;
                OnElementChanged(i, j);
                OnElementChanged(j, i);
            }
        }
        private new bool IsValid(T[][] elements) {
            if (!base.IsValid(elements)) return false;
            for (int i = 0; i < elements.Length; i++)
                for (int j = 0; j < i; j++)
                    if (!elements[i][j].Equals(elements[j][i]))
                        return false;
            return true;
        }
    }

}