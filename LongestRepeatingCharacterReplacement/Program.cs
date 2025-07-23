/*
Dada uma string s e um inteiro k, você pode trocar até k caracteres para que a string contenha a maior substring possível com apenas um caractere repetido.

Input: s = "ABAB", k = 2
Output: 4

Input: s = "AABABBA", k = 1
Output: 4

Input: s = "ABCDE", k = 2
Output: 3

Input: s = "AAAA", k = 0
Output: 4

Input: s = "ABBB", k = 2
Output: 4
 
*/

Console.WriteLine(new Solution().FindLongestRepeatingCharacter("ABAB", 2) == 4);
Console.WriteLine(new Solution().FindLongestRepeatingCharacter("AABABBA", 1) == 4);
Console.WriteLine(new Solution().FindLongestRepeatingCharacter("ABCDE", 2) == 3);
Console.WriteLine(new Solution().FindLongestRepeatingCharacter("AAAA", 0) == 4);
Console.WriteLine(new Solution().FindLongestRepeatingCharacter("ABBB", 2) == 4);


public class Solution() 
{

    public int FindLongestRepeatingCharacter(string str , int max_trocas )
    {
        int start = 0;
        int end = 0;

        Dictionary<char,int> frequencia = new Dictionary<char, int>();

        int maxFreq = 0;
        int maxLength = 0;

        for (end = 0; end < str.Length; end++) 
        {
            char c = str[end];

            if (!frequencia.ContainsKey(c))
                frequencia[c] = 0;
            frequencia[c]++;

            maxFreq = Math.Max(maxFreq, frequencia[c]);

            if (!podemosTrocar(end, start, maxFreq, max_trocas))
            {
                frequencia[str[start]]--;
                start++;
            }

            maxLength = Math.Max(maxLength, end - start + 1);

        }

        return maxLength;
    }

    bool podemosTrocar(int end, int start, int maxfreq, int k)
    {
        int windows_size = end - start + 1;
        if (windows_size - maxfreq <= k)
        {
            return true;
        }
        return false;
    }

}