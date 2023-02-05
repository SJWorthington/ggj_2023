using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogUIController : MonoBehaviour
{
    //todo - this but less lazy
    //todo ^ ignore above comment, embrace lazy
    [SerializeField] private GameObject dialogCanvas;
    [SerializeField] private GameObject tinusCanvas;
    [SerializeField] private GameObject treeCanvas;
    [SerializeField] private GameObject tiberiusCanvas;
    [SerializeField] private GameObject tootersCanvas;
    [SerializeField] private GameObject trishCanvas;

    [SerializeField] private TextMeshProUGUI _dialogTextMesh;

    private int currentConversationIndex;

    private ConversationObject currentConversation;

    [SerializeField] private InputManager _inputManager;

    private Manager whyDoesEveryClassHaveThisBloodyManager;


    // Start is called before the first frame update
    private void Start()
    {
        whyDoesEveryClassHaveThisBloodyManager = FindObjectOfType<Manager>();
    }

    public void UserClickedAButtonWhileWeWereDoingADialogue()
    {
        currentConversationIndex++;
        if (currentConversationIndex == currentConversation.text.Count)
        {
            endTheDialog();
            return;
        }

        DisplayNextDialog(currentConversationIndex);
    }

    private void endTheDialog()
    {
        this.currentConversation = null;
        currentConversationIndex = 0;
        tinusCanvas.SetActive(false);
        trishCanvas.SetActive(false);
        tootersCanvas.SetActive(false);
        tiberiusCanvas.SetActive(false);
        treeCanvas.SetActive(false);
        dialogCanvas.SetActive(false);

        //todo - magic number is good :+1:
        if (whyDoesEveryClassHaveThisBloodyManager.conversationCounter <= 7)
        {
            //todo - this is fucked, move please
            whyDoesEveryClassHaveThisBloodyManager.conversationCounter++;
            _inputManager.OkayWeCanGoBackToInGameControlsNowThanks();
        }
        else
        {
            SceneManager.LoadScene(5);
        }
    }

    public void startADialog(ConversationObject conversation)
    {
        _inputManager.HelloCanWeGoIntoDialogModePlease();
        this.currentConversation = conversation;
        dialogCanvas.SetActive(true);
        DisplayNextDialog(0);
    }

    private void DisplayNextDialog(int conversationIndex)
    {
        var speaker = currentConversation.characterSpeaking[conversationIndex];
        var text = currentConversation.text[conversationIndex];

        _dialogTextMesh.SetText(text);
        dialogCanvas.SetActive(true);
        //this is really, really good code
        switch (speaker)
        {
            case ConversationObject.Character.TREE:
                tinusCanvas.SetActive(false);
                trishCanvas.SetActive(false);
                tootersCanvas.SetActive(false);
                tiberiusCanvas.SetActive(false);
                treeCanvas.SetActive(true);
                break;
            case ConversationObject.Character.TINUS:
                treeCanvas.SetActive(false);
                trishCanvas.SetActive(false);
                tootersCanvas.SetActive(false);
                tiberiusCanvas.SetActive(false);
                tinusCanvas.SetActive(true);
                break;
            case ConversationObject.Character.TRISH:
                tinusCanvas.SetActive(false);
                treeCanvas.SetActive(false);
                tootersCanvas.SetActive(false);
                tiberiusCanvas.SetActive(false);
                trishCanvas.SetActive(true);
                break;
            case ConversationObject.Character.TOOTERS:
                tinusCanvas.SetActive(false);
                treeCanvas.SetActive(false);
                tiberiusCanvas.SetActive(false);
                trishCanvas.SetActive(false);
                tootersCanvas.SetActive(true);
                break;
            case ConversationObject.Character.TIBERIUS:
                tinusCanvas.SetActive(false);
                treeCanvas.SetActive(false);
                trishCanvas.SetActive(false);
                tootersCanvas.SetActive(false);
                tiberiusCanvas.SetActive(true);
                break;
        }
    }
}