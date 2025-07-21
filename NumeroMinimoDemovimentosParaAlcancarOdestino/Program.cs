int[,] grid = new int[,] {
    { 0, 1, 0, 0, 0 },
    { 0, 1, 0, 1, 0 },
    { 0, 0, 0, 1, 0 },
    { 1, 1, 0, 0, 0 }
};

int rows = grid.GetLength(0);
int cols = grid.GetLength(1);

//implementar o grafo
Dictionary<string,List<string>> grafo = new Dictionary<string, List<string>>();

for (int i = 0; i < rows; i++) 
{
    for (int j = 0; j < cols; j++) 
    {
        List<string> list = new List<string>();
        //adicionar ja so os caminhos possiveis no grafo
        // verificar cima
        if (i > 0) 
        {
            if(grid[i - 1, j] != 1)
                list.Add($"{i - 1},{j}");
        }
        //verificar baixo
        if (i < rows - 1)
        {
            if(grid[i + 1, j] != 1)
                list.Add($"{i + 1},{j}");
        }
        //direita
        if (j < cols - 1)
        {
            if(grid[i, j + 1] != 1)
                list.Add($"{i},{j+1}");
        }
        //esquerda
        if (j > 0)
        {
            if(grid[i, j - 1] != 1)
                list.Add($"{i},{j - 1}");
        }

        grafo[$"{i},{j}"] = list;//atribuindo a lista de vizinhos possiveis


    }
}
Console.WriteLine("Grafo ja finalizado com as possibilidades do tabuleiro 2D");
string inicio = "0,0";
string final = $"{rows - 1},{cols - 1}";

Queue<string> fila = new Queue<string>(grafo[inicio]); //para ir adicionando os graus de vizinho!
HashSet<string> verificados = new HashSet<string>(); //controle de quem ja foi verificado
Dictionary<string, string> predecessores = new Dictionary<string, string>();//gravar o historico dos pais!

foreach (var valor in grafo[inicio])
{
    predecessores[valor] = inicio;
}

while (fila.Count > 0)
{
    var vizinho = fila.Dequeue();

    if(verificados.Contains(vizinho))
        continue;

    verificados.Add(vizinho);
    if (vizinho.Equals(final))
    {
        Console.WriteLine("Finalizando algoritmo!!");
        //imprimir historico!
        ImprimirCaminho(inicio, final);
    }
    else 
    {
        foreach (var item in grafo[vizinho]) 
        {
            //verificar aqui tbem se nao estou colocando nenhum vertice repitido, novamente!

            if (!verificados.Contains(item) && !predecessores.ContainsKey(item))
            {
                fila.Enqueue(item);
                predecessores[item] = vizinho;//registrando os pais
            }
        }
    }

}
//finalizando o loop, zerou a fila, eh um problema sem solucao!! 

void ImprimirCaminho(string inicio, string fim) 
{
    var caminho = new List<string>();
    var atual = fim;
    while (atual != inicio) 
    {
        caminho.Add(atual);
        atual = predecessores[atual];
    }
    caminho.Add(inicio);
    caminho.Reverse();
    Console.WriteLine(string.Join(" -> ", caminho));

}