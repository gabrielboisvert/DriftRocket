using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveGameButton : MonoBehaviour
{
    [SerializeField] private string saveGame;
    public string SaveGame { get => saveGame; set => saveGame = value; }
    public void OnClick()
    {
        GameManager.LoadSaveGame(this.SaveGame);
        GameManager.Fade.FadeStart("LevelSelector");
    }
}