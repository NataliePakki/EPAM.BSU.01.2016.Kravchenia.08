
namespace Task2 { 
    public class NodeTree<T> {
        public T Info;
        public NodeTree<T> Left;
        public NodeTree<T> Right;

        public NodeTree(T info) {
            Info = info;
        }
        public NodeTree(T info, NodeTree<T> left = null, NodeTree<T> right = null) : this(info) {
            Left = left;
            Right = right;
        }
    }
}
