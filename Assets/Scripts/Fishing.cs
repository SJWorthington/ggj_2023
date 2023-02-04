using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fishing : MonoBehaviour
{
    private float timer; 
    private int seconds; 
    public GameObject alert; 
    private bool alerted = false;

    // Start is called before the first frame update
    void Start()
    {
        seconds = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; 
        float sec = timer % 60;
        seconds = (int)sec;

        if(alerted){
            Debug.Log("Alerted");
            if(Input.GetKeyDown("space")){
                //Randomise loot size 0-1 scale. 
                UnityEngine.Random.Range(0,1); 
            }
        }
    }

    public void GoFish(){
        seconds = 0; 
        if(seconds == 3){
            alert.SetActive(true);
            alerted = true;
        }
        if(seconds == 5){
            alert.SetActive(false);
            alerted = false;
        }
    }
}
