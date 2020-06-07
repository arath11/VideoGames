using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding
{
    //busqueda a lo ancho breadthwise

    public static List<Nodo> Ancho(Nodo inicio, Nodo fin) {
        // 2 estructuras utilizadas por el algoritmo
        List<Nodo> visitados = new List<Nodo>();
        Queue<Nodo> trabajo = new Queue<Nodo>();

        // reiniciar historial de nodo raiz
        inicio.historial = new List<Nodo>();
        trabajo.Enqueue(inicio);
        visitados.Add(inicio);

        while (trabajo.Count > 0)
        {
            Nodo actual = trabajo.Dequeue();
            if (actual == fin)
            {
                // generar lista resultado y regresarla
                List<Nodo> resultado = new List<Nodo>(actual.historial);
                resultado.Add(actual);
                return resultado;
            }
            else
            {
                // si no es el objetivo - agregar vecinos
                for (int i = 0; i < actual.vecinos.Length; i++)
                {
                    Nodo vecinoActual = actual.vecinos[i];
                    if (!visitados.Contains(vecinoActual))
                    {
                        // reiniciar ruta
                        vecinoActual.historial = new List<Nodo>(actual.historial);
                        vecinoActual.historial.Add(actual);
                        // agregar a estructuras
                        trabajo.Enqueue(vecinoActual);
                        visitados.Add(vecinoActual);
                    }
                }
            }
        }

        // no existe una ruta posible
        return null;
    }


    // busqueda a lo profundo
    // depthwise
    public static List<Nodo> Profundo(Nodo inicio, Nodo fin)
    {
        // 2 estructuras utilizadas por el algoritmo
        List<Nodo> visitados = new List<Nodo>();
        Stack<Nodo> trabajo = new Stack<Nodo>();
        // reiniciar historial de nodo raiz
        inicio.historial = new List<Nodo>();
        trabajo.Push(inicio);
        visitados.Add(inicio);

        while (trabajo.Count > 0)
        {

            Nodo actual = trabajo.Pop();

            if (actual == fin)
            {

                // generar lista resultado y regresarla
                List<Nodo> resultado = new List<Nodo>(actual.historial);
                resultado.Add(actual);
                return resultado;
            }
            else
            {

                // si no es el objetivo - agregar vecinos
                for (int i = 0; i < actual.vecinos.Length; i++)
                {

                    Nodo vecinoActual = actual.vecinos[i];

                    if (!visitados.Contains(vecinoActual))
                    {

                        // reiniciar ruta
                        vecinoActual.historial = new List<Nodo>(actual.historial);
                        vecinoActual.historial.Add(actual);

                        // agregar a estructuras
                        trabajo.Push(vecinoActual);
                        visitados.Add(vecinoActual);
                    }
                }
            }
        }

        // no existe una ruta posible
        return null;
    }
    // a estrella, a asterisco
    // a star
    public static List<Nodo> AEstrella(Nodo inicio, Nodo fin)
    {

        List<Nodo> trabajo = new List<Nodo>();
        List<Nodo> visitados = new List<Nodo>();

        inicio.historial = new List<Nodo>();
        inicio.g = 0;
        inicio.h = Vector3.Distance(inicio.transform.position, fin.transform.position);

        trabajo.Add(inicio);
        visitados.Add(inicio);

        // caso único
        if (inicio == fin)
        {
            List<Nodo> resultado = new List<Nodo>();
            resultado.Add(inicio);
            return resultado;
        }

        while (trabajo.Count > 0)
        {

            // NUEVO CAMBIO - ELEGIR EL QUE SIGUE
            // - el que tenga menor F
            Nodo actual = trabajo[0];

            for (int i = 1; i < trabajo.Count; i++)
            {
                if (trabajo[i].F < actual.F)
                    actual = trabajo[i];
            }

            trabajo.Remove(actual);

            for (int i = 0; i < actual.vecinos.Length; i++)
            {

                Nodo vecinoActual = actual.vecinos[i];

                if (!visitados.Contains(vecinoActual))
                {

                    // agregar historial
                    vecinoActual.historial = new List<Nodo>(actual.historial);
                    vecinoActual.historial.Add(actual);

                    if (vecinoActual == fin)
                    {
                        List<Nodo> resultado = new List<Nodo>(vecinoActual.historial);
                        resultado.Add(vecinoActual);
                        return resultado;
                    }

                    // procesar valores de A*
                    vecinoActual.g = actual.g +
                        Vector3.Distance(vecinoActual.transform.position, actual.transform.position);

                    vecinoActual.h = Vector3.Distance(
                                            vecinoActual.transform.position,
                                            fin.transform.position
                                        );

                    trabajo.Add(vecinoActual);
                    visitados.Add(vecinoActual);
                }
            }
        }

        return null;
    }



}
