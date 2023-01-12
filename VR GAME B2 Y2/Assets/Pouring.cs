using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouring : MonoBehaviour
{
    [SerializeField] private PouringTrigger pouringTrigger;
    private ParticleSystem particles;
    bool isPouring = false;
    bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.eulerAngles.x > 80 && transform.rotation.eulerAngles.x < 280)
        {
            isPouring = true;
            Invoke("StopPouring", 1);
        }
        if (transform.rotation.eulerAngles.x < -80 && transform.rotation.eulerAngles.x > -280)
        {
            isPouring = true;
            Invoke("StopPouring", 1);
        }
        if (transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 280)
        {
            isPouring = true;
            Invoke("StopPouring", 1);
        }
        if (transform.rotation.eulerAngles.z < -80 && transform.rotation.eulerAngles.z > -280)
        {
            isPouring = true;
            Invoke("StopPouring", 1);
        }

        if (isPouring)
        {
            particles.Emit(1);
        }
        
        if (triggered && isPouring)
        {
            pouringTrigger.EnableFood();
        }
    }

    void StopPouring()
    {
        if (isPouring)
        {
            isPouring = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        triggered = false;
    }
}
