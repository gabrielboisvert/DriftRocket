using UnityEngine.UI;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private string levelName;
    public void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(this.OnClick);

        if (GameManager.SaveGame.Levels.ContainsKey(this.levelName))
        {
            Transform stars = gameObject.transform.Find("Stars");
            for (int i = 0; i < GameManager.SaveGame.Levels[this.levelName].StarCounter; i++)
            {
                RawImage img = stars.GetChild(i).GetComponent<RawImage>();
                Texture2D[] textures = stars.GetChild(i).GetComponent<TextureArray>().Textures;
                img.texture = textures[1];
            }
        }
    }
    public void OnClick()
    {
        GameManager.SaveGame.AddLevel(levelName);
        GameManager.Fade.FadeStart(levelName);
    }
}