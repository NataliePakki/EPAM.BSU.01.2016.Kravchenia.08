using System;
using System.Linq;
using Task1.Visitor;

namespace Task1.Matrices {
    public class SquareMatrix<T> { 
        protected T[] Elements;
        public EventHandler<ElementEventArgs> ElementChanged;
        public SquareMatrix() { } 
        public SquareMatrix(int n) {
            if (n > 0) {
                N = n;
                Elements = new T[N*N];
            }
            else throw new ArgumentException("N must be positive.");
        }
        public SquareMatrix(T[][] elements)  {
            if (elements == null)
                throw new ArgumentNullException($"{nameof(elements)} is null.");
            if (!IsValid(elements))
                throw new ArgumentException("Array doesn't sqaure.");
            N = elements.Length;
            Elements = new T[N * N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++) {
                    this[i,j] = elements[i][j];
                   }
        }
        public int N { get; protected set; }

        public virtual T this[int i, int j]{
            get {
                if(i > N || j > N || i < 0 || j < 0)
                    throw new ArgumentOutOfRangeException();
                return Elements[i * N + j];
                
            }
            set {
                if (i > N || j > N || i < 0 || j < 0)
                    throw new ArgumentOutOfRangeException();
                Elements[i * N + j] = value;
                OnElementChanged(i, j);
            }
        }

        protected void OnElementChanged(int i, int j){
            ElementChanged?.Invoke(this, new ElementEventArgs(i, j));
        }

        public void Accept(IMatrixVisitor<T> visitor) {
            visitor.Visit((dynamic)this);
        }

        protected  bool IsValid(T[][] elements) {
            return elements.All(arg => arg.Length == elements.Length);
        }

    }
    public class ElementEventArgs : EventArgs {
        public int I { get; private set; }
        public int J { get; private set; }
        public ElementEventArgs(int i, int j) {
            I = i;
            J = j;
        }
    }

}
