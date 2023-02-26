using TMPro;
using UnityEngine;

public class LevelName : MonoBehaviour
{
    void Start()
    {
#if UNITY_EDITOR
        if (GameManager.SaveGame == null)
            return;
#endif
        GetComponent<TextMeshProUGUI>().text = GameManager.SaveGame.CurrentLevel;
    }
}
