namespace Task1.Validator {
    public class SymmetricMatrixValidator<T>: IValidatorMatrix<T> {
        public bool IsValid(T[][] elements) {
            if (elements == null) return false;
            for (int i = 0; i < elements.Length; i++)
                for (int j = 0; j < i; j++)
                    if (!elements[i][j].Equals(elements[j][i]))
                        return false;
            return true;
        }
        public string Message => "Matrix isn't symmetric.";
    }
}