using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSmashing : MonoBehaviour
{
    [SerializeField] private GameObject egg1;
    [SerializeField] private GameObject egg2;
    private Rigidbody rigidbody;

    private bool colliding;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rigidbody.velocity.y >= 0.5 && colliding)
        {
            egg1.SetActive(true);
            egg2.SetActive(true);
            gameObject.SetActive(false);
        }

        if (rigidbody.velocity.y <= -0.5 && colliding)
        {
            egg1.SetActive(true);
            egg2.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        colliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        colliding = false;
    }
}
