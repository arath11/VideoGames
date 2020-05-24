using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
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
        rb.AddForce(transform.up * 1, ForceMode.Impulse);
        Destroy(gameObject, 4);

    }



    void OnCollisionStay(Collision colision)
    {
        Destroy(gameObject);


        if (colision.gameObject.tag == "Personaje")
        {
            Destroy(colision.gameObject);
            Destroy(gameObject);
        }
    }


    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
