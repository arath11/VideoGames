using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pf_test : MonoBehaviour
{

    public Nodo inicio, fin;


    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        //bREADTWISE -busquedda alo ancho 
        if (Input.GetKeyUp(KeyCode.B))
        {
            List<Nodo> ruta = PathFinding.Ancho(inicio, fin);

            foreach (Nodo actual in ruta)
            {
                print(actual.transform.name);

            }
            //la magia del singleton 
            PersonajeWaypoints.Instancia.ReiniciarRuta(ruta.ToArray());
        }

        // DEPTHWISE - BUSQUEDA A LO PROFUNDO
        if (Input.GetKeyUp(KeyCode.D))
        {

            List<Nodo> ruta = PathFinding.Profundo(inicio, fin);

            foreach (Nodo actual in ruta)
            {
                print(actual.transform.name);
            }

            // la magia del singleton
            PersonajeWaypoints.Instancia.ReiniciarRuta(ruta.ToArray());
        }

        // A* - A estrella (A asterisco, A star)
        if (Input.GetKeyUp(KeyCode.A))
        {

            List<Nodo> ruta = PathFinding.AEstrella(inicio, fin);

            foreach (Nodo actual in ruta)
            {
                print(actual.transform.name);
            }

            // la magia del singleton
            PersonajeWaypoints.Instancia.ReiniciarRuta(ruta.ToArray());
        }


    }
}
