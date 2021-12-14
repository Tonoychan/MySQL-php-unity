using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class PlayerGameScript : MonoBehaviour
{
    public Text UserInfoText;
    

    private void Start()
    {
        var CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        string CurrentPlayerUsername = CurrentPlayer.GetComponent<CurrentPlayer>().Username;
        int CurrentPlayerScore = CurrentPlayer.GetComponent<CurrentPlayer>().Score;

        UserInfoText.text = "User: " + CurrentPlayerUsername + " | " + "Points: " + CurrentPlayerScore.ToString();
    }

    public void StartGame()
    {
        FindObjectOfType<SceneSwitcher>().LoadGame();
    }

    public void LoadLeaderboards()
    {
        FindObjectOfType<SceneSwitcher>().LoadLeaderboardScene();
    }
    public void SignOut()
    {
        var CurrentPlayers = GameObject.FindGameObjectsWithTag("CurrentPlayer");
        foreach(var item in CurrentPlayers)
        {
            Destroy(item);
        }
        FindObjectOfType<SceneSwitcher>().LoadWelcomeScene();
    }
}
