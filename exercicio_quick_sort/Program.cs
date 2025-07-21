using Base_Folder1;
using System;

var produtos = new List<Produto>
{
    new Produto { Nome = "Notebook", Preco = 3500.00m },
    new Produto { Nome = "Mouse", Preco = 80.00m },
    new Produto { Nome = "Teclado", Preco = 120.00m },
    new Produto { Nome = "Monitor", Preco = 900.00m },
    new Produto { Nome = "HD Externo", Preco = 400.00m }
};

var ordenados = Produto.OrdenaPorColuna(produtos, p => p.Nome);
Console.WriteLine("Ordenador por Nome");
foreach (var produto in ordenados) 
{
    
    Console.WriteLine($"{produto.Nome}-{produto.Preco}");
    
}

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("-----------------------------------------");
Console.WriteLine();
Console.WriteLine();

var ordenados2 = Produto.OrdenaPorColuna(produtos, p => p.Preco);
Console.WriteLine("Ordenador por preco");
foreach (var produto in ordenados2) 
{
    Console.WriteLine($"{produto.Nome}-{produto.Preco}");
}
    