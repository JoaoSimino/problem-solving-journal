﻿/*
Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number. Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.

Return the indices of the two numbers, index1 and index2, added by one as an integer array [index1, index2] of length 2.

The tests are generated such that there is exactly one solution. You may not use the same element twice.

Your solution must use only constant extra space.

 

Example 1:

Input: numbers = [2,7,11,15], target = 9
Output: [1,2]
Explanation: The sum of 2 and 7 is 9. Therefore, index1 = 1, index2 = 2. We return [1, 2].
Example 2:

Input: numbers = [2,3,4], target = 6
Output: [1,3]
Explanation: The sum of 2 and 4 is 6. Therefore index1 = 1, index2 = 3. We return [1, 3].
Example 3:

Input: numbers = [-1,0], target = -1
Output: [1,2]
Explanation: The sum of -1 and 0 is -1. Therefore index1 = 1, index2 = 2. We return [1, 2]. 
 
*/

//teste
int[] numbers = { -10, -8, -2, 1, 2, 5, 6 };
var result = new Solution().TwoSum(numbers, 0);
foreach (var item in result)
{
    Console.WriteLine(item);
}

//funciona mais excede o tempo Time Limit Exceeded, preciso otimizar!
public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int left = 0;
        int right = numbers.Length - 1;

        while (left < right)//sem for, apenas while basta!
        {
            int sum = numbers[left] + numbers[right];
            if (sum == target)
            {
                return new int[] { left + 1, right + 1 }; 
            }
            else if (sum < target)
            {
                left++; // precisa de um número maior, e o array deve estar ordenado
            }
            else
            {
                right--; // precisa de um número menor, e o array deve estar ordenado
            }
        }

        return Array.Empty<int>();//sem solucao
    }
}