using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FinalScene : MonoBehaviour
{
    private float currenttime = 0f;
    private float startingtime = 10f;
    public Text  coundownText;
    void Start()
    {
        currenttime = startingtime;
    }

    void Update()
    {
        currenttime -= 1*Time.deltaTime;
        coundownText.text =  currenttime.ToString("0");
        if(currenttime <= 0)
        {
            Yes();
        }
    }
    public void Yes()
    {
        SceneManager.LoadScene(1);
    }
    public void No()
    {
        SceneManager.LoadScene(0);
    }

}
