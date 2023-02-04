using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager1 : MonoBehaviour
{
    public GameObject cave;
    public GameObject squirrel; 
    public Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject empty = GameObject.Find("Manager");
        manager = empty.GetComponent<Manager>();

        if(manager.conversationCounter == 0){
            cave.SetActive(false); 
            squirrel.SetActive(true); 
        }
        if(manager.conversationCounter == 1){
            cave.SetActive(true); 
            squirrel.SetActive(false); 
        }
        if(manager.conversationCounter == 2){
            cave.SetActive(false); 
            squirrel.SetActive(false); 
        }
        if(manager.conversationCounter == 3){
            cave.SetActive(true); 
            squirrel.SetActive(false); 
        }
        if(manager.conversationCounter == 4){
            cave.SetActive(false); 
            squirrel.SetActive(false); 
        }
        if(manager.conversationCounter == 5 && manager.conversationCounter == 6){
            cave.SetActive(true); 
            squirrel.SetActive(false); 
        }
        if(manager.conversationCounter == 7){
            cave.SetActive(false); 
            squirrel.SetActive(true); 
        }
    }

}
