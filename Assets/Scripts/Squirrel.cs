using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Squirrel : MonoBehaviour
{
    private float _dialogActiveTime = 0f;
    [SerializeField] private float maxDialogActiveTime = 3f;

    [SerializeField] private List<string> dialogOptions;
    private int dialogCounter = 0;
    
    
    //todo - delete this, the squirrel won't have direct access to the Dialog controller, just for testing
    [SerializeField] private DialogUIController _dialogUIController;

    public void ActivateDialog()
    {
        FindObjectOfType<WorldStateManager>().hasSpokenToSquirrel = true;
        var dialogSuccess = _dialogUIController.doTinusText(dialogOptions[dialogCounter]);
        if (dialogSuccess)
        {
            dialogCounter++;
            if (dialogCounter >= dialogOptions.Count)
            {
                dialogCounter = 0;
            }
        }
    }
}