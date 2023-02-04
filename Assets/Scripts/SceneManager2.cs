using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager2 : MonoBehaviour
{
    public GameObject turtle; 
    Manager manager; 

    // Start is called before the first frame update
    void Start()
    {
        GameObject empty = GameObject.Find("Manager");
        manager = empty.GetComponent<Manager>();

        if(manager.conversationCounter == 0){
            
            turtle.SetActive(false);
        }
        if(manager.conversationCounter == 1){
            
            turtle.SetActive(false);
        }
        if(manager.conversationCounter == 2){
             
            turtle.SetActive(false);
        }
        if(manager.conversationCounter == 3){
            
            turtle.SetActive(false);
        }
        if(manager.conversationCounter == 4){
            
            turtle.SetActive(true);
        }
        if(manager.conversationCounter == 5 && manager.conversationCounter == 6){
            
            turtle.SetActive(false);
        }
        if(manager.conversationCounter == 7){
            
            turtle.SetActive(false);
        }
    }

}
