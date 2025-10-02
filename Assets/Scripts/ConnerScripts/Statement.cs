using UnityEngine;


[CreateAssetMenu(fileName = "New Statement", menuName = "Statement")]
public class Statement : ScriptableObject
{
    public string person;
    public string statement;
    public Sprite picture;

    public Choices[] choices;

    public bool end; 
}
