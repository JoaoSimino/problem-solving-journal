namespace Base_Folder1;

class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }


    //utilizar generic na implementacao
    //m => m.Coluna  func<T,C>
    public static List<T> OrdenaPorColuna<T, C>(List<T> lista, Func<T, C> selector)
        where C : IComparable<C>
    {


        //caso de quebra de loop, caso base onde nao precisa ser ordenado e nao chama mais recursivamente!
        if (lista.Count <= 1) 
        {
            return lista;
        }


        List<T> maiores = new List<T>();
        List<T> menores = new List<T>();
        T pivo = lista[0];
        
        for (int i = 1; i < lista.Count; i++)
        {
            var valorItem = selector(lista[i]);
            var valorPivo = selector(pivo);

            if (valorItem.CompareTo(valorPivo) < 0)
                menores.Add(lista[i]);
            else
                maiores.Add(lista[i]);

        }

        var ordenados = OrdenaPorColuna(menores, selector);
        ordenados.Add(lista[0]);
        ordenados.AddRange(OrdenaPorColuna(maiores, selector));

        return ordenados;
    }
}

