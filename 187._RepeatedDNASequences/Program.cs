/*
The DNA sequence is composed of a series of nucleotides abbreviated as 'A', 'C', 'G', and 'T'.

For example, "ACGAATTCCG" is a DNA sequence.
When studying DNA, it is useful to identify repeated sequences within the DNA.

Given a string s that represents a DNA sequence, return all the 10-letter-long sequences (substrings) that occur more than once in a DNA molecule. You may return the answer in any order.

 

Example 1:

Input: s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"
Output: ["AAAAACCCCC","CCCCCAAAAA"]
Example 2:

Input: s = "AAAAAAAAAAAAA"
Output: ["AAAAAAAAAA"] 
 
*/

string sequencia = "AAAAAAAAAAAAA";
Console.WriteLine(new Solution().FindRepeatedDnaSequences(sequencia));

public class Solution
{
    public IList<string> FindRepeatedDnaSequences(string s)
    {
        if (s.Length < 10)
            return new List<string>();

        HashSet<string> seen = new();
        HashSet<string> repeated = new();
        char[] window = new char[10];

        for (int i = 0; i <= s.Length - 10; i++)
        {
            for (int j = 0; j < 10; j++)
                window[j] = s[i + j];

            string current = new string(window);
            if (!seen.Add(current))
                repeated.Add(current);
        }

        return repeated.ToList();
    }
}