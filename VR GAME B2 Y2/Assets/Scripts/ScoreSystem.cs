using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI textScore;
    public LeaderBoard scoreManager;

    private void Start()
    {
        score = 0;
        StartCoroutine(ScoreSave());
    }

    public void ScoreIncrease()
    {
        score++;
        
        textScore.text = "" + score;
    }

    IEnumerator ScoreSave()
    {
        yield return new WaitForSeconds(5f);
        yield return scoreManager.SubmitScoreRoutine(score);
    }
}
