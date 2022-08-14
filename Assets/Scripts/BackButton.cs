using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackButton : MonoBehaviour
{
    public GameObject prevScene;
    public GameObject currentScene;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(GoBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Allows you to go back to the previous scene
    void GoBack()
    {
        currentScene.SetActive(false);
        prevScene.SetActive(true);
    }
}
