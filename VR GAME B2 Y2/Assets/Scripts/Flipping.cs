using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipping : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spatula"))
        {
            animator.SetTrigger("Flip");
        }
    }

    public void MakeGrabbable()
    {
        gameObject.tag = "SpatulaGrabbable";
    }
}
