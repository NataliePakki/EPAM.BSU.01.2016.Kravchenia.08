using System;
using System.Collections.Generic;
using static System.Console;
namespace Task2.Console {
    public class PrintTreeHelper<T> {
        private readonly BinaryTree<T> _tree;

        public PrintTreeHelper(BinaryTree<T> tree) {
            if(tree == null)
                throw new ArgumentNullException();
            _tree = tree;
        }

        public void PrintAll() {
            Line();
            Print();
            PreorderPrint();
            PostorderPrint();
            IncorderPrint();
            Line();
        }
        public void Print() => Print(_tree.GetRoot(), 0);
        
        public void PreorderPrint() => OrderPrint(_tree.Postorder(), "Preorder:");
        public void PostorderPrint() => OrderPrint(_tree.Postorder(), "Postorder:");
        
        public void IncorderPrint() => OrderPrint(_tree.Inorder(), "Inororder:");

        private static void Print(NodeTree<T> node, int level) {
            if (node == null) return;
            Print(node.Right, level + 1);
            for (var i = 0; i < level; i++)
                Write("            ");
            Write(node.Info.ToString());
            WriteLine();
            Print(node.Left, level + 1);
        }
        private static void OrderPrint(IEnumerable<T> enumerable, string title) {
            WriteLine(title);
            foreach (var element in enumerable)
                Write($"{element}  ");
            WriteLine();
        }

        private static void Line() {
            WriteLine("-------------------------------------------");
        }

    }
}