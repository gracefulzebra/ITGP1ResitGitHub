using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Inherits variables from AliensFiringR1 script

public class AlienFiringR3 : AlienFiringR1
{
   

    void Start()
    {
        //assigns AliensR3 tag objects to array
        aliens = GameObject.FindGameObjectsWithTag("AlienR3");

    }


    void Update()
    {
        //increments timer by delta time value
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireTimerMax)
        {
            //find random number between 0 and lenght of array
            r = Random.Range(0, aliens.Length);
            //selected number of the array is chosen to fire
            aliens[r].gameObject.GetComponent<Alien>().Fire();
            //fire timer is reset
            fireTimer = 0;

        }

    }


}

