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
    public void AddWealth(WealthChange wc)
    {
        if (wc != null)
        {
            // Add wc.wealth to our local wealthChange
            wealthChange += wc.wealth;

            // Update UI text
            Text textField = GameObject.Find("WealthValue").GetComponent<Text>();
            textField.text = "" + wealthChange;

            // Debug log
            UnityEngine.Debug.Log("TotalWealth = " + wealthChange);
        }
        else
        {
            UnityEngine.Debug.LogError("WealthChange reference is null!");
        }
    }
}
