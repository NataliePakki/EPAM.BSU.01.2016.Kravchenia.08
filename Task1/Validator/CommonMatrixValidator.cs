using System.Linq;

namespace Task1.Validator {
    public class CommonMatrixValidator<T> : IValidatorMatrix<T> {
        public  bool IsValid(T[][] elements) {
            if (elements == null) return false;
                int size = elements[0].Length;
                return elements.All(x => x.Length == size);
            
        }
        public  string Message => "Matrix isn't rectangular";
    }
}