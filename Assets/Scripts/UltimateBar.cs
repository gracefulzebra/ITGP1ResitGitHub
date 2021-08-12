using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateBar : MonoBehaviour
{
    //slider component connection
    public Slider slider;
    //timer variables
    public float Timer=0;
    public float TimerMax; 
    //fire bool starts as false

    public bool fire = false;
    //assigns X key to keycode
    public KeyCode xKey = KeyCode.X;
    public GameObject ship;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //assigns X key to variable
        bool isXpressed = Input.GetKey(xKey);
        //increments timer by delta time value
            Timer += Time.deltaTime;
        //increments slider components fill
        slider.value = Timer;
      
        
        if (isXpressed && Timer >= TimerMax)
        {
            //resets timer 
            //runs UltFire functions on Ship script
            Timer = 0;
            ship = GameObject.FindGameObjectWithTag("Ship");
            ship.gameObject.GetComponent<Ship>().UltFire();
            
        }
        
    }
}
