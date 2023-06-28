using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_ordenamiento
{
    internal class Lista
    {
        Nodo nodoInicial;
        Nodo nodoActual;
        public Lista()
        {
            nodoInicial= new Nodo();
        }
        public bool ValidaVacio()
        {
            if (nodoInicial.Siguiente == null)
            {
                return true;
            }
            return false;
            //return nodoInicial.Siguiente == null;

        }
        public void VaciarLista()
        {
            nodoInicial.Siguiente = null;
        }
        public string Recorrer()
        {
            string datos = string.Empty;
            nodoActual = nodoInicial;
            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
                datos += nodoActual.Valor + ",";
            }
            return datos;
        }
        public void Agregar(int valor)
        {
            nodoActual = nodoInicial;
            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
            }
            Nodo nodoNuevo = new Nodo(valor);
            nodoActual.Siguiente= nodoNuevo;
        }
        public void AgregarNodoInicio(int valor)
        {
            nodoActual = nodoInicial;
            Nodo nuevoNodo = new Nodo(valor, nodoActual.Siguiente);
            nodoActual.Siguiente = nuevoNodo;
        }
        public Nodo Buscar(int valor)
        {
            if (ValidaVacio())
            {
                return null;
            }
            nodoActual = nodoInicial;
            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
                if (nodoActual.Valor==valor)
                {
                    return nodoActual;
                }
            }
            return null;
        }
        public Nodo BuscarPorIndice(int indice)
        {
            int Indice = -1;

            if (ValidaVacio() == false)
            {
                Nodo nodoBusqueda = nodoInicial;

                while (nodoBusqueda.Siguiente != null)
                {
                    nodoBusqueda = nodoBusqueda.Siguiente;
                    Indice++;

                    if (Indice == indice)
                    {
                        return nodoBusqueda;
                    }
                }
            }

            return null;
        }

        private int ObtenerLongitud()
        {
            int Indice = -1;

            if (ValidaVacio() == false)
            {
                Nodo nodoRecorrido = nodoInicial;

                while (nodoRecorrido.Siguiente != null)
                {
                    nodoRecorrido = nodoRecorrido.Siguiente;
                    Indice++;
                }

                return Indice;
            }

            return Indice;
        }
        public Nodo BuscarAnterior(int valor)
        {
            if (ValidaVacio() == false)
            {
                Nodo nodoBusqueda = nodoInicial;

                while (nodoBusqueda.Siguiente != null
                            && nodoBusqueda.Siguiente.Valor != valor)
                {
                    nodoBusqueda = nodoBusqueda.Siguiente;
                    if (nodoBusqueda.Siguiente.Valor == valor)
                    {
                        return nodoBusqueda;
                    }
                }
            }
            return null;
        }

        public void BorrarNodo(int valor)
        {
            if (ValidaVacio() == false)
            {
                nodoActual = Buscar(valor);

                if (nodoActual != null)
                {
                    Nodo nodoAnterior = BuscarAnterior(valor);
                    nodoAnterior.Siguiente = nodoActual.Siguiente;
                    nodoActual.Siguiente = null;
                }
            }
        }

        //Se creó un indexer para buscar Nodos de la lista por medio de un índice tipo arreglo.
        public int this[int indiceNodo]
        {
            get
            {
                nodoActual = BuscarPorIndice(indiceNodo);

                return nodoActual.Valor;
            }

            set
            {
                nodoActual = BuscarPorIndice(indiceNodo);
                if (nodoActual != null)
                {
                    nodoActual.Valor = value;
                }
            }
        }

        //Intercambia los valores de los nodos en los indices indicados.
        public void intercambio(int indice1, int indice2)
        {
            int temporal = this[indice1];
            this[indice1] = this[indice2];
            this[indice2] = temporal;
        }

        public int division(int indiceInicio, int indiceFinal)
        {
            int valorPivote = 0;
            int indicePivote = 0; //Es el índice donde quedará el pivote al final
            int indiceComparacion = 0; //Es el índice del elemento que se compara con el pivote

            //Seleccionamos el último elemento de la lista como el pivote
            valorPivote = this[indiceFinal];

            //Ponemos el índice del pivote al inicio
            indicePivote = indiceInicio;

            //Recorremos la lista en la division
            for (indiceComparacion = indiceInicio; indiceComparacion < indiceFinal; indiceComparacion++)
            {
                //Revisamos si el valor a comparar es menor o igual al valor del pivote 
                if (this[indiceComparacion] <= valorPivote) {
                    //De ser así intercambiamos el valor del indice de comparación con el valor del indice de Pivote
                    intercambio(indiceComparacion, indicePivote);

                    //Nos movemos al índice siguiente
                    indicePivote++;
                }
            }
            //Finalmente intercambiamos nuestro pivote con el valor en la posición de indicePivote (donde queremos que quede nuestro pivote finalmente)
            intercambio(indicePivote, indiceFinal);

            //Devolvemos el índice donde se encuentra el pivote ahora
            return indicePivote;
        }

        //Este es el metodo Quicksort al que tiene acceso el programa principal para ordenar los valores integer de los nodos al ser llamado
        public void QuickSort()
        {
            int indicePivote = 0;

            //No se acomoda si es un solo elemento
            if (indicePivote >= ObtenerLongitud())
            {
                return;
            }

            //Se obtiene el primer índice de pivote de toda la lista
            indicePivote = division(indicePivote, ObtenerLongitud());

            //Realizaremos más acomodos para el fragmento izquierdo de la lista y el fragmento derecho
            QuickSort(0, indicePivote - 1); //Fragmento a la izquierda del pivote, números menores
            QuickSort(indicePivote + 1, ObtenerLongitud()); //Fragmento a la derecha del pivote, números mayores
        }

        private void QuickSort(int indiceInicio, int indiceFinal) //
        {
            int indicePivote = 0;

            //No se acomoda si es un solo elemento o si es un fragmento inválido
            if (indiceInicio >= indiceFinal)
            {
                return;
            }

            //Se obtiene el primer índice de pivote de toda la lista
            indicePivote = division(indiceInicio, indiceFinal);

            //Realizaremos más acomodos para el fragmento izquierdo de la lista y el fragmento derecho
            QuickSort(indiceInicio, indicePivote - 1); //Fragmento a la izquierda del pivote, números menores
            QuickSort(indicePivote + 1, indiceFinal); //Fragmento a la derecha del pivote, números mayores
        }
    }
}
