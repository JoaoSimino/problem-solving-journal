//nums = [3, 1, 2]
//result = -1

//nums = [7,9,5,8,1,3]
//result = 1


int[] numeros = new int[] { 7, 9, 5, 8, 1, 3 };
var result = new Solution().MinimumDifference(numeros);

Console.WriteLine(result);


public class Solution
{
    public long MinimumDifference(int[] nums)
    {
        int n = nums.Length / 3;
        int len = nums.Length;

        long[] leftSums = new long[len];
        long[] rightSums = new long[len];

        // Minimize left sum (largest n values from left)
        PriorityQueue<int, int> maxHeap = new(); // simulate maxHeap using negative priority
        long leftSum = 0;
        for (int i = 0; i < len; i++)
        {
            maxHeap.Enqueue(nums[i], -nums[i]);
            leftSum += nums[i];

            if (maxHeap.Count > n)
            {
                int removed = maxHeap.Dequeue();
                leftSum -= removed;
            }

            if (i >= n - 1)
                leftSums[i] = leftSum;
        }

        // Maximize right sum (smallest n values from right)
        PriorityQueue<int, int> minHeap = new(); // regular minHeap
        long rightSum = 0;
        for (int i = len - 1; i >= 0; i--)
        {
            minHeap.Enqueue(nums[i], nums[i]);
            rightSum += nums[i];

            if (minHeap.Count > n)
            {
                int removed = minHeap.Dequeue();
                rightSum -= removed;
            }

            if (i <= len - n)
                rightSums[i] = rightSum;
        }

        // Calculate the minimum difference
        long result = long.MaxValue;
        for (int i = n - 1; i < len - n; i++)
        {
            long diff = leftSums[i] - rightSums[i + 1];
            result = Math.Min(result, diff);
        }

        return result;
    }
}

