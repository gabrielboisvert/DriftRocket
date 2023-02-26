using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SaveGamesMenu : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private float padding = 25;
    public float Padding { get => padding; set => padding = value; }
    public void Awake()
    {
        DirectoryInfo info = new DirectoryInfo(SaveGame.SAVE_PATH);
        FileInfo[] files = info.GetFiles().OrderByDescending(p => p.LastWriteTime).ToArray();
        int i = 0;
        foreach (FileInfo file in files)
        {
            if (!file.Name.Contains(SaveGame.EXTENSION_FILE))
                continue;

            GameObject obj = Instantiate(button, this.transform.position, Quaternion.identity);
            obj.transform.SetParent(this.transform);

            RectTransform objRect = obj.GetComponent<RectTransform>();
            objRect.anchoredPosition = new Vector2(0, -((Padding * i) + (i * objRect.rect.size.y)));
            objRect.transform.localScale = this.button.transform.localScale;

            string fileName = file.Name.Substring(0, file.Name.IndexOf('.'));

            obj.GetComponent<SaveGameButton>().SaveGame = file.Name;
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = fileName;

            SaveGame save = JsonConvert.DeserializeObject<SaveGame>(File.ReadAllText(SaveGame.SAVE_PATH + file.Name));

            obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += save.TotalStarCount.ToString();
            obj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text += file.LastWriteTime.ToString("dd/MM/yyyy HH:mm");
            i++;
        }
    }
}