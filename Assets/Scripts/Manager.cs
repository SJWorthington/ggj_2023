using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject manager;

    public int conversationCounter;

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
