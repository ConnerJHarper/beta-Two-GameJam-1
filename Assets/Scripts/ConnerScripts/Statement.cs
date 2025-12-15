using UnityEngine;


[CreateAssetMenu(fileName = "New Statement", menuName = "Statement")]

// Create statement so we can input values in the unreal inspector
public class Statement : ScriptableObject
{
    // Public variables to allow to be called from another script
    public string person;
    public string statement;
    public Sprite picture;

    // Array of choices
    public Choices[] choices;

    public bool end; 
}
