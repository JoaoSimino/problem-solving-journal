//Dado um array de inteiros positivos nums e um inteiro target, encontre o menor comprimento de um subarray contínuo cuja soma seja maior ou igual a target.
//Se nenhum subarray atender a essa condição, retorne 0.

//entrada
int[] nums = { 2, 3, 1, 2, 4, 3 };
int target = 7;

//resultad0 Saída esperada: 2 (Soma mínima ≥ 7 é alcançada no subarray [4,3])

Console.WriteLine(DynamicSlidingWindow());

int DynamicSlidingWindow()
{
    int inicio = 0;
    int soma = 0;
    int menor_tamanho = int.MaxValue;

    for (int i = 0; i < nums.Length; i++)
    {
        soma += nums[i];

        while (soma >= target) //quando passa o valor da soma, eu comeco a diminuir pelo comeco para tentar encontrar a substring menor de solucao, a hora que dimiunir do target sigo colocando os valores restantes
        {
            int tamanho_atual = i - inicio + 1;
            menor_tamanho = Math.Min(menor_tamanho, tamanho_atual);
            soma -= nums[inicio];//verificar se uma solucao menor atende
            inicio++;//ajustando inicio do vetor, que se mantera inclusive para os valores faltantes de adicionar do array!

        }
    }


    return menor_tamanho == int.MaxValue ? 0 : menor_tamanho;//se nao encontrar solucao retorna 0
}

