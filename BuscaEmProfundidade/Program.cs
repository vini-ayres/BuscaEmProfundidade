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

            grafo["Oradea"].Vizinhos.Add(grafo["Zerind"]);
            grafo["Oradea"].Vizinhos.Add(grafo["Sibiu"]);
            grafo["Zerind"].Vizinhos.Add(grafo["Arad"]);
            grafo["Arad"].Vizinhos.Add(grafo["Timisoara"]);
            grafo["Timisoara"].Vizinhos.Add(grafo["Lugoj"]);
            grafo["Lugoj"].Vizinhos.Add(grafo["Mehadia"]);
            grafo["Mehadia"].Vizinhos.Add(grafo["Drobeta"]);
            grafo["Drobeta"].Vizinhos.Add(grafo["Craiova"]);
            grafo["Craiova"].Vizinhos.Add(grafo["Pitesti"]);
            grafo["Craiova"].Vizinhos.Add(grafo["Rimnicu Vilcea"]);
            grafo["Rimnicu Vilcea"].Vizinhos.Add(grafo["Sibiu"]);
            grafo["Sibiu"].Vizinhos.Add(grafo["Fagaras"]);
            grafo["Fagaras"].Vizinhos.Add(grafo["Bucareste"]);
            grafo["Pitesti"].Vizinhos.Add(grafo["Bucareste"]);
            grafo["Bucareste"].Vizinhos.Add(grafo["Giurgiu"]);
            grafo["Bucareste"].Vizinhos.Add(grafo["Urziceni"]);
            grafo["Urziceni"].Vizinhos.Add(grafo["Hirsova"]);
            grafo["Hirsova"].Vizinhos.Add(grafo["Eforie"]);
            grafo["Urziceni"].Vizinhos.Add(grafo["Vaslui"]);
            grafo["Vaslui"].Vizinhos.Add(grafo["Iasi"]);
            grafo["Iasi"].Vizinhos.Add(grafo["Neamt"]);

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
