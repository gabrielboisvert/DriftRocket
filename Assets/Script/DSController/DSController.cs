using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class DSController
{
    //Accelerator
    private static ButtonControl accelX = null;
    public static int scale = 1000;

    // Touch pad
    private static ButtonControl finger1Active = null;
    private static ButtonControl finger1PosY = null;

    private static ButtonControl leftPressure = null;
    private static ButtonControl rightPressure = null;

    private static Gamepad controller = null;

    private static bool hasBeenActivate = false;

    public static Gamepad Controller { get => controller; set => controller = value; }
    public static bool HasBeenActivate { get => hasBeenActivate; set => hasBeenActivate = value; }

    public static Gamepad Init(string layoutFile = null)
    {
        // Read layout from JSON file
        string layout = File.ReadAllText(layoutFile);
        InputSystem.RegisterLayoutOverride(layout, "DualShock4GamepadHID");

        DSController.Controller = Gamepad.current;
        DSController.BindControls(DSController.Controller);
        
        return Controller;
    }
    // Extract value from controller
    private static void BindControls(Gamepad ds)
    {
        accelX = ds.GetChildControl<ButtonControl>("gyro X 14");

        finger1Active = ds.GetChildControl<ButtonControl>("Finger 1 down");
        finger1PosY = ds.GetChildControl<ButtonControl>("Finger 1 yPos");

        leftPressure = ds.GetChildControl<ButtonControl>("leftTrigger");
        rightPressure = ds.GetChildControl<ButtonControl>("rightTrigger");
    }

    public static IEnumerator InitController()
    {
        yield return new WaitForSeconds(0.2f);

        if (!DSController.HasBeenActivate)
        {
            // Little hack to differentiate ps5 controller of a ps4 controller
            if (Gamepad.current.dpad.y.ReadValue() == 0)
                DSController.Init(Application.streamingAssetsPath + "/customLayoutDS4.json");
            else
                DSController.Init(Application.streamingAssetsPath + "/customLayoutDS5.json");

            DSController.HasBeenActivate = true;
        }
    }

    public static float accelerator()
    {
        try
        {
            return (int)(accelX.ReadValue() * scale);
        }
        catch (NullReferenceException)
        {
            return -1;
        }
    }
    
    public static bool IsFinger1Down()
    {
        try
        {
            return finger1Active.ReadValue() == 0;
        }
        catch (NullReferenceException)
        {
            return false;
        }
    }

    public static float GetTouch1PositionY()
    {
        try
        {
            return finger1PosY.ReadValue() * scale;
        }
        catch (NullReferenceException)
        {
            return -1;
        }
    }

    public static Vector2 getPressure()
    {
        try
        {
            return new Vector2(leftPressure.ReadValue(), rightPressure.ReadValue());
        }
        catch (NullReferenceException)
        {
            return Vector2.zero;
        }
    }
}