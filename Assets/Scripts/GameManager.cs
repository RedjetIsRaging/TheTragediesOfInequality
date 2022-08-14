using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject messageSystem;
    public Button simulationButton;
    public Button trainingButton;
    public Button nextDayButton;
    public Button duesButton;
    public GameObject titleScreen;
    public GameObject simulationScreen;
    public GameObject trainingScreen;
    public GameObject tutorial;
    public GameObject duesPanel;
    public TextMeshProUGUI notification;
    public TextMeshProUGUI moneyText;
    public Button nextButton;
    public float money;
    public float wage;
    public int day;
    public int hours;
    public int totalHours;
    public bool started = false;
    private bool cont = false;
    public List<string> condition;
    public Queue<string> messages;
    public bool fired;
    public GameObject summary;
    // Start is called before the first frame update
    void Start()
    {
        day = 1;
        money = 0;
        wage = 7.25f;
        hours = 8;
        totalHours = 0;
        fired = false;
        messageSystem.GetComponent<MessageSystem>().Initialize();
        nextDayButton.onClick.AddListener(EndDay);
        duesButton.onClick.AddListener(ToggleDuesPane);
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            moneyText.text = "Day " + day + "\n$ " + money;
            if (cont)
            {
                totalHours += hours;
                day++;
                Debug.Log(day);
                cont = false;
                notification.gameObject.SetActive(false);
                if(day % 7 == 1)
                {
                    totalHours = 0;
                }
                if (day % 7 == 0)
                {
                    totalHours += hours;
                    float sum = totalHours * wage;
                    money += sum;
                    notification.text = "You got paid $" + sum;
                    notification.gameObject.SetActive(true);
                    notification.color = Color.green;
                }
                if (day <= 28)
                {
                    messageSystem.GetComponent<MessageSystem>().SetMessage();
                }
                if (hours <= 0)
                {
                    fired = true;
                    hours = 0;
                }
            }
            if(day == 28)
            {
                nextDayButton.GetComponentInChildren<TextMeshProUGUI>().text = "End";
            }
            if(day > 28)
            {
                summary.SetActive(true);
            }
        }
    }
    //Starts game
    public void StartGame(string gameMode)
    {
        titleScreen.SetActive(false);
        if(gameMode == "Simulation")
        {
            simulationScreen.SetActive(true);
        }
        else if(gameMode == "Training")
        {
            trainingScreen.SetActive(true);
        }
    }

    public void Simulate()
    {
        tutorial.SetActive(false);
        started = true;
    }
    void EndDay()
    {
        if (!messageSystem.activeInHierarchy)
        {
            cont = true;
        }
    }
    void ToggleDuesPane()
    {
        Vector3 targetLocation = new Vector3(2, -8, 0);
        Vector3 returnLocation = new Vector3(2, -22, 0);
        if (!duesPanel.activeInHierarchy)
        {
            duesPanel.SetActive(true);
            duesPanel.transform.position = Vector3.Lerp(returnLocation ,targetLocation, 1.0f);
        }
        else
        {
            duesPanel.transform.position = Vector3.Lerp(targetLocation, returnLocation, 1.0f);
            duesPanel.SetActive(false);
        }
        
    }

}
