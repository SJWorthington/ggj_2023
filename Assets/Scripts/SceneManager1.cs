using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager1 : MonoBehaviour
{
    public GameObject cave;
    public GameObject squirrel; 
    public Manager manager;

    void Start()
    {
        GameObject empty = GameObject.Find("Manager");
        manager = empty.GetComponent<Manager>();

        Manager.onConversationCountChanged += onConversationCountChanged;

        ActivateThingsAccordingToConversation(manager.conversationCounter);
    }

    public void onConversationCountChanged(int count)
    {
        ActivateThingsAccordingToConversation(count);
    }

    public void ActivateThingsAccordingToConversation(int convoIndex)
    {
        switch (convoIndex)
        {
            case 0:
                cave.SetActive(false); 
                squirrel.SetActive(true);
                break;
            case 1:
                cave.SetActive(true); 
                squirrel.SetActive(false);
                break;
            case 2:
                cave.SetActive(false); 
                squirrel.SetActive(false);
                break;
            case 3:
                cave.SetActive(true); 
                squirrel.SetActive(false);
                break;
            case 4:
                cave.SetActive(false); 
                squirrel.SetActive(false);
                break;
            case 5:
            case 6:
                cave.SetActive(true); 
                squirrel.SetActive(false);
                break;
            case 7:
                cave.SetActive(false); 
                squirrel.SetActive(true);
                break;
        }
    }
}
