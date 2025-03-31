using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaEmProfundidade
{
    class Nodo
    {
        public string Id { get; set; }
        public List<Nodo> Vizinhos { get; set; }

        public Nodo(string id)
        {
            Id = id;
            Vizinhos = new List<Nodo>();
        }
    }
}
