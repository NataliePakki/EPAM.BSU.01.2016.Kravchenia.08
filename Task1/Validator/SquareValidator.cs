namespace Task1.Validator {
    public class SquareMatrixValidator<T>: IValidatorMatrix<T> {
        public bool IsValid(T[][] elements) {
            if (elements == null)
                return false;
            return elements.Length == elements[0].Length;
        }
        public string Message => "Matrix isn't square.";
    }
}
