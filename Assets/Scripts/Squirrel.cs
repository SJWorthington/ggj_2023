using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Squirrel : MonoBehaviour
{
    [SerializeField] private GameObject dialogWindow;
    private TextMeshProUGUI textMesh;

    private float _dialogActiveTime = 0f;
    [SerializeField] private float maxDialogActiveTime = 3f;

    [SerializeField] private List<string> dialogOptions;
    private int dialogCounter = 0;

    private void Start()
    {
        textMesh = dialogWindow.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogWindow.activeSelf)
        {
            _dialogActiveTime += Time.deltaTime;
        }

        if (_dialogActiveTime > maxDialogActiveTime)
        {
            dialogWindow.SetActive(false);
            _dialogActiveTime = 0f;
        }
    }

    public void ActivateDialog()
    {
        FindObjectOfType<WorldStateManager>().hasSpokenToSquirrel = true;
        if (dialogWindow.activeSelf) return;
        textMesh.text = dialogOptions[dialogCounter];
        dialogCounter++;
        if (dialogCounter >= dialogOptions.Count)
        {
            dialogCounter = 0;
        }
        dialogWindow.SetActive(true);
    }
}