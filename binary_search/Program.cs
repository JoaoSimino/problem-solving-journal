
int[] minha_lista = new int[] {
    451, 983, 714, 847, 562, 340, 98, 278, 872, 603,
    114, 775, 369, 21, 958, 480, 734, 911, 107, 826,
    508, 290, 675, 607, 942, 156, 426, 874, 63, 190,
    726, 812, 345, 232, 515, 775, 214, 112, 871, 491,
    605, 687, 422, 325, 74, 968, 630, 265, 382, 882,
    145, 493, 29, 958, 608, 203, 735, 548, 343, 973,
    300, 456, 260, 480, 878, 528, 344, 414, 313, 687,
    391, 804, 731, 67, 816, 901, 599, 376, 456, 828,
    437, 641, 532, 733, 717, 207, 64, 356, 593, 82,
    118, 251, 570, 668, 723, 707, 397, 846, 185, 390,
    970, 543, 280, 190, 841, 690, 331, 637, 487, 653,
    156, 981, 119, 421, 791, 645, 469, 922, 141, 50,
    709, 783, 22, 481, 402, 75, 265, 644, 799, 739,
    310, 411, 734, 313, 217, 629, 930, 742, 605, 389,
    822, 230, 843, 497, 96, 521, 342, 720, 377, 859,
    192, 168, 274, 122, 453, 875, 495, 584, 170, 745,
    154, 223, 671, 190, 440, 727, 402, 935, 82, 800,
    392, 505, 128, 684, 113, 613, 961, 347, 387, 289,
    670, 707, 392, 505, 879, 214, 154, 608, 365, 99,
    313, 474, 272, 385, 314, 579, 160, 721, 613, 851
};


Binary_Search<int> minhaArvoreBinaria = new Binary_Search<int>(minha_lista);

Console.WriteLine(minhaArvoreBinaria.ReturnPositionOfValue(613));

Console.WriteLine(minhaArvoreBinaria.ReturnPositionOfValue(999));

public class Binary_Search<T> where T : IComparable<T>
{
    private readonly T[] _lista;
    
    public Binary_Search(T[] lista)
    {
        //ordenar a lista e atribuir internamente!
        _lista = (T[])lista.Clone();
        Array.Sort( _lista );
    }
    public int ReturnPositionOfValue(T value)  
    {
        int baixo = 0;
        int alto = _lista.Length - 1;
        int meio;
        T chute;

        while (baixo <= alto) 
        {
            meio = (baixo + alto) / 2;
            chute = _lista[meio];
            if (chute.CompareTo(value) == 0)
            {
                return meio;
            }
            else if (chute.CompareTo(value) < 0)//chute eh menor que o valor, descarto parte de baixo!
            {
                baixo = meio + 1;
            }
            else if (chute.CompareTo(value) > 0)// chute eh maior que o valor, descarto parte de cima
            {
                alto = meio - 1;
            }
        }
        return -1;//para numero nao encontrado!
    }
}
