using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(new Vector3(0, 3, 12), ForceMode.Impulse);
        rb.AddForce(transform.up *2, ForceMode.Impulse);
        Destroy(gameObject, 8);

    }



    void OnCollisionStay(Collision colision)
    {
        if (colision.gameObject.tag == "Piso")
        {
            Destroy(colision.gameObject);

        } else if (colision.gameObject.tag == "Enemigo") {
            Destroy(colision.gameObject);
            Destroy(gameObject);
        }
    }


    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }



}
