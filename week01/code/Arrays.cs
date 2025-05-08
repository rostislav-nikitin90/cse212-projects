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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1. Define the array to store results:
        // Create an array of type double with length elements to store the multiples.
        double[] result = new double[length];

        // Step 2. Populate the array using a loop:
        // Use a loop to iterate from 0 to length - 1.
        // On each iteration, calculate the multiple by multiplying number by (index + 1).
        // Assign the computed value to the current position in the array.
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1); // Calculate multiples
        }

        // Step 3. Return the array:
        // Once the loop completes, return the filled array containing the multiples.
        return result;
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1. Determine the effective rotation amount:
        // Since rotating by data.Count results in the same list, modulo (%) can be used 
        // to handle cases where amount >= data.Count.
        // Compute effectiveAmount = amount % data.Count to ensure rotation within the bounds
        // of the list.
        int effectiveAmount = amount % data.Count;

        // Step 2. Use List slicing to rearrange elements:
        // Divide the list into two parts:
        // The last effectiveAmount elements that will move to the front.
        // The remaining elements that stay after rotation.
        // Extract the last effectiveAmount elements using 
        // data.GetRange(data.Count - effectiveAmount, effectiveAmount).
        List<int> lastSegment = data.GetRange(data.Count - effectiveAmount, effectiveAmount);
        // Extract the remaining elements using data.GetRange(0, data.Count - effectiveAmount).
        List<int> firstSegment = data.GetRange(0, data.Count - effectiveAmount);

        // Step 3. Update the original list:
        // Clear the existing list to remove old elements.
        // Add back the extracted segments in the rotated order.
        // First, add the last effectiveAmount elements.
        // Then, add the remaining elements to the end.
        data.Clear(); // Remove all existing elements
        data.AddRange(lastSegment); // Add the rotated last segment first
        data.AddRange(firstSegment); // Add the remaining elements after

    // The list is now modified in-place with the rotated values
    }
}
