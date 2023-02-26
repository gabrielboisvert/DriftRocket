using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveGame
{
    public const string SAVE_PATH = "SaveGame/";
    public const string EXTENSION_FILE = ".gsg";

    private Dictionary<string, Level> levels;
    private int totalStarCount;
    private string filename;
    private string currentLevel;
    [JsonConstructor]
    public SaveGame(Dictionary<string, Level> Levels, int TotalStarCount)
    {
        this.Levels = Levels;
        this.TotalStarCount = TotalStarCount;
    }
    public SaveGame(string filename)
    {
        this.filename = filename;
        this.Levels = new Dictionary<string, Level>();
        this.TotalStarCount = 0;
    }
    [JsonIgnore]
    public string Filename { get => filename; set => filename = value; }
    [JsonIgnore]
    public string CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public Dictionary<string, Level> Levels { get => levels; set => levels = value; }
    public int TotalStarCount { get => totalStarCount; set => totalStarCount = value; }

    public void AddLevel(string levelName)
    {
        this.CurrentLevel = levelName;
        if (!this.Levels.ContainsKey(levelName))
            this.Levels.Add(levelName, new Level(levelName, 0));
    }
    public void SaveProgress()
    {
        if (!Directory.Exists(SAVE_PATH))
            Directory.CreateDirectory(SAVE_PATH);

        if (this.Levels.ContainsKey(this.CurrentLevel))
            if (this.Levels[this.CurrentLevel].StarCounter < GameManager.Player.StarCounter)
            {
                this.Levels[this.CurrentLevel].StarCounter = GameManager.Player.StarCounter;
                this.UpdateTotalStar();
                File.WriteAllText(SAVE_PATH + this.Filename + EXTENSION_FILE, JsonConvert.SerializeObject(this, Formatting.Indented));
            }
    }
    private void UpdateTotalStar()
    {
        this.totalStarCount = 0;
        foreach (KeyValuePair<string, Level> entry in this.levels)
            this.totalStarCount += entry.Value.StarCounter;
    }
}
