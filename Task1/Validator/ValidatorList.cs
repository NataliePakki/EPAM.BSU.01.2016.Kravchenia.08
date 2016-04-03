using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task1.Validator {
    public class ValidatorList<T>: IValidatorList<T>, IEnumerable {
        private readonly List<IValidatorMatrix<T>> _validators;
        public ValidatorList() {
            _validators = new List<IValidatorMatrix<T>>();
        }
        public ValidatorList(List<IValidatorMatrix<T>> validators) {
            _validators = validators;
        }

        public bool IsValid(T[][] elements) {
            return _validators.All(v => v.IsValid(elements));
        }

        public List<string> Messages(T[][] elements){
            return _validators.Where(v => !v.IsValid(elements)).Select(v => v.Message).ToList();
        }
        public void Add(IValidatorMatrix<T> validator) {
            _validators.Add(validator);
        }
        public void Add(ValidatorList<T> validators){
            foreach (IValidatorMatrix<T> validator in validators) {
                _validators.Add(validator);
            }
        }
        public IEnumerator GetEnumerator() {
            return _validators.GetEnumerator();
        }
    }
}
