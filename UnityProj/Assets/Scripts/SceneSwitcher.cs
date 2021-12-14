using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
   public void LoadWelcomeScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNewUserScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLoginScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadPlayerWelcomeScene()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadLeaderboardScene()
    {
        SceneManager.LoadScene(5);
    }
}
