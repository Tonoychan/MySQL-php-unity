using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPlayer : MonoBehaviour
{
    public Text Username;
    public Text Score;
    public GameObject Rank;

    public string username;
    public int score;
    public int rank;
    public void AssignInfo()
    {
        Rank.SetActive(true);
        Username.text = username;
        Score.text = score.ToString();
        Rank.GetComponent<Text>().text = rank.ToString() + ".";
    }

    public void AssignSearchInfo()
    {
        Rank.SetActive(false);
        Username.text = username;
        Score.text = score.ToString();
    }


}
