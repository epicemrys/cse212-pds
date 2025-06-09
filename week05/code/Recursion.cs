using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // TODO Start Problem 1
        // Base case: If n is less than or equal to 0, return 0.
        if (n <= 0)
            return 0;

        // Recursive case: n^2 + SumSquaresRecursive(n - 1)
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2
        // Base case: If the current permutation is of the desired size, you add it to the results.
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }
        
        // Recursive case: Iterate through each letter and form some permutations.
        for (int i = 0; i < letters.Length; i++)
        {
            // Choose the current letter and form new permutations.
            string newWord = word + letters[i];
            string remainingLetters = letters.Remove(i, 1); // Remove the chosen letter from letters
            PermutationsChoose(results, remainingLetters, size, newWord);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // TODO Start Problem 3

        // Initialize the memoization dictionary if it's null
        remember ??= new Dictionary<int, decimal>();

        // Base Cases
        if (s < 0) return 0;
        if (s == 0) return 1; // One way to stay at the ground (do nothing)
        if (remember.ContainsKey(s)) return remember[s]; // Return cached value if it exists

        // Recursive case: Calculate the number of ways to climb
        decimal ways = CountWaysToClimb(s - 1, remember) +
                    CountWaysToClimb(s - 2, remember) +
                    CountWaysToClimb(s - 3, remember);

        remember[s] = ways; // Store result in the dictionary
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results, string current = "")
    {
        // TODO Start Problem 4
        // Base case: If the pattern is empty, add the current string to results
        if (pattern.Length == 0)
        {
            results.Add(current);
            return;
        }

        // Recursive case: Process the first character of the pattern
        char firstChar = pattern[0];

        if (firstChar == '*')
        {
            // If it's a wildcard, we can either include '0' or '1'
            WildcardBinary(pattern[1..], results, current + '0'); // Choose '0'
            WildcardBinary(pattern[1..], results, current + '1'); // Choose '1'
        }
        else
        {
            // If it's not a wildcard, just add the character to current and move on
            WildcardBinary(pattern[1..], results, current + firstChar);
        }
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        // currPath.Add((1,2)); // Use this syntax to add to the current path

        // TODO Start Problem 5
        // ADD CODE HERE
        // Add current position to path
        currPath.Add((x, y));

        // Base case: Check if we've reached the end
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString()); // Add the path to results
        }
        else
        {
            // Explore the four possible directions
            // Up
            if (maze.IsValidMove(currPath, x, y - 1))
                SolveMaze(results, maze, x, y - 1, currPath);
            
            // Down
            if (maze.IsValidMove(currPath, x, y + 1))
                SolveMaze(results, maze, x, y + 1, currPath);
            
            // Left
            if (maze.IsValidMove(currPath, x - 1, y))
                SolveMaze(results, maze, x - 1, y, currPath);
            
            // Right
            if (maze.IsValidMove(currPath, x + 1, y))
                SolveMaze(results, maze, x + 1, y, currPath);
        }

        // Backtrack: Remove the current position from path (to allow other paths)
        currPath.RemoveAt(currPath.Count - 1);
    }
}