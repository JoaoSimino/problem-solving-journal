//nums = [2, 1, 5, 1, 3, 2], k = 3

//Dado um array de inteiros positivos e um número k, encontre a maior soma possível de qualquer subarray contínuo de tamanho k.
//-- Inputs
int[] nums = { 2, 1, 5, 1, 3, 2 };
int k = 3;
//-- Inputs

//-- Innfra
int window_soma = 0;
int max_soma = 0;
//-- Innfra



Console.WriteLine(Sling_Window());

int Sling_Window() 
{
    for (int i = 0; i < nums.Length; i++) 
    {
        window_soma += nums[i];
        if (i >= k - 1 ) 
        {
            if (window_soma > max_soma) 
            {
                max_soma = window_soma;
                
            }
            window_soma -= nums[i - k + 1];  //removendo elemento que saiu da janela, e a janela deve sempre se mover!
        }
    }
    return max_soma;
}