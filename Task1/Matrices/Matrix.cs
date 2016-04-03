using System;
using System.Text;
using Task1.Validator;
using Task1.Visitor;

namespace Task1.Matrices {
    public abstract class Matrix<T> {
        protected ValidatorList<T> ValidationList;
        protected T[][] Elements;
        public EventHandler<ElementEventArgs> ElementChanged;
        private Matrix() {
            ValidationList = new ValidatorList<T>();
            InitValidatorList();
        } 
        protected Matrix(int n, int m) : this() {
            Elements = new T[n][];
            for(int i = 0; i < n; i++)
                Elements[i] = new T[m];
        }
        protected Matrix(int n, int m, ValidatorList<T> validatorList) : this(n, m) {
            if (validatorList == null)
                throw new ArgumentNullException($"{nameof(validatorList)}");
            ValidationList.Add(validatorList);
        }
        protected Matrix(T[][] elements, ValidatorList<T> validatorList) : this() {
            if (validatorList == null)
                throw new ArgumentNullException($"{nameof(validatorList)}");
            ValidationList.Add(validatorList);
            if (IsValid(elements)) {
                Elements = (T[][])elements.Clone();
            }
            else throw new ArgumentException(ValidationList.Messages(elements).ToString());
        }
        protected Matrix(T[][] elements): this(){
            if (IsValid(elements)){
                Elements = (T[][])elements.Clone();
            }
            else throw new ArgumentException(ValidationList.Messages(elements).ToString());
        }
        public int M => Elements[0].Length;
        public int N => Elements.Length;
        protected bool IsValid(T[][] elements) => ValidationList.IsValid(elements);
        protected virtual void InitValidatorList() {
            ValidationList.Add(new CommonMatrixValidator<T>());
        }

        public T this[int i, int j] => Elements[i][j];
        public abstract void SetElement(int i, int j, T element);

        protected void OnElementChanged(int i, int j){
            ElementChanged?.Invoke(this, new ElementEventArgs(i, j));
        }

        public void Accept(IMatrixVisitor<T> visitor) {
            visitor.Visit((dynamic)this);
        }

        public override string ToString() {
            var sb = new StringBuilder();
            for (int i = 0; i < Elements.Length; i++) {
                for (int j = 0; j < Elements[i].Length; j++) {
                    sb.Append(Elements[i][j] + " ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        public bool Equals(Matrix<T> m1) {
            if (m1.N != N || m1.M != M ) return false;
            for(int i = 0; i < Elements.Length; i++)
                for(int j = 0; j < Elements[i].Length; j++)
                    if (!this[i, j].Equals(m1[i, j]))
                        return false;
            return true;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(obj, this)) return true;
            if (ReferenceEquals(obj, null)) return false;
            if (GetType() != obj.GetType()) return false;
            return Equals((Matrix<T>)obj);
        }

        public override int GetHashCode() {
            return Elements.GetHashCode();
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
