using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ship : MonoBehaviour
{
    public float speedx;
    //assigns keypresses to keycodes
    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public KeyCode moveRightKey = KeyCode.RightArrow;
    public KeyCode spaceBar = KeyCode.Space;
    bool canMoveLeft = true;
    bool canMoveRight = true;
    //firing variables
    public float bulletTimer = 1;
    public float bulletTimerMin = 0;
    public bool canFire = true;
    //variable used to alternate between firing spawns
    public bool alt;
    //projectiles
    public GameObject Bullet;
    public GameObject UltFireProjectile;
    //spawn locations
    public GameObject bulletSpawn1;
    public GameObject bulletSpawn2;
    
     void Update()
    { 
        //assigns keypress keycodes to bool variables 
        bool isLeftPressed = Input.GetKey(moveLeftKey);
        bool isRightPressed = Input.GetKey(moveRightKey);
        bool isSpacePressed = Input.GetKey(spaceBar);
       
        //assigns current position vector to position variable
        Vector3 position = transform.localPosition;


        //If statements governing movement based on direction being pressed and contact with walls 
            //left movement
        if (isLeftPressed && canMoveLeft)
        {
            position.x -= speedx;
            transform.localPosition = position;
        }
            //right movement
        if (isRightPressed && canMoveRight)
        {
            position.x += speedx;
            transform.localPosition = position;
        }

        // Runs timer function once per update cycle
        FiringTimer();
        
        //Firing condition - space bar 
        if (isSpacePressed && canFire)
        {
            Fire();
        }
        



    }

    // Controls the countdown timer between bullet instantiation 
    // Checks if countdown is complete and sets fire variable to true 
    public void FiringTimer()
    {
        bulletTimer -= Time.deltaTime;

        if (bulletTimer <= 0)
        {
            canFire = true;
        }
        
    }

    // Sets fire variable to false
    // Instantiates bullet 
    // Resets countdown timer
    public void Fire()
    {
        canFire = false;
        //alternates fire between 2 possible spawn points
        if (alt)
        {
            //instantiates bullet at spawn1
            Instantiate(Bullet, bulletSpawn1.transform.position, bulletSpawn1.transform.rotation);
            alt = false;
        }
        else
        {
            //instantiates bullet at spawn1
            Instantiate(Bullet, bulletSpawn2.transform.position, bulletSpawn2.transform.rotation);
            //sets alt to true so next run through yeilds opposite results 
            alt = true;
        }       
        //resets timer
        bulletTimer = 1; 
    }

    public void UltFire()
    {
        //instantiates an ult projectile at the current position of the ship
        Instantiate(UltFireProjectile, this.transform.position, this.transform.rotation);
    }

   public void OnTriggerEnter2D(Collider2D col)

    {
        //switch statement to deal with wall collision 
        //stops movement in current direction on contact with wall 
        switch (col.gameObject.tag)
        {
            case "LeftWall":

                canMoveLeft = false;
                
                break;

            case "RightWall":

                canMoveRight = false;

                break;
        }
    }
    
    public void OnTriggerExit2D(Collider2D col)
    {
        //switch statement to reenable movement after 
        //leaving collision with wall
        switch (col.gameObject.tag)
        {
            case "LeftWall":

                canMoveLeft = true;

                break;

            case "RightWall":

                canMoveRight = true;

                break;
        }
    }

}
