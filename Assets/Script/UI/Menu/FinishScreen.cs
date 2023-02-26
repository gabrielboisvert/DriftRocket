using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;
    void Start()
    {
        Time.timeScale = 0;
        this.GetComponentInChildren<TextMeshProUGUI>().text = timer.text;
        this.timer.enabled = false;

        GameObject stars = this.transform.Find("StarsUI").gameObject;
        for (int i = 0; i < GameManager.Player.StarCounter; i++)
        {
            GameObject star = stars.transform.GetChild(i).gameObject;
            star.GetComponent<RawImage>().texture = star.GetComponent<TextureArray>().Textures[1];
        }
    }
    public void OnNext()
    {
        Time.timeScale = 1;
        if (SceneManager.sceneCount - 1 == SceneManager.GetActiveScene().buildIndex)
            GameManager.Fade.FadeStart("LevelSelector");
        else
            GameManager.Fade.FadeStart(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnReset()
    {
        Time.timeScale = 1;
        GameManager.Fade.FadeStart(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnMainMenu()
    {
        Time.timeScale = 1;
        GameManager.Fade.FadeStart("LevelSelector");
    }
}
