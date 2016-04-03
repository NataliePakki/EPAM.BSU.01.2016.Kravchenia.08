namespace Task1.Validator {
    public interface IValidatorMatrix<in T> {
        bool IsValid(T[][] elements);
        string Message { get; }
    }
}
