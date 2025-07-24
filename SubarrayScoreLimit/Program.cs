/*
Dado um array de inteiros positivos nums e um número inteiro score, você deve encontrar o comprimento máximo de uma subarray contínua tal que:

O valor de (soma dos elementos da subarray) * (mínimo elemento da subarray) seja menor ou igual a score.

Retorne esse comprimento máximo possível.

nums = [1, 2, 3, 4]
score = 15
Resposta esperada: 3

Justificativa: A subarray [2, 3, 4] tem soma 9, mínimo 2 → 9 * 2 = 18 > 15.
Mas [1, 2, 3] → soma 6, mínimo 1 → 6 * 1 = 6 <= 15 → tamanho 3.

sliding window dinamica
*/

var s = new Solution();
Console.WriteLine(s.SubarrayScoreLimit(new[] { 1, 2, 3, 4 }, 15) == 3); // [1,2,3]
Console.WriteLine(s.SubarrayScoreLimit(new[] { 4, 2, 1, 2, 4 }, 8) == 3); // [1,2,4]
Console.WriteLine(s.SubarrayScoreLimit(new[] { 5, 1, 2, 3, 1 }, 10) == 2); // [5] ou [1,2]
Console.WriteLine(s.SubarrayScoreLimit(new[] { 8, 1, 1, 1, 8 }, 16) == 3); // [1,1,1]
Console.WriteLine(s.SubarrayScoreLimit(new[] { 3, 3, 3, 3 }, 36) == 4); // tudo

public class Solution
{
    public int SubarrayScoreLimit(int[] nums, int score)
    {


        return 0;
    }
}


