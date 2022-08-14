using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DuesButton : MonoBehaviour
{
    public int cost;
    public int repeatTime;
    private Button button;
    private GameManager gameManager;
    public TextMeshProUGUI errorText;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(DeductDues);
    }

    // Update is called once per frame
    void Update()
    { 
    }

    public void DeductDues()
    {
        if (gameManager.money >= cost)
        {
            gameManager.money -= cost;
            gameObject.SetActive(false);
            button.onClick.RemoveAllListeners();
        }
        else
        {
            errorText.gameObject.SetActive(true);
            StartCoroutine(CountDown());
        }
    }
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(2);
        errorText.gameObject.SetActive(false);
    }
}
