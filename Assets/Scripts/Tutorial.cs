using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
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
        messages.Add("You have to pay $1000 dollars a month for your rent while also paying $360 a month for food.");
        messages.Add("As a part of the simulation, you must manage your expenses while trying to stay afloat");
        messages.Add("The Dues button is used to view your expenses that you have to pay.");
        messages.Add("You many also encounter surprise events that may cause some financial issues and difficult choices");
        messages.Add("That is it for the tutorial. Press start to begin.");
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
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Start";
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(gameManager.Simulate);
        }
        tutorialText.text = messages[index];
    }
}
