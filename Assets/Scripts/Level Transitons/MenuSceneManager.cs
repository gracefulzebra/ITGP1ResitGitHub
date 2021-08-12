using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuSceneManager : MonoBehaviour
{
    public void ChangeScene()
    {
        //changes scene to Main Game
        
        SceneManager.LoadScene("Main Game");
    }
}
