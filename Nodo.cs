using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_ordenamiento
{
    internal class Nodo
    {
        public int Valor { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(Nodo siguiente = null)
        {
            Siguiente = siguiente;
        }
        public Nodo(int valor, Nodo siguente = null)
        {
            Valor = valor;
            Siguiente = siguente;
        }

    }
}
