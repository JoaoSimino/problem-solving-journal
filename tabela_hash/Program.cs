var obj1 = new MyObject("aaaaa",2);
var obj2 = new MyObject("abbbbb",42);


//a propria linguagem ja vem com uma implementacao de equals e hashcode default
//consigo ja colocar diretamente um objeto customizado no map!
Dictionary<string, MyObject> dict = new Dictionary<string, MyObject> { 
    {$"{obj1.Descricao}", obj1 },
    {$"{obj2.Descricao}", obj2 }

};
Console.WriteLine("criado!!");

public class MyObject 
{
    public MyObject(string descricao, int quantidade)
    {
        Descricao = descricao;
        Quantidade = quantidade;
    }

    public string Descricao { get; set; }
    public int Quantidade { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is MyObject outra) 
        {
            return Descricao == outra.Descricao && Quantidade == outra.Quantidade;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Descricao, Quantidade);
    }
}
//por default eh considerado a referencia, ou seja Equals pega o endereco de memoria!!