using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{  
    public static bool GameIsPaused = false;
    public GameObject PasueMenuUI;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    { 
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            if(GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        
        PasueMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        PasueMenuUI.SetActive(true);
        Time.timeScale  = 0f;
        GameIsPaused = true;
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
