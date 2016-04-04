using System;
using System.Collections.Generic;

namespace Task2 {
    public class BinaryTree<T> {
        private NodeTree<T> _root;
        private IComparer<T> Comparer { get; }
        public BinaryTree(IComparer<T> comparer = null){
            if (comparer == null)
                if (typeof(T).GetInterface("IComparable`1") == null && typeof(T).GetInterface("IComparable") == null 
                    && typeof(T).GetInterface("IComparer") == null && typeof(T).GetInterface("IComparer`1") == null)
                     throw new DefaultComparerException("Values mustn't comparer.");
            Comparer = comparer ?? Comparer<T>.Default;
                
        }
        public NodeTree<T> GetRoot() => _root;
        public void Add(T info) {
            if (info == null)
                throw new ArgumentNullException();
            if (_root == null) {
                _root = new NodeTree<T>(info);
                return;
            }
            Add(ref _root, info);
        }
        public IEnumerable<T> Inorder() => Inorder(_root);
        public IEnumerable<T> Preorder() => Preorder(_root);
        public IEnumerable<T> Postorder() => Postorder(_root);
        private void Add(ref NodeTree<T> node, T info) {
         if (node == null) {
                node = new NodeTree<T>(info);
                return;
            }
         if (Comparer.Compare(node.Info, info) > 0)
                Add(ref node.Left, info);
         else if (Comparer.Compare(node.Info, info) < 0)
                Add(ref node.Right, info);
           else throw new ArgumentException("Element already exist.");
        }

        private IEnumerable<T> Inorder(NodeTree<T> node) {
            if (node == null)
                yield break;
            foreach (var element in Inorder(node.Left))
                yield return element;

            yield return node.Info;
            foreach (var element in Inorder(node.Right))
                yield return element;
        }
        private IEnumerable<T> Preorder(NodeTree<T> node) {
            if (node == null)
                yield break;
            yield return node.Info;

            foreach (var element in Preorder(node.Left))
                yield return element;

            foreach (var n in Preorder(node.Right))
                yield return n;
        }
        private IEnumerable<T> Postorder(NodeTree<T> node) {
            if (node == null)
                yield break;

            foreach (var element in Postorder(node.Left))
                yield return element;

            foreach (var element in Postorder(node.Right))
                yield return element;
            yield return node.Info;
        }

    }
}
