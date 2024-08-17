using Algorithms.Trees.BinaryTree;

namespace Algorithms.Trees.BinarySearchTree;

public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable<T> {
    public int Count { get; set; }

    public BinarySearchTree() {
        Count = 0;
    }

    public void Add(T data) {
        TreeNode<T>? parent = GetParentForNewNode(data);
        var node = new TreeNode<T>(data, parent);

        if (parent is null) {
            Root = node;
        } else if (data.CompareTo(parent.Data) < 0) {
            parent.Left = node;
        } else {
            parent.Right = node;
        }

        Count++;
    }

    public void Remove(T data) => Remove(Root, data);

    public bool Contains(T data) {
        var current = Root;
        while (current is not null) {
            int comparison = data.CompareTo(current.Data);

            if (comparison < 0) {
                current = current.Left;
                continue;
            }

            if (comparison > 0) {
                current = current.Right;
                continue;
            }

            return true;
        }

        return false;
    }

    private void Remove(TreeNode<T>? node, T data) {
        if (node is null) {
            return;
        } else if (data.CompareTo(node.Data) < 0) {
            Remove(node.Left, data);
        } else if (data.CompareTo(node.Data) > 0) {
            Remove(node.Right, data);
        } else {
            if (node.Left is null || node.Right is null) {
                TreeNode<T>? newNode = node.Left is null && node.Right is null
                    ? null
                    : node.Left ?? node.Right;
                ReplaceInParent(node, newNode);
                Count--;
            } else {
                var successor = FindMinimumInSubtree(node.Right);
                node.Data = successor.Data;
                Remove(successor, successor.Data);
            }
        }
    }

    private TreeNode<T>? GetParentForNewNode(T data) {
        TreeNode<T>? current = Root;
        TreeNode<T>? parent = null;

        while (current is not null) {
            parent = current;
            int comparison = data.CompareTo(current.Data);

            if (comparison == 0) {
                throw new ArgumentException($"The node {data} already exists.");
            } else if (comparison < 0) {
                current = current.Left;
            } else {
                current = current.Right;
            }
        }

        return parent;
    }

    private void ReplaceInParent(TreeNode<T> removable, TreeNode<T>? newNode) {
        if (removable.Parent is not null) {
            var parent = removable.Parent;

            if (parent.Left == removable) {
                parent.Left = newNode;
            } else {
                parent.Right = newNode;
            }
        } else {
            Root = newNode;
        }

        if (newNode is not null) {
            newNode.Parent = removable.Parent;
        }
    }

    private TreeNode<T> FindMinimumInSubtree(TreeNode<T> node) {
        while (node.Left is not null) {
            node = node.Left;
        }

        return node;
    }
}