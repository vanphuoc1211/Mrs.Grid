using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController1 : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    private  float  X;
    private float Y;
    public Transform target;


    private void  Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        X  += Input.GetAxis("Mouse X") * mouseSensitivity *Time.deltaTime;

        Y  += Input.GetAxis("Mouse Y") * mouseSensitivity *Time.deltaTime;

        var targetRotate = Quaternion.Euler(X,Y,0);
        transform.position = target.position - targetRotate*new Vector3(0,0,3f);
        transform.rotation = targetRotate;
    }
}
