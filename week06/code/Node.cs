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
        //check if the value is equal to the Data
        if (value == Data)
        {
            // Do not insert duplicates
            return;
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
        //check if the value is equal to the Data
        if (value == Data)
        {
            // return true if found
            return true;
        }

        if (value < Data)
        {
            // Return false if left is null, else search left
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }
        else
        {
            // Return false if right is null, else search right
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        //base case: if leaf node, height is 1
       int leftHeight = Left?.GetHeight() ?? 0;
       int rightHeight = Right?.GetHeight() ?? 0;

       //return the greater height plus one for the current node
       return Math.Max(leftHeight, rightHeight) + 1;

    }
}