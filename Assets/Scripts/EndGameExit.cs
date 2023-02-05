using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameExit : MonoBehaviour
{
    private float timeSinceOpen = 0f;
    private float macxTime = 5f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceOpen += Time.deltaTime;
        if (timeSinceOpen > macxTime)
        {
            Application.Quit();
        }
    }
}