using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouringParticle : MonoBehaviour
{
    [SerializeField] private Pouring pouring;

    private void OnParticleTrigger()
    {
        pouring.IncreaseParticleCount();
    }
}
