/*
 Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

Note that you must do this in-place without making a copy of the array.

 

Example 1:

Input: nums = [0,1,0,3,12]
Output: [1,3,12,0,0]
Example 2:

Input: nums = [0]
Output: [0]
*/

int[] nums = {0, 1, 0, 3, 12};
new Solution().MoveZeroes(nums);

foreach (int num in nums) 
{
    Console.Write(num);
    Console.Write("  ");
}

public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        int left = 0; //posicao que ele deve ocupar 

        //[5,0,1,0,3,12]
        for (int right = 0; right < nums.Length; right++) //elementos que nao sao zeros
        {
            if (nums[right] != 0) 
            {
                int temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp; 
                left++;
            }
        }
    }
}