using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SceneManager3 : MonoBehaviour
{
    public GameObject bird;
    Manager manager;

    void Start()
    {
        GameObject empty = GameObject.Find("Manager");
        manager = empty.GetComponent<Manager>();

        Manager.onConversationCountChanged += OnConversationCountChanged;

        ActivateThingsForConversationIndex(manager.conversationCounter);
    }

    private void OnDestroy()
    {
        Manager.onConversationCountChanged -= OnConversationCountChanged;
    }

    public void OnConversationCountChanged(int count)
    {
        ActivateThingsForConversationIndex(count);
    }

    private void ActivateThingsForConversationIndex(int convoIndex)
    {
        switch (convoIndex)
        {
            case 0:
            case 1:
                bird.SetActive(false);
                break;
            case 2:
                bird.SetActive(true);
                break;
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
                bird.SetActive(false);
                break;
        }
    }
}