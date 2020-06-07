using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    // Start is called before the first frame update
    //recuperar una referencia a un rigidbody
    private Rigidbody rb;

    void Start()
    {
        //codigo para obtener referencia
        //puede regresar null
        rb = GetComponent<Rigidbody>();
        //---Rigidbody[] rbs = GetComponents<Rigidbody>(); si tienes mas de un componente
        //rigidbody este te obtiene todos los que tengas.
        //3 vectores que son sus amiguitos
        //-Up
        //-Forward
        //-Right

        //rb.AddForce(new Vector3(0,3,12),ForceMode.Impulse);

        //Este vector de abajo y los otros dos son de ejes locales
        //No con referencia a los ejes del mundo
        //Vectores unitarios*
        rb.AddForce(transform.up * 30, ForceMode.Impulse);
        Destroy(gameObject, 1);
        //gameobject con minusculas todo es una referencia al objeto al que pertence
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter(Collision c)
    {
        Destroy(gameObject);
        Destroy(c.gameObject);
    }




    void OnBecameInvisible() {
        Destroy(gameObject);
    }

}