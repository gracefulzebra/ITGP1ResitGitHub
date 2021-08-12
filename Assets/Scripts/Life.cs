using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public int lifeValue;
    public int enemyTotal;
    public int killCounter=0;
    public GameObject[] aliensR1;
    public GameObject[] aliensR2; 
    public GameObject[] aliensR3;
    public GameObject[] aliensR4;


    void Start()
    {
        //aliens arrays search for AlienR# tags to assign 
        //the different rows of aliens to arrays
        aliensR1 = GameObject.FindGameObjectsWithTag("AlienR1");
        aliensR2 = GameObject.FindGameObjectsWithTag("AlienR2");
        aliensR3 = GameObject.FindGameObjectsWithTag("AlienR3");
        aliensR4 = GameObject.FindGameObjectsWithTag("AlienR4");
        
        //the total enemy counter is calculate with the length 
        //of the arrays +2 for the 2 unaccounted for golden ships
        enemyTotal = aliensR1.Length + aliensR2.Length + aliensR3.Length + aliensR4.Length + 2;

        //updates the life text object
        this.gameObject.GetComponent<Text>().text = "Health:" + lifeValue;

    }

    private void Update()
    {
        
        //if life condition is met, change to game over scene
        if (lifeValue <= 0)
        {
            SceneManager.LoadScene("Game Over");
        } 
        //if kill counter condition is met, change to level complete scene
        if (killCounter == enemyTotal)
        {
            SceneManager.LoadScene("Level Complete"); 
            
        }
          
        
    }
  
    
    
   

    public void LifeIncrement()
    {
        //reduce lifeValue by 1
        lifeValue--;
        //updates the life text object
        this.gameObject.GetComponent<Text>().text = "Health:" + lifeValue;

    }

    public void EnemyKilled()
    {
       //Increments killCounter by 1
        killCounter++;

    }
    
   
}
