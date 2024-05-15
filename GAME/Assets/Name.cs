using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    public InputField nameInputField;
    public GameObject start;
    public DataUploader dataUploader; // DataUploader 스크립트 연결
    public int UpgradeCount=0;
    public New_Coin  new_coin;

    public void Upgrade()
    {
        if(UpgradeCount >= 5)
        {

        }
        else
        {
            UpgradeCount++;
        }
    }
    

    //게임 종료
    public void GameExit()
    {
        Debug.Log("게임이 종료됩니다.");
        string playerName = nameInputField.text;
        DateTime EndTime = DateTime.Now;
        string GameEndTime = EndTime.ToString("yyyy-MM-dd HH:mm:ss");
        PlayerPrefs.SetString("EndTime", GameEndTime);

        if (!string.IsNullOrEmpty(GameEndTime))
        {
            string saveEndTime = PlayerPrefs.GetString("EndTime");
            Debug.Log(saveEndTime);

            // DataUploader 스크립트의 PlayTimeUploadData 함수 호출하여 데이터 업로드
            dataUploader.EndTimeUploadData(playerName, GameEndTime);
        }
        else
        {
            Debug.Log("저장된 시간이 없소");
        }

        //게임 종료
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        //이름 초기화
        PlayerPrefs.DeleteKey("PlayerName");
        start.gameObject.SetActive(false);
    }
    
    //이름
    public void SavePlayerName()
    {
        string playerName = nameInputField.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        // 여기서 "PlayerName"은 플레이어 이름을 저장할 때 사용되는 키입니다.
        // PlayerPrefs를 사용하여 이름을 저장합니다. 
        // PlayerPrefs는 유저의 기기에 영구적으로 데이터를 저장하는 데 사용됩니다.
        gameObject.SetActive(false);
        start.gameObject.SetActive(true);
        /*
        if (!string.IsNullOrEmpty(playerName))
        {
            //savedName = 저장된 이름
            string savedName = PlayerPrefs.GetString("PlayerName");
            // 저장된 이름을 불러옵니다.
            Debug.Log("HELLO! " + savedName);
            // DataUploader 스크립트의 UploadData 함수 호출하여 데이터 업로드
            dataUploader.UploadData( playerName);
        }
        else
        {
            Debug.Log("저장된 이름이 없습니다.");
        }
        */
    }
    //플레이 시작 타임
    public void PlayTime()
    {
        string playerName = nameInputField.text;
        DateTime startTime = DateTime.Now;
        string GamePlayTime = startTime.ToString("yyyy-MM-dd HH:mm:ss"); 
        //string playerName = PlayerPrefs.GetString("PlayerName"); // 1. 플레이어 이름을 가져오는지 확인 필요(가져올수있다면 모든 메서드에 복붙)
        Debug.Log(playerName);

        if (!string.IsNullOrEmpty(GamePlayTime))
        {
            string savePlayTime = PlayerPrefs.GetString("PlayTime");
            Debug.Log(savePlayTime);

            // DataUploader 스크립트의 PlayTimeUploadData 함수 호출하여 데이터 업로드
            dataUploader.PlayTimeUploadData(playerName, GamePlayTime); // 인자로 넘기는거 추가
        }
        else
        {
            Debug.Log("저장된 시간이 없소");
        }
    }
    /*
    //업그레이드
    public void UpgradeLog()
    {
        string playerName = nameInputField.text;
        string GatCoinCount = new_coin.GatCoinCount.ToString();
        PlayerPrefs.SetString("Up", GatCoinCount);

        if (!string.IsNullOrEmpty(GatCoinCount))
        {
            string saveUpgradeCount = PlayerPrefs.GetString("Up");
            Debug.Log(saveUpgradeCount);

            // DataUploader 스크립트의 PlayTimeUploadData 함수 호출하여 데이터 업로드
            dataUploader.UpgradeUploadData(playerName, GatCoinCount);
        }
        else
        {
            Debug.Log("저장된 업그레이드가 없소");
        }
    }
    //돈
    public void MoneyLog()
    {
        string playerName = nameInputField.text;
        string Money = new_coin.TotalMoney.ToString();
        PlayerPrefs.SetString("capitalMoney", Money);

        if (!string.IsNullOrEmpty(Money))
        {
            string saveMoney = PlayerPrefs.GetString("capitalMoney");
            Debug.Log(saveMoney);

            // DataUploader 스크립트의 PlayTimeUploadData 함수 호출하여 데이터 업로드
            dataUploader.MoneyUploadData(playerName, Money);
        }
        else
        {
            Debug.Log("저장된 돈이 없소");
        }
    }
    */



    // Update is called once per frame
    void Update()
    {

    }
}