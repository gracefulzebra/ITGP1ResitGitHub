using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienFiringR1 : MonoBehaviour
{
    public GameObject[] aliens;
    //timer variables
    public float fireTimer = 0;
    public float fireTimerMax;
    public int r;
    

    void Start()
    { 
        //assigns AliensR1 tag objects to array
        aliens = GameObject.FindGameObjectsWithTag("AlienR1");

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
