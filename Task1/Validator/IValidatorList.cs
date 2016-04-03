using System.Collections.Generic;

namespace Task1.Validator {
    public interface IValidatorList<in T> {
        bool IsValid(T[][] elements);
        List<string> Messages(T[][] elements);
    }
}
