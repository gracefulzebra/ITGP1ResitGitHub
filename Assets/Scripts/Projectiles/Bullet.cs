using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speedY = 1; 


    void Start()
    {
        
    }

   
    void Update()
    {
        //moves bullet on the y axis by speed value every frame
        Vector3 position = transform.localPosition;

        position.y += speedY;

        transform.localPosition = position; 
            
    }

    
    public void OnTriggerEnter2D(Collider2D col)
    {
        //switch statement for collision
        switch (col.gameObject.tag)
        {
            case "TopWall":
            //destroys bullet game object
                Destroy(this.gameObject);

                break;
                //in case of colliding with any alien 
                //from any row
            case "AlienR1":
            case "AlienR2":
            case "AlienR3":
            case "AlienR4":
                //access the game objects Alien script and run TakeDamage function
                col.gameObject.GetComponent<Alien>().TakeDamage();
                //destroys bullet game object
                Destroy(this.gameObject);

                break;

            case "Golden":
                //access the game objects GoldenShip script and run TakeDamage function
                col.gameObject.GetComponent<GoldenShip>().TakeDamage();
                //destroys bullet game object
                Destroy(this.gameObject);

                break;


        }
    }



}
