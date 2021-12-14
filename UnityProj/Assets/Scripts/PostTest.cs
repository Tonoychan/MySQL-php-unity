using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PostTest : MonoBehaviour
{
    public InputField Name;
    public Text result;


    public void Button()
    {
        StartCoroutine(Post());
    }

    IEnumerator Post()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", Name.text);
        UnityWebRequest postTest = UnityWebRequest.Post("localhost:8888/posttest.php", form); // Script is not on cloud server -  broken
        yield return postTest.SendWebRequest();
        result.text = postTest.downloadHandler.text;
    }
}
