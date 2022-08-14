using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Summary : MonoBehaviour
{
    public List<string> messages;
    public TextMeshProUGUI tutorialText;
    private Button button;
    private int index = -1;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        messages = new List<string>();
        messages.Add("This was a basic glimpse into the lives of the low income. Unfortunately, it is even worse.");
        messages.Add("Most of these people aren't able to afford to support their family fully");
        messages.Add("And they tend to stay in the low income for generations.");
        messages.Add("The average wage is around $10 for the low income, but it still isn't enough.");
        messages.Add("So please, if you are an employer, consider increasing wages if you can. I know CEOs can afford to because they earn around 278 times as much as the workers.");
        messages.Add("Finally, to the low income reading this, there is still hope. You have to keep persevering. With proper experience, it is possible to increase your income level.");
        messages.Add("Thank you for completing this experience.");
        button.onClick.AddListener(ChangeText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeText()
    {
        index++;
        if(index == messages.Count - 1)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(End);
        }
        tutorialText.text = messages[index];
    }
    void End()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
