using UnityEngine;

public class InputManager : MonoBehaviour
{
    private ControlState _controlState = ControlState.IN_GAME;
    [SerializeField] private TreeController _treeController;
    [SerializeField] private DialogUIController _dialogUIController;

    enum ControlState
    {
        IN_GAME,
        DIALOG
    }

    private void Update()
    {
        if (_controlState == ControlState.IN_GAME)
        {
            var verticalInput = Input.GetAxis("Vertical");
            var horizontalInput = Input.GetAxis("Horizontal");
            _treeController.UpdateAxes(verticalInput, horizontalInput);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _treeController.OnActionPressed();
            }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                _dialogUIController.UserClickedAButtonWhileWeWereDoingADialogue();
            }
        }
    }

    public void HelloCanWeGoIntoDialogModePlease()
    {
        this._controlState = ControlState.DIALOG;
    }

    public void OkayWeCanGoBackToInGameControlsNowThanks()
    {
        this._controlState = ControlState.IN_GAME;
    } 
}