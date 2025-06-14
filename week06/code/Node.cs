public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        // Check for duplicates: if value is already in the tree, do nothing
        if (value == Data)
        {
            return; // Value is a duplicate, so we do not insert it
        }
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // If the value is equal to the current node's data, return true
        if (value == Data)
        {
            return true;
        }
        
        // Check left or right based on value
        if (value < Data)
        {
            // Check the left subtree
            return Left?.Contains(value) ?? false;
        }
        else
        {
            // Check the right subtree
            return Right?.Contains(value) ?? false;
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // Get the heights of left and right subtrees,
        // use -1 if they are null (an empty subtree)
        int leftHeight = Left?.GetHeight() ?? -1;
        int rightHeight = Right?.GetHeight() ?? -1;
        
        // The height of the tree will be 1 + the maximum of both heights
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}