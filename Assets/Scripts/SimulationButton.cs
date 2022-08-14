using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SimulationButton : MonoBehaviour
{
    public Button button;
    public string gameMode;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Sets gamemode and starts game
    void SetMode()
    {
        gameMode = "Simulation";
        gameManager.StartGame(gameMode);
    }
}
