/*
Dado um array nums e um inteiro k, retorne a maior média entre todas as subarrays de tamanho k.

Input: nums = [1,12,-5,-6,50,3], k = 4
Output: 12.75

Input: nums = [5,5,5,5,5], k = 2
Output: 5.0

Input: nums = [0,4,0,3,2], k = 1
Output: 4.0

Input: nums = [7,4,5,2,6,2], k = 3
Output: 5.666

Input: nums = [-1,-12,-5,-6,-50,-3], k = 2
Output: -1.0

*/


int[] nums = { 1, 12, -5, -6, 50, 3 };
Console.WriteLine(Math.Round(new Solution().FindMaximumAverageSubarrayOfSizeK(nums,4),2) == 12.75);

int[] nums2 = { 5, 5, 5, 5, 5 };
Console.WriteLine(Math.Round(new Solution().FindMaximumAverageSubarrayOfSizeK(nums2, 2),2) == 5.00);

int[] nums3 = { 0, 4, 0, 3, 2 };
Console.WriteLine(Math.Round(new Solution().FindMaximumAverageSubarrayOfSizeK(nums3, 1),2) == 4.0);

int[] nums4 = { 7, 4, 5, 2, 6, 2 };
Console.WriteLine(Math.Round(new Solution().FindMaximumAverageSubarrayOfSizeK(nums4, 3),2) == 5.33);

int[] nums5 = { -1, -12, -5, -6, -50, -3 };
Console.WriteLine(Math.Round(new Solution().FindMaximumAverageSubarrayOfSizeK(nums5, 2),2) == -5.50);


public class Solution
{
    public float FindMaximumAverageSubarrayOfSizeK(int[] nums, int k) 
    {
        float sum = 0;

        float window_avg = 0;
        float max_avg = float.MinValue;

        for (int i = 0; i < nums.Length; i++) 
        {
            sum += nums[i];
            if ( i >= k -1) 
            { 
                window_avg = sum / k ;
                max_avg = Math.Max(max_avg, window_avg);

                sum -= nums[i - k + 1];//tirar o primeiro valor
            }
        }

        return max_avg;
    }


}