
namespace Task1.Validator {
    public class DiagonalValidator<T>: IValidatorMatrix<T>  {
        public  bool IsValid(T[][] elements) {
            if (elements == null)
                return false;
                for (int i = 0; i < elements.Length; i++)
                    for (int j = 0; j < elements[i].Length; j++)
                        if (i != j && !elements[i][j].Equals(default(T)))
                            return false;
                return true;
        }
        public  string Message => "Matrix isn't diogonal.";
    }
}
