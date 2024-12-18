using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    // Reference to the player input component.
    public static PlayerInput playerInput;

    // Inputs that will be referenced in other scripts to get their values and use them.
    public Vector2 moveInput { get; private set; }

    public bool attackInput { get; private set; }
    public bool restartInput { get; private set; }
    public bool quitInput { get; private set; }

    // Input actions in the controls input action asset.
    // More specifically, the Player map.
    private InputAction moveAction;

    private InputAction attackAction;
    private InputAction restartAction;
    private InputAction quitAction;

    // Input actions in the UI map.
    private InputAction restartActionUI;
    private InputAction quitActionUI;

    private void Awake()
    {
        // Assign playerInput reference.
        playerInput = GetComponent<PlayerInput>();

        // Setup the input actions so we can then use them.
        SetupInputActions();
    }

    private void Update()
    {
        // Constantly update the inputs to make the correct information is being sent to other scripts.
        UpdateInputs();
    }

    private void SetupInputActions()
    {
        // Assign the input action by indicating the action's name from the action map that is contained in the PlayerInput component.
        moveAction = playerInput.actions["Move"];
        attackAction = playerInput.actions["Attack"];
        restartAction = playerInput.actions["Restart"];
        quitAction = playerInput.actions["Quit"];

        // UI input actions.
        restartActionUI = playerInput.actions["RestartUI"];
        quitActionUI = playerInput.actions["QuitUI"];
    }

    private void UpdateInputs()
    {
        // Set the values for the input actions.
        // Move uses vector 2 for x and y cords that are used to determine movement.
        moveInput = moveAction.ReadValue<Vector2>();

        // Below actions check if the user has pressed the button.
        attackInput = attackAction.WasPressedThisFrame();
        restartInput = restartAction.WasPressedThisFrame() || restartActionUI.WasPressedThisFrame();
        quitInput = quitAction.WasPressedThisFrame() || quitActionUI.WasPressedThisFrame();
    }
}