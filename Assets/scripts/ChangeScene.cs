using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int Scene;
    public void OnTriggerEnter(Collider  other)
    {
        SceneManager.LoadScene(Scene);
    }
}
