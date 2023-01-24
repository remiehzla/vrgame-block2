using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public LeaderBoard leaderBoard;
    public TMP_InputField playerNameInputfield;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupRoutine());
    }


    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputfield.text, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Succesfully set player name");
            }
            else
            {
                Debug.Log("COULD NOT SET PLAYER NAME" + response.Error);
            }


        });
    }

    IEnumerator SetupRoutine()  
    {
        yield return LoginRoutine();
        yield return leaderBoard.FetchTopHighScoresRoutine();
    }
    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player Logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Could not Start");
                done = true;
            }
        });

        yield return new WaitWhile(() => done == false);

    }
}
