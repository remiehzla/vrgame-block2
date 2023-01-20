using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipping : MonoBehaviour
{
    private Animator animator;
    private bool flippable = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spatula") && flippable)
        {
            animator.SetTrigger("Flip");
        }
    }

    public void MakeFlippable()
    {
        flippable = true;
    }

    public void MakeGrabbable()
    {
        gameObject.tag = "SpatulaGrabbable";
    }
}
