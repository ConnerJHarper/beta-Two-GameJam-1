using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[System.Serializable]
public class Choices
{
    public string text;
    public Statement nextStatement;

    public int wealthChange; // starting value (make sure it's initialized properly)
    public int stress;

    // Adds wealth from WealthChange and updates UI

    public void ApplyChoice()
    {
        Debug.Log("Applying wealth change of " + wealthChange);
        WealthChange.Instance.AddWealth(wealthChange);
    }
}
