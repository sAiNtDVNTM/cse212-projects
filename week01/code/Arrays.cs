public static class Arrays
{
    public static double[] MultiplesOf(double number, int length)
    {
        //Step 1: create the array with the length size to hold all the multiples.
        double[] multiples = new double[length];
        //Step 2: Create a loop from 0 to -1            
        for (int i = 0; i < length; i++)
            // Step 3: For each position i, calculate (number * (i + 1)). and Store that value in the array at position i.
            multiples[i] = number * (i + 1);

        return multiples; // Step 4: Return the result


        //PLAN: We need to create an array of size "length" to hold the multiples. Also we need to use a loop that runs from 0 up to length - 1.
        // Then we must do this operation i in the array like this: calculate (number * (i + 1)). Store that value in the array at position i.
        // and the final step, after the loop finishes, return the array.
    }


    public static void RotateListRight(List<int> data, int amount)
    {
        //Step 1: Get the total 
        int count = data.Count;
        //Step 2: Handle the case where amount == count, rotating by the full length
        if (amount == count)
            return;
        //Step 3: Calculate the starting index for rotation
        int startIndex = count - amount;
        // Step 4: Slice the list into two parts
        List<int> partA = data.GetRange(startIndex, amount);
        List<int> partB = data.GetRange(0, startIndex);
        // Step 5: Clear the original list
        data.Clear();
        // Step 6: Add Part A first, then Part B back into the original list.
        data.AddRange(partA);
        data.AddRange(partB);

    }

    // PLAN: Get the total number of elements in the list using data.Count. If the amount equals the list length, no rotation is needed — return immediately.
    // Then we need to calculate the starting index for rotation: startIndex = data.Count - amount. This is where the "cut" happens in the list. 
    //After that slice the list into two parts:
    //Part A: from startIndex to the end (last 'amount' elements).
    //Part B: from the beginning up to startIndex (the rest).
    //Clear the original list so we can rebuild it.
    //Add Part A first, then Part B back into the original list.
    //Done — the original list is now rotated in place.



}


