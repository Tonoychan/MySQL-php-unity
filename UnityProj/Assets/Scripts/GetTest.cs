using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GetTest : MonoBehaviour
{
    public Text text;

    void Start()
    {
        StartCoroutine(GetTesting());
    }

    IEnumerator GetTesting()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get("localhost:8888/test.php"); //Probably broken with cloud server - Script does not exist on server
        yield return webRequest.SendWebRequest();
        text.text = webRequest.downloadHandler.text;
    }

}
