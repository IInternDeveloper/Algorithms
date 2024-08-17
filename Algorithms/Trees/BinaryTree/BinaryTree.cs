namespace Algorithms.Trees.BinaryTree;

public class BinaryTree<T> {
    public TreeNode<T>? Root { get; set; }

    public BinaryTree() {
        Root = null;
    }

    public int GetHeight() =>
        Traverse(TraversalEnum.PreOrder).Max(node => node.GetHeight());

    public List<TreeNode<T>> Traverse(TraversalEnum mode) {
        var result = new List<TreeNode<T>>();

        switch (mode) {
            case TraversalEnum.PreOrder:
                TraversePreOrder(Root, result);
                break;
            case TraversalEnum.InOrder:
                TraverseInOrder(Root, result);
                break;
            case TraversalEnum.PostOrder:
                TraversePostOrder(Root, result);
                break;
        }

        return result;
    }

    private void TraversePreOrder(TreeNode<T>? node, List<TreeNode<T>> result) {
        if (node is null) {
            return;
        }

        result.Add(node);
        TraversePreOrder(node.Left, result);
        TraversePreOrder(node.Right, result);
    }

    private void TraverseInOrder(TreeNode<T>? node, List<TreeNode<T>> result) {
        if (node is null) {
            return;
        }

        TraverseInOrder(node.Left, result);
        result.Add(node);
        TraverseInOrder(node.Right, result);
    }

    private void TraversePostOrder(TreeNode<T>? node, List<TreeNode<T>> result) {
        if (node is null) {
            return;
        }

        TraversePostOrder(node.Left, result);
        TraversePostOrder(node.Right, result);
        result.Add(node);
    }
}