//Given a string s, find the length of the longest substring without duplicate characters. => Sliding Window dynamic
/*
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.


Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
*/

//validando opcoes do leetcode!

using System.Collections.Generic;

Console.WriteLine(new Solution().LengthOfLongestSubstring("abcabcbb")==3);
Console.WriteLine(new Solution().LengthOfLongestSubstring("bbbbb") == 1);
Console.WriteLine(new Solution().LengthOfLongestSubstring("pwwkew") == 3);

public class Solution
{
    public int LengthOfLongestSubstring(string str)
    {
        int tamanho_window = 0;
        int tamanho_maximo = 0;
        int inicio = 0;

        Dictionary<char, int> ultimasOcorrencias = new(); //melhor solucao hash 0(1)


        for (int i = 0; i < str.Length; i++) 
        {
            char c = str[i];

            //minha maneira inicial ate mais performatica!!!
            //if (ultimasOcorrencias.ContainsKey(c) && ultimasOcorrencias[c] >= inicio) 
            //{
            //    //meu inicio nao deve ser daqui pra frente!, deve ser da posicao de de primeira ocorrencia de str[i] para frente
            //    inicio = ultimasOcorrencias[c] + 1;
            //}
            while (ultimasOcorrencias.ContainsKey(c)) 
            {
                ultimasOcorrencias.Remove(str[inicio]);
                inicio++;
            }

            ultimasOcorrencias[c] = i;// Atualiza sempre com a última posição
            
            tamanho_window = i - inicio + 1;
            tamanho_maximo = int.Max(tamanho_window, tamanho_maximo);
            
        }
        return tamanho_maximo;
    }
}