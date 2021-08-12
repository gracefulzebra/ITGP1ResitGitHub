using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenShip : MonoBehaviour
{
    public int health = 1;
    public GameObject lifeScript;
    
    //movement switching bools
    public bool rightWallTouch = false;
    public bool leftWallTouch = true;

    public float speedx;


    void Start()
    {

    }

    void Update()
    {
        //movement code
        Vector3 position = transform.localPosition;

        //after contact a wall the bool is flipped and 
        //the ship moves in the opposite direction
        if (rightWallTouch)
        {
            position.x -= speedx;
            transform.localPosition = position;
        }

        if (leftWallTouch)
        {
            position.x += speedx;
            transform.localPosition = position;
        }

        //Checks health per frame in order to 
        //run kill function
        if (health <= 0)
        {
            Kill();
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        //switch statement for collision 

        switch (col.gameObject.tag)
        {
            case "LeftWall":
                //touching left wall flips bool variables
                leftWallTouch = true;
                rightWallTouch = false;

                break;

            case "RightWall":
                //touching right wall flips bool variables
                rightWallTouch = true;
                leftWallTouch = false;

                break; 

        }
    }


    public void TakeDamage()
    {
        //reduces health by 1
        health--;
    }

    public void Kill()
    {
        //accesses the game objects Life script
        //runs EnemyKilled function
        lifeScript = GameObject.Find("Text");
        lifeScript.GetComponent<Life>().EnemyKilled();
        //destrys GoldenShip game object
        Destroy(this.gameObject);
    }





}

