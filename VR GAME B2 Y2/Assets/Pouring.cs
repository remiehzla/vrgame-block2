using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouring : MonoBehaviour
{
    [SerializeField] private PouringTrigger pouringTrigger;
    private ParticleSystem particles;
    bool spillLiquid = false;

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
        }
        if (transform.rotation.eulerAngles.x < -80)
        {
            particles.Emit(1);
        }
        if (transform.rotation.eulerAngles.z > 80)
        {
            particles.Emit(1);
        }
        if (transform.rotation.eulerAngles.z < -80)
        {
            particles.Emit(1);
        }

        if (particleCount > minParticleCount)
        {
            pouringTrigger.EnableFood();
        }
    }

    void Spill()
    {
        spillLiquid = !spillLiquid;
    }

    public void IncreaseParticleCount()
    {
        particleCount += 1;
    }
}
