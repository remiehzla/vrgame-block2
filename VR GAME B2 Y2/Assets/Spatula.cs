using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spatula : MonoBehaviour
{
    [SerializeField] private Transform foodTransform;
    [SerializeField] private Transform transformRef;
    public bool isHolding = false;
    public Transform grabbedFood;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpatulaGrabbable") && isHolding == false)
        {
            other.transform.SetParent(foodTransform);
            grabbedFood = other.transform;
            isHolding = true;
        }
    }
}
