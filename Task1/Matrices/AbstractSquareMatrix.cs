using System;
using System.Linq;
using Task1.Visitor;

namespace Task1.Matrices {
    public abstract class AbstractSquareMatrix<T> { 
        protected T[] Elements;
        public EventHandler<ElementEventArgs> ElementChanged;
        
        public int N { get; set; }

        protected AbstractSquareMatrix(int n) {
            if (n > 0) {
                N = n;
                Init(N);
            }
            else throw new ArgumentException("N must be positive.");
        } 
        protected AbstractSquareMatrix(T[][] elements) {
            if (elements == null) 
                throw new ArgumentNullException($"{nameof(elements)} is null");
            InitElements(elements);
        } 

        public T this[int i, int j]{
            get {
                if(i > N || j > N || i < 0 || j < 0)
                    throw new ArgumentOutOfRangeException();
				return GetElement(i,j);
                
            }
            set {
                if (i > N || j > N || i < 0 || j < 0)
                    throw new ArgumentOutOfRangeException();
				SetElement(i,j,value);
                OnElementChanged(i, j);
            }
        }

        protected void OnElementChanged(int i, int j){
            ElementChanged?.Invoke(this, new ElementEventArgs(i, j));
        }

        protected abstract void SetElement(int i, int j, T value);
		protected abstract T GetElement(int i,int j);

        protected abstract void Init(int n);
        protected abstract void InitElements(T[][] elements);

        public void Accept(IMatrixVisitor<T> visitor) {
            visitor.Visit((dynamic)this);
        }

        protected  bool IsValid(T[][] elements) {
            return elements.All(arg => arg.Length == elements.Length);
        }

        protected virtual void Init(T[][] elements) { }
            
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


