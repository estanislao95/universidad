using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    public Rigidbody machinegun;
    public Rigidbody pistol;


    public Transform shotpivot;
    public Transform player;

    public int speed;
    public int type = 0;
    
    float fireratetimer = 0;

    public int pistolammo = 0;
    public int pistolammoMax = 0;

    public int machinegunammo = 0;
    public int machinegunammoMax = 0;

    public Text ammo;
    public Text gunindicator;

    void Start()
    {

        machinegunammo = machinegunammoMax;
        pistolammo = pistolammoMax;
        type = 1;
        ammo.text = ("Pistol");
        gunindicator.text = ("Ammo " + pistolammo);



    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            type = 1;
            ammo.text = ("Pistol");
            gunindicator.text = ("Ammo " + pistolammo);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            type = 2;
            ammo.text = ("Machine Gun");
            gunindicator.text = ("Ammo " + machinegunammo);

        }
       // if (Input.GetKeyDown(KeyCode.Alpha3))
       // {
       //     type = 3;
       //
       // }




        if (Input.GetKey(KeyCode.Mouse0) && type == 1 && pistolammo >= 0)
        {
            fireratetimer += Time.deltaTime;
            gunindicator.text = ("Ammo " + pistolammo);

            if (fireratetimer >= 0.3f)
            {

                Rigidbody bulletClone = (Rigidbody)Instantiate(pistol, transform.position, transform.rotation);



                bulletClone.transform.position = shotpivot.position;
                bulletClone.velocity = transform.right * speed;

                fireratetimer = 0;
                pistolammo--;
            }




        }

        if (Input.GetKey(KeyCode.Mouse0) && type == 2 && machinegunammo >= 0)
        {
            fireratetimer += Time.deltaTime;
            gunindicator.text = ("Ammo " + machinegunammo);

            if (fireratetimer >= 0.1f)
            {

                Rigidbody bulletClone1 = (Rigidbody)Instantiate(machinegun, transform.position, transform.rotation);



                bulletClone1.transform.position = shotpivot.position;
                bulletClone1.velocity = transform.right * speed;

                fireratetimer = 0;
                machinegunammo--;
            }
 



        }


        // if (Input.GetKeyDown(KeyCode.Mouse0) && type == 3)
        // {
        //     Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
        //
        //
        //
        //     bulletClone.transform.position = shotpivot.position;
        //     bulletClone.velocity = transform.right * speed;
        //
        //
        //
        // }

        machinegunammo = machinegunammo > machinegunammoMax ? machinegunammoMax : machinegunammo;
        pistolammo = pistolammo > pistolammoMax ? pistolammoMax : pistolammo;

    }
}
