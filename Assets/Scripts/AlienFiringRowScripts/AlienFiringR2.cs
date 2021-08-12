using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Inherits variables from AliensFiringR1 script
public class AlienFiringR2 : AlienFiringR1
{
    

    void Start()
    {
        //assigns AliensR2 tag objects to array
        aliens = GameObject.FindGameObjectsWithTag("AlienR2");

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
