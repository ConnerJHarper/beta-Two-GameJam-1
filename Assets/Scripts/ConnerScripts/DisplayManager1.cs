using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayManager : MonoBehaviour 
{
    public Statement curStatement; 

    public Text personText;
    public Text statementText;
    public Image picture;
    public int MentalValue;
    public string loadLevel;

    public Button[] choiceButtons;

    void Start()
    {
        SpecialCondition();
    }

    public void ChoiceClicked(int id)
    {
        curStatement = curStatement.choices[id].nextStatement;
        SpecialCondition();
    }

    public void SpecialCondition()
    {
        if (curStatement.end)
        {
            SceneManager.LoadScene(loadLevel);
            Debug.Log("You Leave!");
            
        }
        else
        {
            DisplayNextStatement();
        }
    }


            public void DisplayNextStatement()
            {
                personText.text = curStatement.person;
                statementText.text = curStatement.statement;
                picture.sprite = curStatement.picture;

                for (int x = 0; x < choiceButtons.Length; x++)
                {
                    if (x < curStatement.choices.Length)
                    {
                        choiceButtons[x].gameObject.SetActive(true);
                        choiceButtons[x].transform.GetChild(0).GetComponent<Text>().text = curStatement.choices[x].text;
                        
                    }
                    else
                    {
                        choiceButtons[x].gameObject.SetActive(false);
                    
            }       }
                }
}

    

