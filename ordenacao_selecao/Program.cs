//pouco eficiente, ainda mais com tamanho do array crescendo!
//BigO(n*n)
Musica[] array = new Musica[]
{
    new Musica("RADIOHEAD",156),
    new Musica("kISHORE KUMAR",141),
    new Musica("THE BALCK EYES",35),
    new Musica("NEUTRAL MILK HOTEL",94),
    new Musica("BECK",88),
    new Musica("THE STROKES",61),
    new Musica("WILCO",111)
};

var ordenacao = new OrdenacaoPorSelecao<Musica, int>(array, m => m.ContadorDePlays);

foreach (var item in ordenacao.ArrayOrdenado)
{
    Console.WriteLine($"{item.Cantor} - {item.ContadorDePlays}");
}


//-----

public class Musica 
{
    public Musica(string cantor, int contadorDePlays)
    {
        Cantor = cantor;
        ContadorDePlays = contadorDePlays;
    }
    public string Cantor { get; set; }
    public int ContadorDePlays { get; set; }
}

public class OrdenacaoPorSelecao<T,Y> where Y : IComparable<Y>
{
    public T[] ArrayOrdenado { get; }

    public OrdenacaoPorSelecao(T[] array, Func<T, Y> seletor)
    {
        //para nao precisar modificar a entrada!
        T[] copia = (T[])array.Clone();
        int n = copia.Length;

        for (int i = 0; i < n - 1; i++) //percorrendo todo array
        {
            int indiceMaior = i;
            for (int j = i + 1; j < n; j++) //percorrendo o resto para deixar o maior ate o momento
            {
                if (seletor(copia[j]).CompareTo(seletor(copia[indiceMaior])) > 0)
                {
                    indiceMaior = j;
                }


            }
            if (indiceMaior != i)
            {
                (copia[i], copia[indiceMaior]) = (copia[indiceMaior], copia[i]);
            }
        }
        ArrayOrdenado = copia;

    }

}