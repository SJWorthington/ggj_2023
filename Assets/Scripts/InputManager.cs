using UnityEngine;

public class InputManager : MonoBehaviour
{
    private ControlState _controlState = ControlState.IN_GAME;
    [SerializeField] private TreeController _treeController;
    [SerializeField] private DialogInputController _dialogInputController;

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
                _treeController.ONActionPressed();
            }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                _dialogInputController.SomethingWasPressedAndNowDoAThingPlease();
            }
        }
    }
}