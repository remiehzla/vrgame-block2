using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixing : MonoBehaviour
{
    [SerializeField] private BoxCollider trigger1;
    [SerializeField] private BoxCollider trigger2;
    [SerializeField] private BoxCollider trigger3;
    [SerializeField] private BoxCollider trigger4;

    [SerializeField] private int neededTriggerCount = 20;
    private int triggerCount = 0;

    [SerializeField] private GameObject mixture;

    void Update()
    {
        if (triggerCount >= neededTriggerCount)
        {
            EnableMixture();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Whisk"))
        {
            triggerCount += 1;
            EnableNextTrigger();
        }
    }

    private void EnableNextTrigger()
    {
        if (trigger4.enabled == true)
        {
            trigger1.enabled = true;
            trigger4.enabled = false;
        }
        if (trigger3.enabled == true)
        {
            trigger4.enabled = true;
            trigger3.enabled = false;
        }
        if (trigger2.enabled == true)
        {
            trigger3.enabled = true;
            trigger2.enabled = false;
        }
        if (trigger1.enabled == true)
        {
            trigger2.enabled = true;
            trigger1.enabled = false;
        }
    }

    void EnableMixture()
    {
        mixture.SetActive(true);
    }
}
