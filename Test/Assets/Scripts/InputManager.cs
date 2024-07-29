using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputControl _inputControl;
    
    [SerializeField] private bool startInput = false;
    public Vector2 movementInput;
    
    
    private void Start()
    {
        if (_inputControl == null)
        {
            _inputControl = new InputControl();

            _inputControl.Global.StartGame.performed += i => startInput = true;
            _inputControl.Camera.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }
        _inputControl.Enable();
    }

    private void Update()
    {
        HandleAllInput();
    }

    private void HandleAllInput()
    {
        HandleStartInput();
    }

    private void HandleStartInput()
    {
        if (startInput)
        {
            startInput = false;
            Debug.Log("Start!");
            GameEvent.Rolled();
        }
    }
}
