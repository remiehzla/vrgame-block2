using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouringTrigger : MonoBehaviour
{
    [SerializeField] private GameObject food;

    public void EnableFood()
    {
        food.SetActive(true);
    }
}
