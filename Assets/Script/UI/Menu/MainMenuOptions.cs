using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour
{
    [SerializeField] private string defaultName = "game";
    public void OnCreate()
    {
        if (!Directory.Exists(SaveGame.SAVE_PATH))
            Directory.CreateDirectory(SaveGame.SAVE_PATH);

        this.defaultName += new DirectoryInfo(SaveGame.SAVE_PATH).GetFiles().Length;

        GameManager.SaveGame = new SaveGame(this.defaultName);
        GameManager.Fade.FadeStart("LevelSelector");
    }
    public void OnOptions(GameObject menu)
    {
        menu.SetActive(true);
    }
    public void OnCredits()
    {
        GameManager.Fade.FadeStart("Credits");
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
