using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float speedY = 1;


    void Start()
    {

    }


    void Update()
    {
        //moves bomb on the y axis by speed value every frame
        Vector3 position = transform.localPosition;

        position.y -= speedY;

        transform.localPosition = position;

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        //switch statement for collision
        switch (col.gameObject.tag)
        {
            
            case "Floor":
            case "UltFire":
                //destroys bomb game object
                Destroy(this.gameObject);

                break;

            case "Ship":
                //access the game objects Life script and run LifeIncrement function
                GameObject text = GameObject.Find("Text");
                text.gameObject.GetComponent<Life>().LifeIncrement();
                //destroy game object
                Destroy(this.gameObject);

                break;



        }
    }



}
