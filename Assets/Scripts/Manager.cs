using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject manager;

    private int _conversationCounter;

    public int conversationCounter
    {
        get { return _conversationCounter; }
        set
        {
            _conversationCounter = value;
            onConversationCountChanged(value);
        }
    }
    
    public static event Action<int> onConversationCountChanged;


    public bool boot = false;
    public bool tire = false;
    public bool tinCan = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(manager); 
        SceneManager.LoadScene(1);
    }

}
