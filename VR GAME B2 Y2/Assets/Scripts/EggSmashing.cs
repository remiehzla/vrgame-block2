using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSmashing : MonoBehaviour
{
    [SerializeField] private GameObject egg1;
    [SerializeField] private GameObject egg2;
    [SerializeField] private Transform eggTransform;

    private Rigidbody rigidbody;

    [SerializeField] private float breakSpeed = 50;

    private bool colliding;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rigidbody.velocity.x >= breakSpeed * 0.01 && colliding)
        {
            BreakEgg();
        }

        if (rigidbody.velocity.x <= breakSpeed * -0.01 && colliding)
        {
            BreakEgg();
        }

        if (rigidbody.velocity.y >= breakSpeed * 0.01 && colliding)
        {
            BreakEgg();
        }

        if (rigidbody.velocity.y <= breakSpeed * -0.01 && colliding)
        {
            BreakEgg();
        }

        if (rigidbody.velocity.z >= breakSpeed * 0.01 && colliding)
        {
            BreakEgg();
        }

        if (rigidbody.velocity.z <= breakSpeed * -0.01 && colliding)
        {
            BreakEgg();
        }
    }

    void BreakEgg()
    {
        eggTransform.transform.SetParent(null);
        egg1.SetActive(true);
        egg2.SetActive(true);
        gameObject.SetActive(false);
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
