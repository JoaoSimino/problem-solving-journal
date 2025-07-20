//com conceitos aprendidos de DC como base, dividir para conquistar!

int[] array = { 9, 3, 7, 1, 8, 2, 5 };

var result = QuickSort(array);

foreach (var item in result) 
{
    Console.WriteLine(item);
}

int[] QuickSort(int[] array) 
{
    List<int> maiores = new();
    List<int> menores = new();

    //condicao de parada..., array com tamanho de um nao precisa ser ordenado !!
    if (array.Length <= 1)
        return array;

    //selecionando o primeiro item do array como pivo
    int pivo = array[0];

    for (int i = 1; i < array.Length ; i++)
    {
        if (array[i] > pivo)
        {
            maiores.Add(array[i]);
        }
        else 
        {
            menores.Add(array[i]);
        }
    }

    int[] resultado = QuickSort(menores.ToArray())// pulo do gato de escrita do algoritmo!!
        .Concat(new int[] { pivo })
        .Concat(QuickSort(maiores.ToArray()))
        .ToArray();

    return resultado;
}