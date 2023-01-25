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

    [SerializeField] private AudioSource mixSound;
    [SerializeField] private AudioSource mixSound2;

    [SerializeField] private GameObject mixture;

    void Update()
    {
        if (triggerCount >= neededTriggerCount)
        {
            EnableMixture();
            // If the whisk has collided with the triggers often enough, enable the mixture object.
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Whisk"))
        {
            triggerCount += 1;
            EnableNextTrigger();
            // If the object colliding with the trigger is a whisk, increase the trigger count and move the trigger.
        }
    }

    private void EnableNextTrigger()
    {
        if (trigger4.enabled == true)
        {
            trigger1.enabled = true;
            trigger4.enabled = false;
            mixSound.Play();
            mixSound2.Play();
        }
        if (trigger3.enabled == true)
        {
            trigger4.enabled = true;
            trigger3.enabled = false;
            mixSound.Play();
            mixSound2.Play();
        }
        if (trigger2.enabled == true)
        {
            trigger3.enabled = true;
            trigger2.enabled = false;
            mixSound.Play();
            mixSound2.Play();
        }
        if (trigger1.enabled == true)
        {
            trigger2.enabled = true;
            trigger1.enabled = false;
            mixSound.Play();
            mixSound2.Play();
        }
        // Enable the next trigger based on which one is currently enabled.
    }

    void EnableMixture()
    {
        mixture.SetActive(true);
    }
}
