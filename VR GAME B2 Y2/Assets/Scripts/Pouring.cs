using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouring : MonoBehaviour
{
    [SerializeField] private PouringTrigger pouringTrigger;
    private ParticleSystem particles;
    [SerializeField] private Transform transformRef;
    bool isPouring = false;
    bool triggered;

    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (transformRef.rotation.eulerAngles.x > 80 && transformRef.rotation.eulerAngles.x < 280)
        {
            isPouring = true;
            Invoke("StopPouring", 1);
        }
        if (transformRef.rotation.eulerAngles.x < -80 && transformRef.rotation.eulerAngles.x > -280)
        {
            isPouring = true;
            Invoke("StopPouring", 1);
        }
        if (transformRef.rotation.eulerAngles.z > 80 && transformRef.rotation.eulerAngles.z < 280)
        {
            isPouring = true;
            Invoke("StopPouring", 1);
        }
        if (transformRef.rotation.eulerAngles.z < -80 && transformRef.rotation.eulerAngles.z > -280)
        {
            isPouring = true;
            Invoke("StopPouring", 1);
        }
        // Check if the X and Z rotation are right for the liquid to pour out. Stop pouring after a second to check again.

        if (isPouring)
        {
            particles.Emit(1);
        }
        // If the liquid can be poured out, emit particles to visualize this.
        
        if (triggered && isPouring)
        {
            pouringTrigger.EnableFood();
        }
        // If the object collides with its desegnated trigger, access the trigger script to enable its food/ingredient.
    }

    void StopPouring()
    {
        if (isPouring)
        {
            isPouring = false;
        }
        // Stop pouring if the X and Z rotation no longer allow for it.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PouringTrigger>() == pouringTrigger)
        {
            triggered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PouringTrigger>() == pouringTrigger)
        {
            triggered = false;
        }
    }
    // Check if the object collides with its desegnated trigger.
}
