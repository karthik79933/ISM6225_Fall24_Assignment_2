using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 1,1,1};
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 3,2,4 };
            int target = 6;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 10;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = {4, 5, 6, 7, 0, 1, 2};
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 10;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 30;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {   // Write your code here
                // Validate input array
        if (nums == null || nums.Length == 0)
            throw new ArgumentException("Input array cannot be null or empty");

              // Use HashSet for O(1) lookups to identify existing numbers
              HashSet<int> existingNumbers = new HashSet<int>(nums);
              List<int> missingNumbers = new List<int>();

              // Check each number in the expected range [1, n]
        // where n = array length (since numbers should be 1 to n)
        for (int i = 1; i <= nums.Length; i++)
        {
            // Add to missing list if number not found in the set
            if (!existingNumbers.Contains(i))
            {
                missingNumbers.Add(i);
            }
        }
        return missingNumbers;
             
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Validate input
        if (nums == null || nums.Length == 0)
            throw new ArgumentException("Input array cannot be null or empty");

        // Separate even and odd numbers
        List<int> evens = new List<int>();
        List<int> odds = new List<int>();

        foreach (int num in nums)
        {
            if (num % 2 == 0)
                evens.Add(num);
            else
                odds.Add(num);
        }

        // Sort both lists
        evens.Sort();
        odds.Sort();

        // Merge even and odd lists into a result array
        int[] result = new int[nums.Length];
        int index = 0;

        foreach (int even in evens)
            result[index++] = even;

        foreach (int odd in odds)
            result[index++] = odd;

        return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
               // Validate input
        if (nums == null || nums.Length < 2)
            throw new ArgumentException("Input array must have at least two elements.");

        // Dictionary to store numbers and their indices
        Dictionary<int, int> numToIndex = new Dictionary<int, int>();

        // Iterate through the array
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i]; // The number we need to find

            // Check if complement exists in the dictionary
            if (numToIndex.ContainsKey(complement))
            {
                // If found, return indices of complement and current number
                return new int[] { numToIndex[complement], i };
            }

            // If not found, store current number and its index
            if (!numToIndex.ContainsKey(nums[i]))
                numToIndex[nums[i]] = i;
        }

        // If no solution is found, return an empty array
        return new int[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
               // Validate input
        if (nums == null || nums.Length < 3)
            throw new ArgumentException("Array must have at least three numbers.");
        
        // Sort the array to easily access the largest and smallest values
        Array.Sort(nums);
        
        // After sorting, the largest product will be either:
        // 1. The product of the three largest numbers (last three elements in the sorted array)
        // 2. The product of the two smallest numbers (the most negative numbers) and the largest number.
        
        // Option 1: Product of the three largest numbers
        int option1 = nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3];
        
        // Option 2: Product of the two smallest numbers (most negative) and the largest number
        int option2 = nums[0] * nums[1] * nums[nums.Length - 1];
        
        // Return the maximum of the two options
        return Math.Max(option1, option2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Edge case: if the number is 0, return "0" because the binary equivalent of 0 is simply 0
        if (decimalNumber == 0)
            return "0";
        
        // Initialize a string to hold the binary result
        string binaryResult = "";

        // Loop to perform division and get the remainder (binary digit)
        while (decimalNumber > 0)
        {
            // Get the remainder when divided by 2 (this gives us the binary digit)
            int remainder = decimalNumber % 2;
            
            // Add the remainder (binary digit) to the front of the result string
            binaryResult = remainder.ToString() + binaryResult;

            // Update decimalNumber by dividing it by 2 to process the next digit
            decimalNumber = decimalNumber / 2;
        }

        // Return the final binary string result
        return binaryResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Edge case: If the array has only one element, return it as the minimum.
        if (nums.Length == 1)
            return nums[0];

        // Initialize the pointers for binary search
        int low = 0;
        int high = nums.Length - 1;

        // Perform binary search to find the minimum element
        while (low < high)
        {
            int mid = low + (high - low) / 2; // Calculate mid index

            // If mid element is greater than the high element, the minimum is in the right half
            if (nums[mid] > nums[high])
            {
                low = mid + 1; // Move the low pointer to the right half
            }
            // If mid element is less than or equal to the high element, the minimum is in the left half
            else
            {
                high = mid; // Move the high pointer to mid (inclusive)
            }
        }

        // After the loop ends, low will be pointing to the minimum element
        return nums[low];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Edge case: Negative numbers are not palindromes
        // A negative number cannot be a palindrome because the negative sign will not match
        if (x < 0)
            return false;

        // Edge case: A number ending in 0 (except 0 itself) cannot be a palindrome
        // Numbers like 10, 100, etc., are not palindromes because the reverse would start with a zero
        if (x % 10 == 0 && x != 0)
            return false;

        int reversedHalf = 0;

        // Reverse only half of the number to avoid overflow and achieve efficiency
        // We stop when x becomes less than or equal to reversedHalf
        while (x > reversedHalf)
        {
            int lastDigit = x % 10;  // Extract the last digit
            reversedHalf = reversedHalf * 10 + lastDigit;  // Build the reversed number
            x /= 10;  // Remove the last digit from the original number
        }

        // After the loop, x will be smaller or equal to reversedHalf
        // If the length of the number is odd, reversedHalf will have one extra digit.
        // So, we compare x with reversedHalf or reversedHalf / 10 to handle both even and odd lengths.
        return x == reversedHalf || x == reversedHalf / 10;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                 // Edge case: If n is 0 or 1, return n directly (base cases of Fibonacci sequence)
        if (n == 0)
            return 0;
        if (n == 1)
            return 1;

        // Initialize variables to store Fibonacci numbers at previous two positions
        int prev1 = 0; // F(0)
        int prev2 = 1; // F(1)

        // Loop to calculate Fibonacci number for n >= 2
        for (int i = 2; i <= n; i++)
        {
            int current = prev1 + prev2;  // F(i) = F(i-1) + F(i-2)
            prev1 = prev2;  // Update prev1 to previous prev2 value
            prev2 = current;  // Update prev2 to the newly calculated Fibonacci number
        }

        // Return the Fibonacci number for F(n)
        return prev2;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
