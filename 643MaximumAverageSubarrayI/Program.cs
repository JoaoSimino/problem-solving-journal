//Input: nums = [1,12,-5,-6,50,3], k = 4
//Output: 12.75000
//Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75


using System.Numerics;

int[] nums = { 1, 12, -5, -6, 50, 3 };
int k = 4;



var solution = new Solution().FindMaxAverage(nums,k);
Console.WriteLine(solution);

public class Solution
{
    public double FindMaxAverage(int[] nums, int target)
    {
        double window_sum = 0;
        double window_avg = 0;
        double max_window_avg = double.MinValue;
        for (int i = 0; i < nums.Length; i++) 
        {
            window_sum += nums[i];
            if (i >= target - 1) 
            {
                window_avg = window_sum / target;
                max_window_avg = Math.Max(window_avg, max_window_avg);
                window_sum -= nums[i - target + 1];//ajustando agora a janela tirando o primeiro elemento
            }


        }
        return max_window_avg;
    }
}