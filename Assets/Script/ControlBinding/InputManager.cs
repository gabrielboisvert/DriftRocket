using System;
using UnityEngine.InputSystem;
public class InputManager
{
    private static GenerateControl inputActions = new GenerateControl();
    private static event Action<InputActionMap> actionMapChange;
    public static void ToggleActionMap(InputActionMap actionMap)
    {
        if (actionMap.enabled)
            return;

        InputActions.Disable();
        actionMapChange?.Invoke(actionMap);
        actionMap.Enable();
    }
    public static GenerateControl InputActions { get => inputActions; set => inputActions = value; }
    public static Action<InputActionMap> ActionMapChange { get => actionMapChange; set => actionMapChange = value; }
}
