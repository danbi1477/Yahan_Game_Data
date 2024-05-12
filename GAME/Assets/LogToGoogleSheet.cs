using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SendDataToGoogleScript : MonoBehaviour
{
    public string scriptURL = "https://script.google.com/macros/s/AKfycbwKpGJtmm1GyUpxu7Btw6C9xUSCvC-3rNQCFMPHlWi5cT7b5A3h9EOs6V5qhSU3Ap9l2g/exec";

    public void SendData(string data)
    {
        StartCoroutine(PostRequest(data));
    }

    IEnumerator PostRequest(string data)
    {
        WWWForm form = new WWWForm();
        form.AddField("data", data);

        using (UnityWebRequest www = UnityWebRequest.Post(scriptURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Data sent successfully!");
            }
        }
    }
}