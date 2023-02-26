using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerUI))]
public class PlayerFallingDetector : Editor
{
    private void OnSceneGUI()
    {
        PlayerUI UI = (PlayerUI)target;

        Handles.color = Color.green;
        Handles.DrawWireCube(UI.transform.position, UI.FallingDetectorSize);

        Handles.color = Color.white;
        Handles.DrawWireCube(new Vector3(UI.transform.position.x, UI.transform.position.y, 0), UI.Cam.EdgeDetectorSize);
    }
}