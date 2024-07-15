using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFlatform : MonoBehaviour
{
   public WaitPoint waitpoint;
   public float speed;
   private int targetWaitpointIndex;
   private Transform previousWaitpoint;
   private Transform targetWaipoint;
   private float timeToWaitpoint;
   private float elaspTime;
   
   void Start()
   {
        TargetNextWaitpoint();
   }

   void FixedUpdate()
   {
        ChangeWaipointIndex();
   }

   private void TargetNextWaitpoint()
   {
        previousWaitpoint = waitpoint.GetWaitPoint(targetWaitpointIndex);
        targetWaitpointIndex = waitpoint.GetNextWaitPointIndex(targetWaitpointIndex);
        targetWaipoint = waitpoint.GetWaitPoint(targetWaitpointIndex);

        elaspTime = 0;

        float distanceToWaitpoint = Vector3.Distance(previousWaitpoint.position,targetWaipoint.position);
        timeToWaitpoint = distanceToWaitpoint/speed;
   }
   private void ChangeWaipointIndex()
   {
        elaspTime += Time.deltaTime;
        float elasped = elaspTime / timeToWaitpoint ;
        elasped = Mathf.SmoothStep(0,1,elasped);
        transform.position = Vector3.Lerp(previousWaitpoint.position,targetWaipoint.position,elasped);
        

        if(elasped >=1)
        {
            TargetNextWaitpoint();
        }

   }
   private void OnTriggerEnter(Collider other)
   {
        other.transform.SetParent(transform);
   }

   private void OnTriggerExit(Collider other)
   {
        other.transform.SetParent(null);
   }
}
