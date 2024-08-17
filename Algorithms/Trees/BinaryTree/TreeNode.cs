namespace Algorithms.Trees.BinaryTree;

public class TreeNode<T> {
    public T Data { get; set; }
    public TreeNode<T>? Parent { get; set; } = null;

    public TreeNode<T>? Left { get; set; } = null;
    public TreeNode<T>? Right { get; set; } = null;

    public TreeNode(T data) {
        Data = data;
    }

    public TreeNode(T data, TreeNode<T>? parent) {
        Data = data;
        Parent = parent;
    }

    public int GetHeight() {
        int height = 1;
        var current = this;
        while (current.Parent is not null) {
            height++;
            current = current.Parent;
        }

        return height;
    }
}