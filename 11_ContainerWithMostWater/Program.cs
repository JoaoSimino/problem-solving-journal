﻿/*

You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).

Find two lines that together with the x-axis form a container, such that the container contains the most water.

Return the maximum amount of water a container can store.

Notice that you may not slant the container.

Input: height = [1,8,6,2,5,4,8,3,7]
Output: 49
Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.
Example 2:

Input: height = [1,1]
Output: 1
 
*/
int[] height = { 8, 7, 2, 1 };

Console.WriteLine(new Solution().MaxArea(height));

public class Solution
{
    public int MaxArea(int[] height)
    {
        
        int max_area = 0;
        int left = 0;
        int right = height.Length - 1;

        //deixando fixo primeiro altura e variando as bases
        while (left < right)
        {
            int minHeight = Math.Min(height[left], height[right]);
            int width = right - left;
            int area = minHeight * width;

            max_area = Math.Max(max_area, area);

            //movimento inteligente, pulo do gato!
            if (height[left] < height[right])
                left++;
            else
                right--;

        }
        
        return max_area;
    }
}