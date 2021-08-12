using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltFire : MonoBehaviour
{

    public float speedY = 1;


    void Start()
    {

    }


    void Update()
    {
        //moves Ult fire on the y axis by speed value every frame
        Vector3 position = transform.localPosition;

        position.y += speedY;

        transform.localPosition = position;

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        //switch statement for collision
        switch (col.gameObject.tag)
        {
            case "UltBarrier":
                //destroys ult game object
                Destroy(this.gameObject);

                break;

            case "AlienR1":
            case "AlienR2":
            case "AlienR3":
            case "AlienR4":

                //accesses collided objects Alien script and runs TakeDamage function
                col.gameObject.GetComponent<Alien>().TakeDamage();

                

                break;

            case "Golden":
                //accesses collided objects GoldenShip script and runs TakeDamage function
                col.gameObject.GetComponent<GoldenShip>().TakeDamage();

                

                break;


        }
    }



}
