using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene(2);
    }

    public void QuitGame(){
        Debug.Log("GAMA OVAR");
        Application.Quit(); 
    }
}
