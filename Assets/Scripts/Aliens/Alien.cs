using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public int health =3;
    public GameObject bomb;
    public GameObject bombSpawn;
    public GameObject lifeScript; 

    void Start()
    {
        
    }

    void Update()
    {
        //Checks health per frame in order to 
        //run kill function
        if (health <= 0)
        {
            Kill();
        }

        
    }

  

    public void Fire()
    {
        //instantiates a bomb at the bombspawn position
        Instantiate(bomb, bombSpawn.transform.position, bombSpawn.transform.rotation);
    }


    public void TakeDamage() 
    {
        //reduces health value by 1
        health--; 
    }

   public void Kill()
    { 
        //searches for the Text object and runs the EnemyKilled function 
        //on the Life script
        lifeScript = GameObject.Find("Text");
        lifeScript.GetComponent<Life>().EnemyKilled();
        //destroys game object
        Destroy(this.gameObject);
    }

    



}
