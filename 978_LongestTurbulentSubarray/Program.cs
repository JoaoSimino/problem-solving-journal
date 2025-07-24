/*
Given an integer array arr, return the length of a maximum size turbulent subarray of arr.

A subarray is turbulent if the comparison sign flips between each adjacent pair of elements in the subarray.

More formally, a subarray [arr[i], arr[i + 1], ..., arr[j]] of arr is said to be turbulent if and only if:

For i <= k < j:
arr[k] > arr[k + 1] when k is odd, and
arr[k] < arr[k + 1] when k is even.

Or, for i <= k < j:
arr[k] > arr[k + 1] when k is even, and
arr[k] < arr[k + 1] when k is odd.
 

Example 1:
Input: arr = [9,4,2,10,7,8,8,1,9]
Output: 5
Explanation: arr[1] > arr[2] < arr[3] > arr[4] < arr[5]

Example 2:
Input: arr = [4,8,12,16]
Output: 2

Example 3:
Input: arr = [100]
Output: 1
  
*/

int[] arr = { 4, 8, 12, 16 };

Console.WriteLine(new Solution().MaxTurbulenceSize(arr) == 2);

public class Solution
{
    public int MaxTurbulenceSize(int[] arr)
    {
        if (arr.Length == 1) return 1;

        int wind_size = 1;
        int max_size = 1;
        int pos_atual = 0;

        while (pos_atual + 1 < arr.Length)
        {
            int atual = arr[pos_atual];
            int next = arr[pos_atual + 1];

            if (atual == next)
            {
                wind_size = 1;
                pos_atual++;
                continue;
            }

            wind_size = 2; // Começamos com dois elementos diferentes

            // Expandir janela enquanto for turbulento, eh a solucao mais facil e elegante
            int i = pos_atual + 1;
            while (i + 1 < arr.Length && trocouSinal(arr[i - 1], arr[i], arr[i + 1]))
            {
                wind_size++;
                i++;
            }

            max_size = Math.Max(max_size, wind_size);
            pos_atual = i;
        }

        return max_size;
    }

    bool trocouSinal(int a, int b, int c)
    {
        return (a > b && b < c) || (a < b && b > c);
    }
}
