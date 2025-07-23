/*Dado um array ordenado estritamente crescente de inteiros positivos, retorne o K-ésimo número positivo que está faltando na sequência.
 

Input: arr = [2,3,4,7,11], k = 5
Output: 9

Input: arr = [1,2,3,4], k = 2
Output: 6

Input: arr = [1,3,5,7,9], k = 4
Output: 8

Input: arr = [2], k = 1
Output: 1

Input: arr = [5,6,7], k = 2
Output: 2
 
*/

int[] arr = { 2, 3, 4, 7, 11 };
Console.WriteLine(new Solution().FindKMIssing(arr, 5) == 9);

int[] arr2 = { 1, 2, 3, 4 };
Console.WriteLine(new Solution().FindKMIssing(arr2, 2) == 6);

int[] arr3 = { 1, 3, 5, 7, 9 };
Console.WriteLine(new Solution().FindKMIssing(arr3, 4) == 8);

int[] arr4 = { 2 };
Console.WriteLine(new Solution().FindKMIssing(arr4, 1) == 1);

int[] arr5 = { 5 , 6, 7};
Console.WriteLine(new Solution().FindKMIssing(arr5, 2) == 2);


public class Solution
{
    public int FindKMIssing(int[] nums, int k)
    {
        int pos = 0;
        int missing_count = 0;
        for (int i = 0; i < nums.Length; i++) 
        {
            while (++pos < nums[i]) 
            {
                missing_count++;
                if (missing_count == k) 
                {
                    return pos;
                }
            }
        }//as faltas devem completar a frente do array!
        return pos + k - missing_count;
    }
    
}