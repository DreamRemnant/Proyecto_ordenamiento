using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_ordenamiento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lista listaSimpleLigada = new Lista();

            //Llenaremos la lista con números al azar entre 1 y 20
            Random rnd = new Random();
            
            listaSimpleLigada.Agregar(rnd.Next(1, 20));
            listaSimpleLigada.Agregar(rnd.Next(1, 20));
            listaSimpleLigada.Agregar(rnd.Next(1, 20));
            listaSimpleLigada.Agregar(rnd.Next(1, 20));
            listaSimpleLigada.Agregar(rnd.Next(1, 20));

            //Primero imprimimos la lista con los valores al azar sin ordenar
            Console.WriteLine(listaSimpleLigada.Recorrer());
            Console.ReadKey();
            //Ordenamos los valores utilizando el comando Quicksort
            listaSimpleLigada.QuickSort();
            //Imprimimos la lista con los valores ordenados
            Console.WriteLine(listaSimpleLigada.Recorrer());
            Console.ReadKey();
        }
    }
}
