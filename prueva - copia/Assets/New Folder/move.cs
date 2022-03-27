using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public float walkpseed = 4f;
    public float roatationspeed = 180;
    public Rigidbody rigid;
    public float jumpspeed = 10;

    public float maxlife = 0;
    public float currentlife = 0;

    public float maxarmor = 0;
    public float currentarmor = 0;

    [HideInInspector]
    public bool isjump = true;
    [HideInInspector]
    public bool onair = true;

    [HideInInspector]
    public int speedboost = 0;
    [HideInInspector]
    float speedtimer = 0;


    public float run = 0;

    public int jumpamount = 0;


    public Image lifebar;
    public Image armor;


    // Start is called before the first frame update
    void Start()
    {
        currentlife = maxlife;
        currentarmor = maxarmor;

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        jumplogic();

        currentlife = currentlife > maxlife ? maxlife : currentlife;
        currentarmor = currentarmor > maxarmor ? maxarmor : currentarmor;


        lifebar.fillAmount = (currentlife / maxlife);
        armor.fillAmount = (currentarmor / maxarmor);






    }

    void movement()
    {


        Vector3 inputVector;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        inputVector.z = 0f;

 

        if (speedboost == 1)
        {
            speedtimer += Time.deltaTime;


            inputVector.y += run;

            if (speedtimer >= 4)
                speedboost = 0;
        }

        //transform.position += inputVector * walkpseed * Time.deltaTime;
        // transform.position += (transform.right * inputVector.y //+
        //                        //transform.forward * inputVector.x
        //                        ) 
        //                        * walkpseed * Time.deltaTime;

        rigid.MovePosition(rigid.position + (transform.right
                           * inputVector.y + transform.forward * inputVector.z)
                           * walkpseed * Time.deltaTime);


        rigid.MoveRotation(rigid.rotation * Quaternion.Euler(0,inputVector.x * 
                                            roatationspeed * Time.deltaTime,0));    
    }

    void jumplogic()
    {





        if (Input.GetButtonDown("Jump") && isjump == true && jumpamount != 2)
        {
            if (onair == true)
            {
                rigid.AddForce(Vector3.up * jumpspeed * 1.05f, ForceMode.Impulse);
            }
            else
            {
                rigid.AddForce(Vector3.up * jumpspeed, ForceMode.Impulse);
            }



            jumpamount++;
            onair = true;

            Debug.Log(jumpamount);

            if (jumpamount == 2)
            {
                isjump = false;
            }

        }

      //  if (Input.GetButtonDown("Jump") && isjump == false && doublejump == true)
      //  {
      //      Debug.Log("input");
      //      rigid.AddForce(Vector3.up * jumpspeed * 2, ForceMode.Impulse);
      //      doublejump = false;
      //  }
    }


    private void OnCollisionEnter(Collision collision)
    {



        if (collision.gameObject.layer == 6)
        {
            isjump = true;
            jumpamount = 0;
            onair = false;
        }


        
    }




}
