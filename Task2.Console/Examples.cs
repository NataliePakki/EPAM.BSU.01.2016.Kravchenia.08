using System;
using System.Collections.Generic;
using System.Text;

namespace Task2.Console {
    public class Book : IComparable<Book> {
        public Book(string name, double price) {
            Name = name;
            Price = price;
        }
        public string Name { get; set; }
        public double Price { get; set; }

        public int CompareTo(Book other) {
            if (other == null) return -1;
            return Name.CompareTo(other.Name);
        }

        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append($"{Name}({Price}$)");
            return sb.ToString();
        }
    }
    public struct Point {
        public int X;
        public int Y;

        public Point(int x, int y) {
            X = x;
            Y = y;
        }

        public override string ToString() {
            return $"({X}:{Y})";
        }
    }
    public class LengthIntComparer : IComparer<int> {
        public int Compare(int x, int y)  {
            var lengthX = x.ToString();
            var lengthY = y.ToString();
            if (lengthX.Length == lengthY.Length) return 0;
            return (lengthX.Length > lengthY.Length) ? 1 : -1;
        }
    }
    
    public class LengthStringComparer : IComparer<string> {
        public int Compare(string x, string y) {
            if (x.Length == y.Length) return 0;
            return (x.Length > y.Length) ? 1 : -1;
        }
    }
    public class PriceBookComparer : IComparer<Book> {
        public int Compare(Book x, Book y) {
            return x.Price.CompareTo(y.Price);
        }
    }
    public class PointComparer : IComparer<Point>{
        public int Compare(Point p1, Point p2){
            return p1.X.CompareTo(p2.X);
        }
    }

}