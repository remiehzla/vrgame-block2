using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouring : MonoBehaviour
{
    [SerializeField] private PouringTrigger pouringTrigger;
    private ParticleSystem particles;
    bool isPouring = false;
    bool triggered;

    [SerializeField] private float minParticleCount;
    private float particleCount;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.eulerAngles.x > 80)
        {
            particles.Emit(1);
            isPouring = true;
        }
        if (transform.rotation.eulerAngles.x < -80)
        {
            particles.Emit(1);
            isPouring = true;
        }
        if (transform.rotation.eulerAngles.z > 80)
        {
            particles.Emit(1);
            isPouring = true;
        }
        if (transform.rotation.eulerAngles.z < -80)
        {
            particles.Emit(1);
            isPouring = true;
        }

        if (triggered && isPouring)
        {
            IncreaseParticleCount();
        }

        if (particleCount > minParticleCount)
        {
            pouringTrigger.EnableFood();
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

    public void IncreaseParticleCount()
    {
        particleCount += 1;
    }
}
