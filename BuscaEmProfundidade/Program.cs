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
            // Criação dos nós
            Nodo a = new Nodo("A");
            Nodo b = new Nodo("B");
            Nodo c = new Nodo("C");
            Nodo d = new Nodo("D");
            Nodo e = new Nodo("E");
            Nodo f = new Nodo("F");

            // Estabelecendo as conexões (arestas)
            a.Vizinhos.Add(b);
            a.Vizinhos.Add(c);
            b.Vizinhos.Add(d);
            b.Vizinhos.Add(e);
            c.Vizinhos.Add(f);
            e.Vizinhos.Add(f);

            Nodo inicio = a;
            Console.WriteLine($"Busca em Profundidade a partir do nó {inicio.Id}: ");
            DFS(inicio, new HashSet<Nodo>());
            Console.ReadKey();
        }

        static void DFS(Nodo nodo, HashSet<Nodo> visitados)
        {
            if (visitados.Contains(nodo)) return;

            visitados.Add(nodo);
            Console.WriteLine(nodo.Id);

            foreach (var vizinho in nodo.Vizinhos)
            {
                DFS(vizinho, visitados);
            }
        }
    }
}
