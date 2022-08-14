using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Event
{
    public string message;
    public int[] yesResult;
    public string yesMessage;
    public int[] noResult;
    public string noMessage;
    public bool requiresWork;
    public Event(string str, int[] y, string strY, int[] n, string strN, bool r)
    {
        message = str;
        yesResult = y;
        yesMessage = strY;
        noResult = n;
        noMessage = strN;
        requiresWork = r;
    }
}
public class MessageSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    public TextMeshProUGUI messageText;
    public Button yesButton;
    public Button noButton;
    public Button okButton;
    public List<Event> events = new List<Event>();
    public bool[] used = new bool[25];
    public int num;
    void Start()
    {

    }
    public void Initialize()
    {
        yesButton.onClick.AddListener(Yes);
        noButton.onClick.AddListener(No);
        okButton.onClick.AddListener(OK);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        int[] neutral = { 0, 0, 0, 0 };
        for (int i = 0; i < 5; i++)
        {
            int[] promotion = GeneratePromotion();
            events.Add(new Event("You got promoted for $" + promotion[0], promotion, "You got promoted !", neutral, "You refused to be promoted",true));
        }
        for (int i = 0; i < 3; i++)
        {
            events.Add(new Event("You became sick. Should you attend work?", new int[] { 0, -4, 0, 0 }, "You knew you needed money, so you took a risk and went to work. However, you ended up going home early by 4 hours due to a coworker noticing your illness.", neutral, "You decided not to go to work. Unfortunately, your boss doesn't give sick leave.",true));
        }
        events.Add(new Event("You were asked to join a union in order to increase wages. Should you join?", new int[] { 0, 0, -gameManager.hours, 0 }, "You ended up getting fired...", neutral, "You decided it was safer not to join. The other union members ended up getting fired.",true));
        for (int i = 0; i < 3; i++)
        {
            events.Add(new Event("Your friend invited you to a special event. However, it costs $100 in travel expenses and you miss a work day.", new int[] { 0, -8, -gameManager.hours, -100 }, "You decided to go, but your boss fired you for missing work.", neutral, "You told your friend that you couldn't attend although your friend wasn't very happy about it.",false));
        }
        events.Add(new Event("You have been thinking about asking your boss for a time extension to your time frame. Should you ask for it?", new int[] { 0, 0, 4, 0 }, "You asked for the extension and got it!", neutral, "You didn't feel like putting in the extra effort, so you didn't ask.",true));
        events.Add(new Event("You have been thinking about asking your boss for a time extension to your time frame. Should you ask for it?", neutral, "You asked, but your boss rejected the request.", neutral, "You didn't feel like putting in the extra effort, so you didn't ask.",true));
        events.Add(new Event("Your mother has gotten into an accident, and you were asked to pay $300 for part of her hospital bill. Do you pay for it?", new int[] { 0, 0, 0, -300 }, "You paid the $300", neutral, "You didn't pay for the bill, but rather sent a get well soon note.",false));
        for(int i = 0; i < 2; i++)
        {
            events.Add(new Event("You unfortunately got into an accident and had to pay $200 in damages", new int[] { 0, 0, 0, -200 }, "You paid for it.", new int[] { 0, 0, 0, -200 }, "You paid for it.", false));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMessage()
    {
        num = Random.Range(0,30);
        Debug.Log(num);
        while (used[num])
        {
            Debug.Log(num);
            num = Random.Range(0, 30);
        }

        if (num < events.Count)
        {
            if (!gameManager.fired || !events[num].requiresWork)
            {
                Debug.Log(gameManager.fired);
                Debug.Log(events[num].requiresWork);
                messageText.text = events[num].message;
                Display();
            }
        }
    }
    public void Display()
    {
        gameObject.SetActive(true);
    }

    public int[] GeneratePromotion()
    {
        return new int[4] { Random.Range(1, 5), 0, 0,0 };
    }

    void Yes()
    {
        if (num < 18)
        {
            int[] result = events[num].yesResult;
            gameManager.wage += result[0];
            gameManager.totalHours += result[1];
            gameManager.hours += result[2];
            gameManager.money += result[3];
            messageText.text = events[num].yesMessage;
            okButton.gameObject.SetActive(true);
        }
        
    }

    void No()
    {
        if (num < 18)
        {
            int[] result = events[num].noResult;
            gameManager.wage += result[0];
            gameManager.totalHours += result[1];
            gameManager.hours += result[2];
            gameManager.money += result[3];
            messageText.text = events[num].noMessage;
            okButton.gameObject.SetActive(true);
        }
    }

    void OK()
    {
        okButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
