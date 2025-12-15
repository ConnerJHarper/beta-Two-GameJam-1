using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class DisplayManager : MonoBehaviour 
{
    public Statement currentStatement; 

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
        Choices chosen = currentStatement.choices[id];

        chosen.ApplyChoice();

        currentStatement = currentStatement.choices[id].nextStatement;
        SpecialCondition();
    }

    public void SpecialCondition()
    {
        if (currentStatement.end)
        {
            SceneManager.LoadScene(loadLevel);
            StartCoroutine(RefreshWealthAfterSceneLoad());
            
        }
        else
        {
            DisplayNextStatement();
        }
    }

    private IEnumerator RefreshWealthAfterSceneLoad()
    {
        yield return null;
        WealthChange.Instance.UpdateWealthUI();
    }


            public void DisplayNextStatement()
            {
                personText.text = currentStatement.person;
                statementText.text = currentStatement.statement;
                picture.sprite = currentStatement.picture;

                for (int x = 0; x < choiceButtons.Length; x++)
                {
                    if (x < currentStatement.choices.Length)
                    {
                        choiceButtons[x].gameObject.SetActive(true);
                        choiceButtons[x].transform.GetChild(0).GetComponent<Text>().text = currentStatement.choices[x].text;
                        
                    }
                    else
                    {
                        choiceButtons[x].gameObject.SetActive(false);
                    
            }       }
                }
}

    

