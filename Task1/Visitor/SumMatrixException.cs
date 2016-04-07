using System;

namespace Task1.Visitor {
    public sealed class SumMatrixException : Exception {
        public SumMatrixException(string message) : base(message) { }
    }
}