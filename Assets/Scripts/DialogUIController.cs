using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DialogUIController : MonoBehaviour
{
    //todo - this but less lazy
    [SerializeField] private GameObject dialogCanvas;

    //[SerializeField] private DebugUI.Panel _textBgPanel;
    //[SerializeField] private DebugUI.Panel _portraitBgPanel;
    [SerializeField] private TextMeshProUGUI _dialogTextMesh;
    //[SerializeField] private Image _portraitImage;

    private float _dialogActiveTime = 0f;
    private float _maxDialogActiveTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogCanvas.activeSelf)
        {
            _dialogActiveTime += Time.deltaTime;
        }

        if (_dialogActiveTime > _maxDialogActiveTime)
        {
            dialogCanvas.SetActive(false);
            _dialogActiveTime = 0f;
        }
    }

    public bool doTinusText(string dialogText)
    {
        if (dialogCanvas.activeSelf) return false;
        _dialogTextMesh.SetText(dialogText);
        dialogCanvas.SetActive(true);
        return true;
    }
}