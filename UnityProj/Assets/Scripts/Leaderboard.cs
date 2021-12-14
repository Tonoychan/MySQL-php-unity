using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using System;

public class Leaderboard : MonoBehaviour
{
    public GameObject leaderPrefab;
    public GameObject panel;

    public InputField searchInput;
    public Button searchButton;
    public Text searchButtonText;

    void Start()
    {
        StartCoroutine(GetallPlayers());
        
    }

    public void LoadPlayerScene()
    {
        FindObjectOfType<SceneSwitcher>().LoadPlayerWelcomeScene();
    }

    IEnumerator GetallPlayers()
    {
        WWWForm getAllPlayersForm = new WWWForm();
        getAllPlayersForm.AddField("apppassword", "thisisfromtheapp!");
        UnityWebRequest getAllPlayersRequest = UnityWebRequest.Post("localhost:8888/getall.php", getAllPlayersForm);
        yield return getAllPlayersRequest.SendWebRequest();
        if (getAllPlayersRequest.error == null)
        {
            int rank = 1;
            JSONNode allPlayers = JSON.Parse(getAllPlayersRequest.downloadHandler.text);
            foreach(JSONNode player in allPlayers)
            {
                var leaderBoardPlayer = Instantiate(leaderPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                leaderBoardPlayer.transform.SetParent(panel.transform);
                leaderBoardPlayer.GetComponent<LeaderboardPlayer>().username = player[0];
                leaderBoardPlayer.GetComponent<LeaderboardPlayer>().score = int.Parse(player[1]);
                leaderBoardPlayer.GetComponent<LeaderboardPlayer>().rank = rank;
                leaderBoardPlayer.GetComponent<LeaderboardPlayer>().AssignInfo();
                rank++;
            }
        } else
        {
            Debug.Log(getAllPlayersRequest.error);
        }
    }

    public void search()
    {
        DestroyAllLeaderboardPlayers();
        DisableSearchButton();
        if(searchInput.text == "")
        {
            StartCoroutine(GetallPlayers());
            ResetSearchButton();
        } else
        {
            StartCoroutine(SearchForPlayer());
        } 
    }

    IEnumerator SearchForPlayer()
    {

        WWWForm searchForm = new WWWForm();
        searchForm.AddField("apppassword", "thisisfromtheapp!");
        searchForm.AddField("search", searchInput.text);
        UnityWebRequest searchForPlayersRequest = UnityWebRequest.Post("localhost:8888/search.php", searchForm);
        yield return searchForPlayersRequest.SendWebRequest();
        if(searchForPlayersRequest.error == null)
        {
            Debug.Log(searchForPlayersRequest.downloadHandler.text);
            JSONNode allPlayers = JSON.Parse(searchForPlayersRequest.downloadHandler.text);
            try
            {
                foreach (JSONNode player in allPlayers)
                {
                    var leaderBoardPlayer = Instantiate(leaderPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    leaderBoardPlayer.transform.SetParent(panel.transform);
                    leaderBoardPlayer.GetComponent<LeaderboardPlayer>().username = player[0];
                    leaderBoardPlayer.GetComponent<LeaderboardPlayer>().score = int.Parse(player[1]);
                    leaderBoardPlayer.GetComponent<LeaderboardPlayer>().AssignSearchInfo();
                }
            } catch(Exception e)
            {
                Debug.Log(e);
            }
            
        } else
        {
            Debug.Log(searchForPlayersRequest.error);
        }
        ResetSearchButton();
    }

    public void DisableSearchButton()
    {
        searchButtonText.text = "Searching...";
        searchButton.GetComponent<Image>().color = Color.grey;
        searchButton.interactable = false;
    }

    public void ResetSearchButton()
    {
        searchButtonText.text = "Search";
        searchButton.GetComponent<Image>().color = Color.white;
        searchButton.interactable = true;
    }

    public void DestroyAllLeaderboardPlayers()
    {
        var leadboardPlayers = GameObject.FindGameObjectsWithTag("LeaderboardPlayer");
        foreach(var player in leadboardPlayers)
        {
            Destroy(player);
        }
    }


}
