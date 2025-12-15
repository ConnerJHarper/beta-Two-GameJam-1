using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[System.Serializable]
public class Choices
{
    public string text;
    public Statement nextStatement;

    public int wealthChange; 
    public int stress;

    

    public void ApplyChoice()
    {
        Debug.Log("Applying wealth change of " + wealthChange);
        WealthChange.Instance.AddWealth(wealthChange);

        Debug.Log("Applying stress change of " + stress);
        MentalHealth.Instance.ChangeStress(stress);
    }
}
