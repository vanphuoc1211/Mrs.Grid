using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public void Level1()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(2);
    }
    public void Level3()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(3);
    }
    public void Level4()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(4);
    }
    public void Level5()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(5);
    }

}
