using System;

[Serializable]
public class Level
{
    private string name;
    private int starCounter;

    public Level(string name, int starCounter)
    {
        this.Name = name;
        this.StarCounter = starCounter;
    }

    public string Name { get => name; set => name = value; }
    public int StarCounter { get => starCounter; set => starCounter = value; }
}
