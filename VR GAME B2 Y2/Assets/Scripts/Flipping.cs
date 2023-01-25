using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipping : MonoBehaviour
{
    private Animator animator;
    private bool flippable = false;

    [SerializeField] private AudioSource flipSound;

    public LeaderBoard leaderBoard;
    public PosesTracker posesTracker;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spatula") && flippable)
        {
            animator.SetTrigger("Flip");
            flipSound.Play();
        }
    }

    public void MakeFlippable()
    {
        flippable = true;
    }

    public void MakeGrabbable()
    {
        gameObject.tag = "SpatulaGrabbable";
        StartCoroutine(ScoreSave());
    }

    public IEnumerator ScoreSave()
    {
        yield return new WaitForSeconds(2f);
        yield return leaderBoard.SubmitScoreRoutine(posesTracker.numberOfPoses);
        Debug.Log("Uploaded");
    }
}
