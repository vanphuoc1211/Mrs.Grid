using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitPoint : MonoBehaviour
{
    public Transform GetWaitPoint(int waitpointindex)
    {
        return transform.GetChild(waitpointindex);
    }

    public int GetNextWaitPointIndex(int currentWaitpointIndex)
    {
        int nextWaitpointIndex = currentWaitpointIndex +1;

        if (nextWaitpointIndex == transform.childCount)
        {
            nextWaitpointIndex = 0;
        }

        return nextWaitpointIndex;  
    }
}
