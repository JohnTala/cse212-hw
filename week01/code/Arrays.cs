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
        // Step 1: Create an array with the requested length.
        double[] multiples = new double[length];

        // Step 2: Loop through each position in the array.
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple of the number.
            // The first multiple is number * 1.
            // The second multiple is number * 2, and so on.
            multiples[i] = number * (i + 1);
        }

        // Performance: The loop runs once for each element in the array.
        // Therefore, the performance is O(n).
        return multiples;
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
        // Step 1: Find the index where the last 'amount' elements begin.
        // For example, if the list contains 9 elements and amount is 3:
        // index = 9 - 3 = 6.
        int index = data.Count - amount;

        // Step 2: Get the last 'amount' elements.
        // GetRange(6, 3) gives {7, 8, 9}.
        List<int> firstPart = data.GetRange(index, amount);

        // Step 3: Get the elements before the last 'amount' elements.
        // GetRange(0, 6) gives {1, 2, 3, 4, 5, 6}.
        List<int> secondPart = data.GetRange(0, index);

        // Step 4: Clear the original list.
        data.Clear();

        // Step 5: Add the last 'amount' elements to the beginning.
        data.AddRange(firstPart);

        // Step 6: Add the remaining elements after them.
        data.AddRange(secondPart);

        // Performance:
        // The GetRange and AddRange operations process elements linearly.
        // The operations are sequential, so the overall performance is O(n).
        //
        // O(n) + O(n) + O(n) + O(n) = O(4n)
        // Drop the constant 4: O(n)
    }
}