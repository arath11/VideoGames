using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo : MonoBehaviour
{
    
    //para dibujar las lineas
    public Nodo[] vecinos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    private void OnDrawGizmos()
    {
        //pintar la linea entre ellos color amarillo 
        Gizmos.color = new Color(255, 128, 0);

        //dinjuar la linea 
        for (int i = 0; i < vecinos.Length; i++)
        {
            if (vecinos[i] != null)
                Gizmos.DrawLine(transform.position, vecinos[i].transform.position);
        }

        //dibuja el circulo en ellos azul 
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 1);
    }


    //cuando lo seleccionamos se pone en rojo 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 1);
    }

}
