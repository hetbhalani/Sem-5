class TreeNode{
    int value;
    TreeNode left = null;
    TreeNode right = null;
}

public class mirrorTree {
    public static void main(String[] args) {
        Integer[] tree = {1, 2, 2,null, 3, 3, null};
        TreeNode root = buildTree(tree, 0);
        printPostOrder(root);
        System.out.println();
        if (isMirror(root)) {
            System.out.println("mirror");
        } else {
            System.out.println("not mirror");
        }
    }

    public static TreeNode buildTree(Integer[] arr, int i) {
        if (i >= arr.length || arr[i] == null) return null;
        TreeNode node = new TreeNode();

        node.value = arr[i];
        node.left = buildTree(arr, 2*i +1);
        node.right = buildTree(arr, 2*i +2);
        return node;
    }

    public static void printPostOrder(TreeNode root) {
        if (root == null) return;
        System.out.print(root.value + " ");
        printPostOrder(root.left);
        printPostOrder(root.right);
    }

    public static boolean isMirror(TreeNode root) {
        if (root == null) return true;
        return isMirrorHelper(root.left, root.right);
    }

    private static boolean isMirrorHelper(TreeNode left, TreeNode right) {
        if (left == null && right == null) return true;
        if (left == null || right == null) return false;
        if (left.value != right.value) return false;
        return isMirrorHelper(left.left, right.right) && isMirrorHelper(left.right, right.left);
    }
}