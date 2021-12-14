using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Game : MonoBehaviour
{
    public Text ScoreText;
    public GameObject CurrentPlayer;

    void Start()
    {
        CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        UpdateScoreText();
    }


    public void Add10Points()
    {
        CurrentPlayer.GetComponent<CurrentPlayer>().Score += 10;
        UpdateScoreText();
    }

    public void Add100Points()
    {
        CurrentPlayer.GetComponent<CurrentPlayer>().Score += 100;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        ScoreText.text = "Score: " + CurrentPlayer.GetComponent<CurrentPlayer>().Score.ToString();
    }


    public void EndGame()
    {
        StartCoroutine(SavePlayerScore());
    }

    IEnumerator SavePlayerScore()
    {
        string username = CurrentPlayer.GetComponent<CurrentPlayer>().Username;
        string scoreFromPlayer = CurrentPlayer.GetComponent<CurrentPlayer>().Score.ToString();
        WWWForm scoreForm = new WWWForm();
        //scoreForm.AddField("apppassword", "thisisfromtheapp!");
        scoreForm.AddField("username", username);
        scoreForm.AddField("score", scoreFromPlayer);
        UnityWebRequest updatePlayerRequest = UnityWebRequest.Post("localhost:8888/updateplayerscore.php", scoreForm);
        yield return updatePlayerRequest.SendWebRequest();
        if (updatePlayerRequest.error == null)
        {
            string result = updatePlayerRequest.downloadHandler.text;
            Debug.Log(result);
            if (result == "0")
            {
                FindObjectOfType<SceneSwitcher>().LoadPlayerWelcomeScene();
            } else
            {
                Debug.Log("Error!!");
            }

        } else
        {  
            Debug.Log(updatePlayerRequest.error);
        }
    }


}
