using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    [SerializeField] private List<ConversationObject> conversations;
    private Manager manager;
    private DialogUIController _dialogUIController;

    private void Start()
    {
        manager = FindObjectOfType<Manager>();
        _dialogUIController = FindObjectOfType<DialogUIController>();
    }


    public void playNextConversation()
    {
        if (manager.conversationCounter >= conversations.Count)
        {
            Debug.Log("You broke the game lol");
            return;
        }

        var nextConversation = conversations[manager.conversationCounter];

        //todo - this is fucked, move please
        manager.conversationCounter++;

        //todo - move controller state to DIALOG
        //Doing it here is crap code, but oh well lol
        _dialogUIController.startADialog(nextConversation);
    }
}