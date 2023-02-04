using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PondFish : MonoBehaviour
{
    //todo - this is identical to the Squirrel, this doesn't need to be 2 scripts

    [SerializeField] private GameObject dialogWindow;
    private TextMeshProUGUI textMesh;

    private float _dialogActiveTime = 0f;
    [SerializeField] private float maxDialogActiveTime = 3f;

    [SerializeField] private string preSquirrelDialog;
    [SerializeField] private string postSquirrelDialog;


    // Start is called before the first frame update
    void Start()
    {
        textMesh = dialogWindow.GetComponentInChildren<TextMeshProUGUI>();
    }

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

    //todo - delete
    public void ActivateDialog()
    {
        // if (FindObjectOfType<WorldStateManager>().hasSpokenToSquirrel)
        // {
        //     textMesh.text = postSquirrelDialog;
        // }
        // else
        // {
        //     textMesh.text = preSquirrelDialog;
        // }
        //
        // dialogWindow.SetActive(true);
    }
}