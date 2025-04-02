using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaEmProfundidade
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Nodo> grafo = new Dictionary<string, Nodo>();
            string[] cidades = { "Oradea", "Zerind", "Arad", "Timisoara", "Lugoj", "Mehadia", "Drobeta", "Craiova", "Rimnicu Vilcea", "Sibiu", "Fagaras", "Pitesti", "Bucareste", "Giurgiu", "Urziceni", "Hirsova", "Eforie", "Vaslui", "Iasi", "Neamt" };

            foreach (var cidade in cidades)
            {
                grafo[cidade] = new Nodo(cidade);
            }

            grafo["Oradea"].Vizinhos.AddRange(new[] { grafo["Zerind"], grafo["Sibiu"] });
            grafo["Zerind"].Vizinhos.AddRange(new[] { grafo["Oradea"], grafo["Arad"] });
            grafo["Arad"].Vizinhos.AddRange(new[] { grafo["Zerind"], grafo["Sibiu"], grafo["Timisoara"] });
            grafo["Timisoara"].Vizinhos.AddRange(new[] { grafo["Arad"], grafo["Lugoj"] });
            grafo["Lugoj"].Vizinhos.AddRange(new[] { grafo["Timisoara"], grafo["Mehadia"] });
            grafo["Mehadia"].Vizinhos.AddRange(new[] { grafo["Lugoj"], grafo["Drobeta"] });
            grafo["Drobeta"].Vizinhos.AddRange(new[] { grafo["Mehadia"], grafo["Craiova"] });
            grafo["Craiova"].Vizinhos.AddRange(new[] { grafo["Drobeta"], grafo["Rimnicu Vilcea"], grafo["Pitesti"] });
            grafo["Rimnicu Vilcea"].Vizinhos.AddRange(new[] { grafo["Craiova"], grafo["Sibiu"], grafo["Pitesti"] });
            grafo["Sibiu"].Vizinhos.AddRange(new[] { grafo["Oradea"], grafo["Arad"], grafo["Rimnicu Vilcea"], grafo["Fagaras"] });
            grafo["Fagaras"].Vizinhos.AddRange(new[] { grafo["Sibiu"], grafo["Bucareste"] });
            grafo["Pitesti"].Vizinhos.AddRange(new[] { grafo["Rimnicu Vilcea"], grafo["Craiova"], grafo["Bucareste"] });
            grafo["Bucareste"].Vizinhos.AddRange(new[] { grafo["Fagaras"], grafo["Pitesti"], grafo["Giurgiu"], grafo["Urziceni"] });
            grafo["Giurgiu"].Vizinhos.Add(grafo["Bucareste"]);
            grafo["Urziceni"].Vizinhos.AddRange(new[] { grafo["Bucareste"], grafo["Vaslui"], grafo["Hirsova"] });
            grafo["Hirsova"].Vizinhos.AddRange(new[] { grafo["Urziceni"], grafo["Eforie"] });
            grafo["Eforie"].Vizinhos.Add(grafo["Hirsova"]);
            grafo["Vaslui"].Vizinhos.AddRange(new[] { grafo["Urziceni"], grafo["Iasi"] });
            grafo["Iasi"].Vizinhos.AddRange(new[] { grafo["Vaslui"], grafo["Neamt"] });
            grafo["Neamt"].Vizinhos.Add(grafo["Iasi"]);

            Console.Write("Digite a cidade de partida: ");
            string partida = Console.ReadLine();
            Console.Write("Digite a cidade de destino: ");
            string destino = Console.ReadLine();

            if (!grafo.ContainsKey(partida) || !grafo.ContainsKey(destino))
            {
                Console.WriteLine("Cidade inválida!");
                return;
            }

            Console.WriteLine($"Busca em Profundidade de {partida} para {destino}: ");
            HashSet<Nodo> visitados = new HashSet<Nodo>();
            List<string> caminho = new List<string>();
            if (DFS(grafo[partida], grafo[destino], visitados, caminho))
            {
                caminho.Reverse();
                Console.WriteLine(string.Join(" -> ", caminho));
            }
            else
            {
                Console.WriteLine("Caminho não encontrado.");
            }
        }

        static bool DFS(Nodo atual, Nodo destino, HashSet<Nodo> visitados, List<string> caminho)
        {
            if (visitados.Contains(atual)) return false;
            visitados.Add(atual);

            if (atual == destino)
            {
                caminho.Add(atual.Id);
                return true;
            }

            foreach (var vizinho in atual.Vizinhos)
            {
                if (DFS(vizinho, destino, visitados, caminho))
                {
                    caminho.Add(atual.Id);
                    return true;
                }
            }
            return false;
        }
    }
}
