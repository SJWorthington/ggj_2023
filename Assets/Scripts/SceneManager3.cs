using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager3 : MonoBehaviour
{
    public GameObject bird; 
    Manager manager; 
    // Start is called before the first frame update
    void Start()
    {
        GameObject empty = GameObject.Find("Manager");
        manager = empty.GetComponent<Manager>();

        if(manager.conversationCounter == 0){
            bird.SetActive(false); 
            
        }
        if(manager.conversationCounter == 1){
            bird.SetActive(false); 
            
        }
        if(manager.conversationCounter == 2){
            bird.SetActive(true); 
            
        }
        if(manager.conversationCounter == 3){
            bird.SetActive(false); 
            
        }
        if(manager.conversationCounter == 4){
            bird.SetActive(false); 
            
        }
        if(manager.conversationCounter == 5 && manager.conversationCounter == 6){
            bird.SetActive(false); 
            
        }
        if(manager.conversationCounter == 7){
            bird.SetActive(false); 
            
        }
    }

}
