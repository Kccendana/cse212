public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        //1.create a new array of double with size lenghth
        double[] multiples = new double[length];

        //2.use a for loop to iterate through the array from 0 to length -1
        for (int i = 0; i < length; i++)
        {
            //3. inside the loop, set each element at index i to be number * (i+ 1)
            multiples[i] = number * (i + 1);
        }
        //4. return the array multiples
        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        //0. Guard clauses
        if (data == null || data.Count == 0)
        {
            return; // nothing to rotate
        }

        //1.Normalize the amount so it is in range of 0 to data.Count -1
        amount = amount % data.Count;
        if (amount == 0)
        {
            return; // no rotation needed
        }
        //2. Copy th last 'amount' elements into a temporary list.
        //Example: if the data = {1,2,3,4,5,6,7,8,9} and the amount = 3
        // then the temp list = {7,8,9}
        var temp = data.GetRange(data.Count - amount, amount);

        //3.Remove those last elements from the end of the original list.
        data.RemoveRange(data.Count - amount, amount);

        //4. Insert the saved elements from the temporary list to the front of the original lilst.
        data.InsertRange(0, temp);

        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
    }
}
