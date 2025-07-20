//fatorial example
int valor = 5;

int resultado = Fatorial.Result(valor);
Console.WriteLine(resultado);



Console.WriteLine(Fatorial.Result(3));

Console.WriteLine(Fatorial.Result(10));

public static class Fatorial 
{
    public static int Result(int valor) 
    {
        if(valor == 1)
            return 1;
        return valor * Result(valor - 1);
    }

}