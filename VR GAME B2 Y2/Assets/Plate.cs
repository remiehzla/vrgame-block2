using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] private Transform foodTransform;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spatula"))
        {
            if (other.GetComponent<Spatula>().isHolding)
            {
                other.GetComponent<Spatula>().grabbedFood.SetParent(foodTransform);
                other.GetComponent<Spatula>().isHolding = false;
            }
        }
    }
}
