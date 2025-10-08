using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

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
        Choices chosen = curStatement.choices[id];

        chosen.ApplyChoice();

        curStatement = curStatement.choices[id].nextStatement;
        SpecialCondition();
    }

    public void SpecialCondition()
    {
        if (curStatement.end)
        {
            SceneManager.LoadScene(loadLevel);
            Debug.Log("You Leave!");
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

    

