/*

Given a binary array nums and an integer k, return the maximum number of consecutive 1's in the array if you can flip at most k 0's.

Example 1:

Input: nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2
Output: 6
Explanation: [1,1,1,0,0,1,1,1,1,1,1]
Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.
Example 2:

Input: nums = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], k = 3
Output: 10
Explanation: [0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1]
Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.

*/

Console.WriteLine(new Solution().LongestOnes(new int[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 },2) == 6);

Console.WriteLine(new Solution().LongestOnes(new int[] { 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1 }, 3) == 10);

Console.WriteLine(new Solution().LongestOnes(new int[] { 0, 0, 0, 1 }, 4) == 4);

public class Solution
{
    public int LongestOnes(int[] nums, int k)
    {
        int left = 0, right = 0;
        int zeros = 0;
        int maxLen = 0;

        while (right < nums.Length)
        {
            if (nums[right] == 0)
                zeros++;

            while (zeros > k)
            {
                if (nums[left] == 0)
                    zeros--;
                left++;
            }

            maxLen = Math.Max(maxLen, right - left + 1);
            right++;
        }

        return maxLen;
    }
}