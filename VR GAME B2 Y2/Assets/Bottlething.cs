using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottlething : MonoBehaviour
{
    [SerializeField] private GameObject mixture;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mixture"))
        {
            mixture.SetActive(true);
        }
    }
}
