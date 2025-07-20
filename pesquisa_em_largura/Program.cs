//implementando inicialmente um grafo direcionado com Dictionary
Dictionary<string, List<string>> grafo = new();

grafo.Add("voce", new List<string> { "alice","bob","claire" });
grafo.Add("bob", new List<string> { "anuj", "peggy" });
grafo.Add("alice", new List<string> { "peggy" });
grafo.Add("claire", new List<string> { "thom", "jonny" });
grafo.Add("anuj", new List<string>());
grafo.Add("peggy", new List<string>());
grafo.Add("thom", new List<string>());
grafo.Add("jonny", new List<string>());


BFS bfs = new BFS();
bfs.Execute(grafo, "voce", "anuj");



public class BFS 
{

    private Queue<string> fila { get;  set; }

    private HashSet<string> verificados { get; set; }//hashset para melhor performance que lista, busca BigO(1)
    private Dictionary<string, string> predecessores { get; set; }

    public bool Execute(Dictionary<string, List<string>> grafo, string inicio, string final)
    {
        //adicionar os elementos de primeiro grau do grafo na fila!
        //tenho duas maneiras, deixarei uma comentada para ficar registrada

        fila = new Queue<string>(grafo[inicio]);
        verificados = new HashSet<string>();
        predecessores = new Dictionary<string, string>();

        foreach (var valor in grafo[inicio]) 
        {
            predecessores[valor] = inicio;
        }

        

        //fila populada agora coloco meu while
        while (fila.Count > 0)
        {
            var vizinho = fila.Dequeue();

            //verificar se o mesmo ja foi pesquisado na lista de verificados!
            if(verificados.Contains(vizinho))
                continue;

            verificados.Add(vizinho);//se nao tiver irei fazer a logica de verificacao e ja adiciono aqui, para evitar loops ciclicos!

            if (vizinho.Equals(final))
            {
                Console.WriteLine($"{final} encontrado!");
                ImprimirCaminho(inicio, final);
                return true;
            }
            else
            {
                foreach (var valores in grafo[vizinho])
                {
                    fila.Enqueue(valores);
                    predecessores[valores] = vizinho; // registrando de onde veio!
                }
            }
        }
        return false;//se terminar a fila e nao encontrar ele nao existe no grafo!

    }

    private void ImprimirCaminho(string inicio, string final)
    {
        var caminho = new List<string>();
        var atual = final;//reconstrucao de tras para frente!

        while (atual != inicio)
        {
            caminho.Add(atual);
            atual = predecessores[atual];
        }
        caminho.Add(inicio);
        caminho.Reverse();//inverte a lista

        Console.WriteLine("Caminho encontrado:");
        Console.WriteLine(string.Join(" -> ", caminho));
    }

}
