//algoritmo de dijkstra

//adicionando os vertices juntamente com os pesos

//--- construcao do GRAFO ---//

using System.Linq;

Dictionary<string,Dictionary<string,int>> grafo = new Dictionary<string, Dictionary<string, int>>();

grafo["inicio"] = new Dictionary<string,int>();//map interno da estrutura!
grafo["inicio"]["a"] = 6;
grafo["inicio"]["b"] = 2;

grafo["a"] = new Dictionary<string, int>();
grafo["a"]["fim"] = 1;

grafo["b"] = new Dictionary<string, int>();
grafo["b"]["a"] = 3;
grafo["b"]["fim"] = 5;

grafo["fim"] = new Dictionary<string, int>();

//--- construcao do GRAFO ---//

//--- construcao do hash de Custos de cada vertice ---//
Dictionary<string, int> custos = new Dictionary<string, int>();
custos["a"] = 6;
custos["b"] = 2;
custos["fim"] = int.MaxValue; //nao existe representacao int.Infinity (isso só existe para float ou double)
//--- construcao do hash de Custos de cada vertice ---//

//--- construcao do hash para Pais ---//
Dictionary<string, string> pais = new Dictionary<string, string>();
pais["a"] = "inicio";
pais["b"] = "inicio";
pais["fim"] = string.Empty;
//--- construcao do hash para Pais ---//

HashSet<string> processados = new HashSet<string>();

//funcao que preenche inicialmente um vertice
string vertice = EncontraNoCustoMenorValor(custos);
while (!string.Empty.Equals(vertice)) 
{
    var custo = custos[vertice];
    var vizinhos = grafo[vertice];

    foreach (var n in vizinhos.Keys)
    {
        int novo_custo = custo + vizinhos[n];
        if (custos[n] > novo_custo) 
        {
            custos[n] = novo_custo;
            pais[n] = vertice;
        }
        
    }
    processados.Add(vertice);
    vertice = EncontraNoCustoMenorValor(custos);
}

List<string> caminho = new List<string>();
string atual = "fim";

while (!string.IsNullOrEmpty(atual))
{
    caminho.Insert(0, atual); // insere no início da lista
    pais.TryGetValue(atual, out atual); // tenta voltar para o pai
}

// Impressão do caminho e do custo final
Console.WriteLine("Caminho com menor custo:");
Console.WriteLine(string.Join(" -> ", caminho));
Console.WriteLine($"Custo total: {custos["fim"]}");


string EncontraNoCustoMenorValor(Dictionary<string, int> custos)
{
    var custoMaisBaixo = int.MaxValue;
    var verticeComCustoMenor = string.Empty;

    foreach (var custo in custos)
    {
        if (custoMaisBaixo > custo.Value && !processados.Contains(custo.Key)) 
        {
            custoMaisBaixo = custo.Value;
            verticeComCustoMenor = custo.Key;
        }
    }
    return verticeComCustoMenor;
}