using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject manager; 

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(manager); 
        SceneManager.LoadScene(1);
    }
}
