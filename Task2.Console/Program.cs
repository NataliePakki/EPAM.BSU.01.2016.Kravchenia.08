using static System.Console;
namespace Task2.Console {
    class Program {
        static void Main(){
            #region int with default comparer
            WriteLine("int with default comparer:");
            var intTree = new BinaryTree<int>();
            intTree.Add(10);
            intTree.Add(6);
            intTree.Add(11);
            intTree.Add(-3);
            intTree.Add(45);
            var printIntTreeHelper = new PrintTreeHelper<int>(intTree);
            printIntTreeHelper.PrintAll();
            #endregion

            #region int with length comparer
            WriteLine("int with length comparer:");
            var intTreeLength = new BinaryTree<int>(new LengthIntComparer());
            intTreeLength.Add(4444);
            intTreeLength.Add(55555);
            intTreeLength.Add(333);
            intTreeLength.Add(22);
            intTreeLength.Add(7777777);
            printIntTreeHelper = new PrintTreeHelper<int>(intTreeLength);
            printIntTreeHelper.PrintAll();
            #endregion

            #region string with default comparer
            WriteLine("string with default comparer:");
            var stringTree = new BinaryTree<string>();
            stringTree.Add("lemon");
            stringTree.Add("orange");
            stringTree.Add("apple");
            stringTree.Add("banan");
            stringTree.Add("lime");
            var printStringTreeHelper = new PrintTreeHelper<string>(stringTree);
            printStringTreeHelper.PrintAll();
            #endregion

            #region string with length comparer
            WriteLine("string with length comparer:");
            var stringTreeLength = new BinaryTree<string>(new LengthStringComparer());
            stringTreeLength.Add("cake");
            stringTreeLength.Add("apple");
            stringTreeLength.Add("ice");
            stringTreeLength.Add("no");
            stringTreeLength.Add("limonad");
            printStringTreeHelper = new PrintTreeHelper<string>(stringTreeLength);
            printStringTreeHelper.PrintAll();
            #endregion

            #region Book with default comparer
            WriteLine("Book with default comparer:");
            var bookTree = new BinaryTree<Book>();
            bookTree.Add(new Book("One", 45));
            bookTree.Add(new Book("Tree", 35));
            bookTree.Add(new Book("Eleven", 25));
            bookTree.Add(new Book("Five",  65));
            bookTree.Add(new Book("Two",  95));
            var printBookTreeHelper = new PrintTreeHelper<Book>(bookTree);
            printBookTreeHelper.PrintAll();
            #endregion

            #region Book with price comparer
            WriteLine("Book with price comparer:");
            var bookTreePrice = new BinaryTree<Book>(new PriceBookComparer());
            bookTreePrice.Add(new Book("One", 45));
            bookTreePrice.Add(new Book("Tree", 35));
            bookTreePrice.Add(new Book("Eleven", 25));
            bookTreePrice.Add(new Book("Five", 65));
            bookTreePrice.Add(new Book("Two", 95));
            printBookTreeHelper = new PrintTreeHelper<Book>(bookTreePrice);
            printBookTreeHelper.PrintAll();
            #endregion

            #region Point without comparer
            WriteLine("Point without comparer");
            try {
                var tree = new BinaryTree<Point>();
            }
            catch (DefaultComparerException ex) {
                WriteLine(ex.Message);
            }
           
            #endregion

            #region Point with comparer
            WriteLine("Point with comparer");
             var pointTree = new BinaryTree<Point>(new PointComparer());
            pointTree.Add(new Point(5, 4));
            pointTree.Add(new Point(10, 45));
            pointTree.Add(new Point(4, 16));
            pointTree.Add(new Point(3, 90));
            pointTree.Add(new Point(16, 3));
            var printPointTreeHelper = new PrintTreeHelper<Point>(pointTree);
            printPointTreeHelper.PrintAll();
            #endregion
            ReadKey();
        }
    }
}
