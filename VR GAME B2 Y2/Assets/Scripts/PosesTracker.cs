using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosesTracker : MonoBehaviour
{
    public int numberOfPoses = 0;
    
    public void NumberOfPoses()
    {
        numberOfPoses++;
        Debug.Log("Number of poses done: " + numberOfPoses);
    }
   
}
