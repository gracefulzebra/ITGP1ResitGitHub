using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScene : MonoBehaviour
{
    public float delay = 5;
    //sets Main Menu to New Level variable
    public string NewLevel = "Main Menu";
    void Start()
    {
        //calls coroutine and passes delay parameter
        StartCoroutine(LoadLevelAfterDelay(delay));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        //waits for [delay] seconds 
        yield return new WaitForSeconds(delay); 
        //Loads New Level variable Scene
        SceneManager.LoadScene(NewLevel);
    }
}

