using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Rigidbody bullet;

    public Transform shotpivot;
    public Transform player;

    public int speed;
    public int type = 0;

    float fireratetimer = 0;
    void Start()
    {
        type = 1;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            type = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            type = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            type = 3;
        }




        if (Input.GetKeyDown(KeyCode.Mouse0) && type == 1)
        {
            Rigidbody bulletClone = (Rigidbody) Instantiate(bullet, transform.position, transform. rotation);



            bulletClone.transform.position = shotpivot.position;
            bulletClone.velocity = transform.right * speed;



        }

        if (Input.GetKey(KeyCode.Mouse0) && type == 2)
        {
            fireratetimer += Time.deltaTime;
            Debug.Log(fireratetimer);


            if (fireratetimer >= 0.1f)
            {

                Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);



                bulletClone.transform.position = shotpivot.position;
                bulletClone.velocity = transform.right * speed;

                fireratetimer = 0;
            }




        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && type == 3)
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);



            bulletClone.transform.position = shotpivot.position;
            bulletClone.velocity = transform.right * speed;



        }



    }
}
