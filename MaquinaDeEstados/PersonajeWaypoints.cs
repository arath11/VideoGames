using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeWaypoints : MonoBehaviour
{
    //semi-singleton 
    public static PersonajeWaypoints Instancia {
        private set;
        get; 
    }

    //propierties 
    //sutituto / mejora gettters y setters
    public int NodoActual {
        set {
            nodoActual = value;
        }
        get {
            return nodoActual;
        }
    }




    //private int nodoActual;

    public Nodo[] vecinos;
    public float velocidad=3;
    
    public float rangoValido = .01f;

    
    private Nodo[] ruta;
    private int nodoActual;


    // Start is called before the first frame update
    void Start()
    {
        Instancia = this;
        nodoActual = 0;
        StartCoroutine(VerificarObjetivo());
        ruta = vecinos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(vecinos[nodoActual].transform);
        transform.Translate(transform.forward * velocidad * Time.deltaTime, Space.World);

    }

    //checamos la distancia entre el objeto y el objetivo 
    IEnumerator VerificarObjetivo() {
        while (true) {

            //checar disancia 
            float distancia = Vector3.Distance(transform.position,vecinos[nodoActual].transform.position);
            
            
            //llegamos y cambiamos de objetivo 
            if (distancia < rangoValido) {
                nodoActual++;
                //ajuste con modulo 
                nodoActual %= vecinos.Length;    
            }
            yield return new WaitForSeconds(.3f);
        }    
    
    }



    public void ReiniciarRuta(Nodo[] ruta)
    {
        this.vecinos = ruta;
        nodoActual = 0;
    }

}
