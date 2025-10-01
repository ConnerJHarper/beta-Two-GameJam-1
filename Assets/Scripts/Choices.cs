using UnityEngine;

[System.Serializable]
public class Choices 
{
    public string text;
    public Statement nextStatement;

    public int wealthchange;
    public int stresschange;
}
