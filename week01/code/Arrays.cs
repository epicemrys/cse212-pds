// Using dynamic arrays and solve complex problems.
// Comments show a plan in enough detail that it could be implemented by another

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
        // Step 1: Here we create a new array of doubles with the size 'length'.
        double[] multiplesArray = new double[length];

        // Step 2: A loop is used to fill the array with the multiples.
        // We will start from index 0 to 'length - 1' and calculate the multiple.
        for (int i = 0; i < length; i++)
        {
            multiplesArray[i] = number * (i + 1); // 'i + 1' gives us the correct multiple starting from the first one.
        }

        // Step 3: Now it returns the populated array.
        return multiplesArray;
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
        // Step 1: We calculate the effective amount by taking the modulus with the list's count.
        // This therefore handles cases where the amount is greater than the size of the list.
        int count = data.Count;
        amount = amount % count;

        // Step 2: You store the last 'amount' elements in a temporary list
        List<int> temp = data.GetRange(count - amount, amount);

        // Step 3: Shift the original list elements to the right
        for (int i = count - 1; i >= amount; i--)
        {
            data[i] = data[i - amount]; // No you move the elements to the right by using the 'amount'
        }

        // Step 4: You place the elements from the temporary list at the start
        for (int i = 0; i < amount; i++)
        {
            data[i] = temp[i]; // Lastly, puts the stored elements back at the start of the list
        }
    }
}
