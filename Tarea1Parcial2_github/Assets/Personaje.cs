using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    public Camera cam;

    //bala
//    public GameObject original;

        //salida bala
    public Transform referencia;
    public Transform cielo;
    public GameObject salidaCanon;

    public GameObject Bala;
    public GameObject BalaEnemigo;

    public Camera mainCamera;



    //apunta con mouse
    public Vector3 target;



    // Start is called before the first frame update
    void Start()
    {
    //    Cursor.visible = false;

        StartCoroutine("disparoCielo");


        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        //mover 
      /*
        float h = Input.GetAxis("Horizontal");
        transform.Translate(h * 5 * Time.deltaTime, 0, 0,Space.World);
        float v = Input.GetAxis("Vertical");
        transform.Translate(0,0, v * 5 * Time.deltaTime, Space.World);
        */



        //ROTAR viejo 
        // float v = Input.GetAxis("Vertical");
        //transform.Rotate(0,0,30 * v * Time.deltaTime, Space.World);


        //rotar chido
       
        /*
        
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength)) {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
        */

        //


        //mostrar algo en donde esta aopuntando
        //target =  cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

        //rotar
        /*Vector3 difference = target - salidaCanon.transform.position;
        float rotationZ = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);*/

        if (Input.GetMouseButtonDown(0)) {
            StartCoroutine("disparo");

        }

        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine("disparo");

        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("disparo");

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine("disparo");

        }

    }

    void OnCollisionStay(Collision colision)
    {
        if (colision.gameObject.tag == "Enemigo")
        {
            Destroy(colision.gameObject);
            Destroy(gameObject);
        }
    }


    IEnumerator disparo()
    {
        while (true)
        {
            //Instantiate(original);
            Instantiate(Bala,
                referencia.position,
                referencia.rotation
                );
            yield return new WaitForSeconds(.1f);

        }
    }


    IEnumerator disparoCielo()
    {
        while (true)
        {
            Vector3 position = new Vector3(Mathf.Clamp(Random.Range(-10.0f, 10.0f), -7, 7), +1, -5);
            Instantiate(BalaEnemigo, position, cielo.rotation);
            yield return new WaitForSeconds(2.0f);

        }
    }

}
