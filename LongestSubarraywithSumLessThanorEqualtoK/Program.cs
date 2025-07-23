/*
Dado um array de inteiros positivos nums e um inteiro k, retorne o comprimento da maior subarray cuja soma seja menor ou igual a k. 
*/

/*Casos de TESTES
Input: nums = [1, 2, 1, 0, 1, 1, 0], k = 4
Output: 5

Input: nums = [1, 1, 1, 1, 1], k = 2
Output: 2

Input: nums = [2, 2, 2, 2], k = 3
Output: 1

Input: nums = [3, 1, 2, 1], k = 4
Output: 3

Input: nums = [1, 2, 3, 4, 5], k = 9
Output: 3


Input: nums = [10, 11, 6, 4, 5], k = 3
Output: 0
*/

int[] nums = { 1, 2, 1, 0, 1, 1, 0 };
Console.WriteLine(new Solution().MaiorSubarrayComSomaMenorQueK(nums,4)==5);

int[] num2 = { 1, 1, 1, 1, 1 };
Console.WriteLine(new Solution().MaiorSubarrayComSomaMenorQueK(num2, 2) == 2);

int[] nums3 = { 2, 2, 2, 2 };
Console.WriteLine(new Solution().MaiorSubarrayComSomaMenorQueK(nums3, 3) == 1);

int[] nums4 = { 3, 1, 2, 1 };
Console.WriteLine(new Solution().MaiorSubarrayComSomaMenorQueK(nums4, 4) == 3);

int[] nums5 = { 1, 2, 3, 4, 5 };
Console.WriteLine(new Solution().MaiorSubarrayComSomaMenorQueK(nums5, 9) == 3);


int[] nums6 = { 10, 11, 6, 4, 5 };
Console.WriteLine(new Solution().MaiorSubarrayComSomaMenorQueK(nums5, 9) == 3);

public class Solution
{
    public int MaiorSubarrayComSomaMenorQueK(int[] nums, int valor_soma) 
    {

        int sum = 0;
        int posicao_remocao = 0;
        int maior_tamanho = 0;
        int tamanho_janela = 0;

        //soma igual menor ou igual a k
        //maior array
        //janela deslizante dinamica
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            
            while (sum > valor_soma) 
            {
                //vou removendo os elementos partindo do inicio, inversao de logica ate que o valor fique denovo dentro do pedido!
                sum -= nums[posicao_remocao++];
            }

            tamanho_janela = i - posicao_remocao + 1;
            maior_tamanho = Math.Max(maior_tamanho, tamanho_janela);

        }


        return maior_tamanho;
    }
}

