/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;
using System.Xml.Linq;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Net.Mime.MediaTypeNames;
using System.Buffers.Text;
using System.Drawing;
using System.Net.Sockets;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection.Metadata;
using System.Threading;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3,6,9,1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2,1,2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                if (nums.Length == 0)
                    return 0;

                int uniqueCount = 1; 

                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] != nums[uniqueCount - 1]) 
                    {
                        nums[uniqueCount] = nums[i]; 
                        uniqueCount++; 
                    }
                }

                return uniqueCount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*Explaination:
        The function iterates through the array, keeping track of unique elements.When encountering a new 
            unique element,it updates the array and increments the count.It returns the count of unique elements.
        */
        
        
        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                int not_zero_index = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        nums[not_zero_index] = nums[i];
                        not_zero_index++;
                    }
                }

                //adding 0 to rest of the array
                while (not_zero_index < nums.Length)
                {
                    nums[not_zero_index] = 0;
                    not_zero_index++;
                }

                // Converting the array to list
                return nums.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured in the code: " + ex.Message);
                throw;
            }
        }
        /* Explaination:
        This function takes an integer array called nums as input.
It iterates through the array, moving all non-zero elements to the front of the array, maintaining their relative order.
Once all non-zero elements are moved, it fills the rest of the array with zeros.
Finally, it converts the modified array back to a list and returns it.
Overall, the function moves all zeros to the end of the array while keeping the non-zero elements in the same order.
        */
        
        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                Array.Sort(nums); // Sort the array to simplify the process

                IList<IList<int>> result = new List<IList<int>>();

                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Skip duplicates
                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;

                    int left = i + 1;
                    int right = nums.Length - 1;

                    while (left < right)
                    {
                        int sum = nums[i] + nums[left] + nums[right];

                        if (sum == 0)
                        {
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });

                            // Skip duplicates
                            while (left < right && nums[left] == nums[left + 1])
                                left++;
                            while (left < right && nums[right] == nums[right - 1])
                                right--;

                            left++;
                            right--;
                        }
                        else if (sum < 0)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         Explaination:
This function takes an integer array called nums as input and finds all unique triplets where the sum equals zero.
It sorts the array to simplify the process and avoid duplicate solutions.
Using a nested loop, it iterates through the array, checking each possible combination of triplets.
It ensures no duplicate triplets are added to the result set.
Finally, it returns a list of lists containing all unique triplets whose sum is zero.
        */

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                int maxCount = 0;
                int currentCount = 0;

                foreach (int num in nums)
                {
                    if (num == 1)
                    {
                        currentCount++;
                        maxCount = Math.Max(maxCount, currentCount);
                    }
                    else
                    {
                        currentCount = 0;
                    }
                }

                return maxCount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         This function takes a binary array called nums as input and finds the maximum number of consecutive 1's in the array.
It iterates through the array, keeping track of the current consecutive count of 1's and updating the maximum count encountered so far.
Whenever a 0 is encountered, it resets the current count.
Finally, it returns the maximum count of consecutive 1's found in the array.
Overall, the function efficiently identifies the longest consecutive sequence of 1's in the binary array.
        */

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int decimalNumber = 0;
                int baseValue = 1; // Base value for binary conversion starts at 1

                while (binary > 0)
                {
                    int lastDigit = binary % 10; // Extract the last digit of the binary number
                    binary = binary / 10; // Remove the last digit from the binary number

                    decimalNumber += lastDigit * baseValue; // Multiply the last digit by the appropriate base value and add to the decimal number
                    baseValue *= 2; // Update the base value for the next digit
                }

                return decimalNumber;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*  Explaination
        This program converts a binary number to its equivalent decimal representation.
It prompts the user to input a binary number as an integer and then calls the BinaryToDecimal function to perform the conversion.
The BinaryToDecimal function iterates through the binary number's digits from right to left.
For each digit, it multiplies the digit by its corresponding power of 2 and adds it to the total decimal value.
Finally, it returns the decimal representation of the binary number.
Overall, the program efficiently converts binary numbers to decimal without using bitwise operators or the Math.Pow function.

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                if (nums.Length < 2)
                    return 0;

                // Find the minimum and maximum values in the array
                int minValue = int.MaxValue;
                int maxValue = int.MinValue;
                foreach (int num in nums)
                {
                    minValue = Math.Min(minValue, num);
                    maxValue = Math.Max(maxValue, num);
                }

                // Calculate the bucket size and the number of buckets
                int bucketSize = Math.Max(1, (maxValue - minValue) / (nums.Length - 1));
                int bucketCount = (maxValue - minValue) / bucketSize + 1;

                // Initialize buckets
                int[] minBucket = new int[bucketCount];
                int[] maxBucket = new int[bucketCount];
                for (int i = 0; i < bucketCount; i++)
                {
                    minBucket[i] = int.MaxValue;
                    maxBucket[i] = int.MinValue;
                }

                // Update minBucket and maxBucket for each element
                foreach (int num in nums)
                {
                    int bucketIndex = (num - minValue) / bucketSize;
                    minBucket[bucketIndex] = Math.Min(minBucket[bucketIndex], num);
                    maxBucket[bucketIndex] = Math.Max(maxBucket[bucketIndex], num);
                }

                // Calculate the maximum gap between consecutive buckets
                int maxGap = 0;
                int previousMax = minValue;
                for (int i = 0; i < bucketCount; i++)
                {
                    if (minBucket[i] != int.MaxValue && maxBucket[i] != int.MinValue)
                    {
                        maxGap = Math.Max(maxGap, minBucket[i] - previousMax);
                        previousMax = maxBucket[i];
                    }
                }

                return maxGap;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Explaination:
        This function, MaximumGap, finds the maximum difference between two successive elements in a sorted form of the input array.
        It first determines the minimum and maximum values in the array to establish the range of values.
Then, it calculates the bucket size and the number of buckets based on the array's range and size.
Next, it initializes buckets and updates them for each element to store minimum and maximum values within each bucket.
Finally, it computes the maximum gap by finding the difference between the minimum of a bucket and the previous bucket's maximum.
The function returns the maximum gap found, representing the maximum difference between successive elements in the sorted array.

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                Array.Sort(nums); 
                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    if (nums[i - 2] + nums[i - 1] > nums[i]) 
                    {
                        return nums[i - 2] + nums[i - 1] + nums[i]; 
                    }
                }

                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* Explaination:-
        This function, LargestPerimeter, finds the largest perimeter of a triangle that can be formed using side lengths from the input array.
    It first sorts the array to simplify the checking process.
Then, it iterates through the sorted array from the end, checking if the sum of the two smaller sides is greater than the largest side (triangle inequality).
If such a triangle can be formed, it returns the sum of the three sides as the largest perimeter.
If no such triangle can be formed, it returns 0, indicating it's impossible to form a triangle with a non-zero area.
Overall, the function efficiently determines the largest possible perimeter of a valid triangle.

        /*
 
        Question:8
 
        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:
 
        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.
 
        A substring is a contiguous sequence of characters in a string.
 
 
        Example 1:
 
        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:
 
        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".
 
        Constraints:
 
        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s and part consists of lowercase English letters.
 
        */

        public static string RemoveOccurrences(string s, string part)
        {

            try
            {
                while (s.Contains(part))
                {
                    int index = s.IndexOf(part);
                    s = s.Remove(index, part.Length);
                }
                return s;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}

/*

This RemoveOccurrences function takes two strings, s and part, and removes all occurrences of part from s.
It continuously finds the leftmost occurrence of part in s and removes it until no more occurrences exist.
The function iterates using a while loop and utilizes the IndexOf and Remove methods to perform the removal of part.
It returns the modified string s after removing all occurrences of part.
Overall, the function effectively removes all instances of the specified substring from the input string, s.
*/