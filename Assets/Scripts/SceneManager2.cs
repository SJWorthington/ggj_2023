using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager2 : MonoBehaviour
{
    public GameObject turtle;
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
        ActivateThingsForConversationIndex(manager.conversationCounter);
    }

    private void ActivateThingsForConversationIndex(int conversationIndex)
    {
        switch (conversationIndex)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                turtle.SetActive(false);
                break;
            case 4:
                turtle.SetActive(true);
                break;
            case 5:
            case 6:
            case 7:
                turtle.SetActive(false);
                break;
        }
    }
}