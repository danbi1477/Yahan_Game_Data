
 using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;


public class DataUploader : MonoBehaviour
{
    /*
    // 데이터를 서버에 업로드하는 함수
    //이름
    public void UploadData(string playerName)
    {
        StartCoroutine(PostData(playerName, "name"));
    }
    */

    //플레이 시작 타임
    public void PlayTimeUploadData(string playerName, string GamePlayTime) // 플레이어 네임 인자 추가
    {
        StartCoroutine(PostData(playerName, GamePlayTime, "PlayTime")); // 포스트데이타 메서드도 인자 2개받을수있게 추가
    }

    //끝난 타임
    public void EndTimeUploadData(string playerName, string GameEndTime)
    {
        StartCoroutine(PostData(playerName, GameEndTime, "EndTime"));
    }

    /*
    //업그레이드 횟수
    public void UpgradeUploadData(string playerName, string GatCoinCount)
    {
        StartCoroutine(PostData(playerName, GatCoinCount, "Up"));
    }
    */
    //돈
    public void MoneyUploadData(string playerName, string Money)
    {
        StartCoroutine(PostData(playerName, Money, "capitalMoney"));
        Debug.Log("돈 로그 성공1");
    }
    
    IEnumerator PostData(string playerName, string type, string typeName)
    {

        string googleAppsScriptURL = "https://script.google.com/macros/s/AKfycbz7u2wEtGPuLP8AtJorgrK151Rwnru8rlbzLpTzvcAg8CLjgE9TzH-i1062OeiGBD40/exec";

        byte[] jsonData = new byte[0];
        List<string> stringArray = new List<string>();
        if (typeName == "name")
        {
            string data = "{\"PlayerName\": \"" + type + "\"}";

            jsonData = System.Text.Encoding.UTF8.GetBytes(data);

        }
        else if (typeName == "PlayTime")
        {
            string data = "{\"PlayerName\": \"" + playerName + "\", \"GamePlayTime\": \"" + type + "\"}";

            jsonData = System.Text.Encoding.UTF8.GetBytes(data);
        }
        else if (typeName == "EndTime")
        {
            string data = "{\"PlayerName\": \"" + playerName + "\",\"EndTime\": \"" + type + "\"}";

            jsonData = System.Text.Encoding.UTF8.GetBytes(data);
        }/*
        else if (typeName == "Up")
        {
            string data = "{\"PlayerName\": \"" + playerName + "\",\"Up\": \"" + type + "\"}";

            jsonData = System.Text.Encoding.UTF8.GetBytes(data);
        }*/

        else if (typeName == "capitalMoney")
        {
            string data = "{\"PlayerName\": \"" + playerName + "\",\"Money\": \"" + type + "\"}";

            jsonData = System.Text.Encoding.UTF8.GetBytes(data);
            Debug.Log("돈 로그 성공!");
        }


        // POST 요청 생성
        UnityWebRequest www = UnityWebRequest.PostWwwForm(googleAppsScriptURL, "POST");
        www.uploadHandler = new UploadHandlerRaw(jsonData);
        www.downloadHandler = new DownloadHandlerBuffer();
        Debug.Log("요청결과" + "=" + googleAppsScriptURL);
        // 요청 헤더 설정 (필요시)
        // www.SetRequestHeader("Content-Type", "application/json");

        // 요청 보내기
        yield return www.SendWebRequest();

        // 요청 결과 확인
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("요청결과" + "=" + www.result);
            Debug.LogError("Error uploading data: " + www.error);
        }
        else
        {
            Debug.Log("Data uploaded successfully!");
        }
    }

    /*
        IEnumerator PostData(string type, string typeName)
        {

            string googleAppsScriptURL = "https://script.google.com/macros/s/AKfycbz7u2wEtGPuLP8AtJorgrK151Rwnru8rlbzLpTzvcAg8CLjgE9TzH-i1062OeiGBD40/exec";

            byte[] jsonData = new byte[0];
            List<object> jsonArray = new List<object>();

            if (typeName == "name")
            {
                string data = "{\"PlayerName\": \"" + type + "\"}";

                jsonData = System.Text.Encoding.UTF8.GetBytes(data);
            }
            
            else if (typeName == "action")
            {
                string data = "{\"action\": \"" + type + "\"}";


                jsonData = System.Text.Encoding.UTF8.GetBytes(data);
            }
            
            else if (typeName == "PlayTime")
            {
                string data = "{\"PlayTime\": \"" + type + "\"}";


                jsonData = System.Text.Encoding.UTF8.GetBytes(data);
                //jsonData2 = System.Text.Encoding.UTF8.GetBytes(data);
            }
            else if (typeName == "EndTime")
            {
                string data = "{\"EndTime\": \"" + type + "\"}";

                jsonData = System.Text.Encoding.UTF8.GetBytes(data);
            }
            else if (typeName == "Up")
            {
                string data = "{\"Up\": \"" + type + "\"}";

                jsonData = System.Text.Encoding.UTF8.GetBytes(data);
            }

            else if (typeName == "capitalMoney")
            {
                string data = "{\"Money\": \"" + type + "\"}";

                jsonData = System.Text.Encoding.UTF8.GetBytes(data);
            }
            

            // POST 요청 생성
            UnityWebRequest www = UnityWebRequest.PostWwwForm(googleAppsScriptURL, "POST");
            www.uploadHandler = new UploadHandlerRaw(jsonData);
            www.downloadHandler = new DownloadHandlerBuffer();
            Debug.Log("요청결과" + "=" + googleAppsScriptURL);
            // 요청 헤더 설정 (필요시)
            // www.SetRequestHeader("Content-Type", "application/json");

            // 요청 보내기
            yield return www.SendWebRequest();

            // 요청 결과 확인
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("요청결과" + "=" + www.result);
                Debug.LogError("Error uploading data: " + www.error);
            }
            else
            {
                Debug.Log("Data uploaded successfully!");
            }
        }
    */
}
