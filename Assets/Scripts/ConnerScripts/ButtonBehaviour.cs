using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public Button myButton;
    public WealthChange wealthChange;

    private Choices choices = new Choices();



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (myButton != null)
        {
            myButton.onClick.AddListener(OnButtonClick);
        }

        


    }

    public void OnButtonClick()
    {
        choices.AddWealth(wealthChange);

    }
}
