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
    public DataUploader dataUploader; // DataUploader ��ũ��Ʈ ����
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
    

    //���� ����
    public void GameExit()
    {
        Debug.Log("������ ����˴ϴ�.");
        string playerName = nameInputField.text;
        DateTime EndTime = DateTime.Now;
        string GameEndTime = EndTime.ToString("yyyy-MM-dd HH:mm:ss");
        PlayerPrefs.SetString("EndTime", GameEndTime);

        if (!string.IsNullOrEmpty(GameEndTime))
        {
            string saveEndTime = PlayerPrefs.GetString("EndTime");
            Debug.Log(saveEndTime);

            // DataUploader ��ũ��Ʈ�� PlayTimeUploadData �Լ� ȣ���Ͽ� ������ ���ε�
            dataUploader.EndTimeUploadData(playerName, GameEndTime);
        }
        else
        {
            Debug.Log("����� �ð��� ����");
        }

        //���� ����
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        //�̸� �ʱ�ȭ
        PlayerPrefs.DeleteKey("PlayerName");
        start.gameObject.SetActive(false);
    }
    
    //�̸�
    public void SavePlayerName()
    {
        string playerName = nameInputField.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        // ���⼭ "PlayerName"�� �÷��̾� �̸��� ������ �� ���Ǵ� Ű�Դϴ�.
        // PlayerPrefs�� ����Ͽ� �̸��� �����մϴ�. 
        // PlayerPrefs�� ������ ��⿡ ���������� �����͸� �����ϴ� �� ���˴ϴ�.
        gameObject.SetActive(false);
        start.gameObject.SetActive(true);
        /*
        if (!string.IsNullOrEmpty(playerName))
        {
            //savedName = ����� �̸�
            string savedName = PlayerPrefs.GetString("PlayerName");
            // ����� �̸��� �ҷ��ɴϴ�.
            Debug.Log("HELLO! " + savedName);
            // DataUploader ��ũ��Ʈ�� UploadData �Լ� ȣ���Ͽ� ������ ���ε�
            dataUploader.UploadData( playerName);
        }
        else
        {
            Debug.Log("����� �̸��� �����ϴ�.");
        }
        */
    }
    //�÷��� ���� Ÿ��
    public void PlayTime()
    {
        string playerName = nameInputField.text;
        DateTime startTime = DateTime.Now;
        string GamePlayTime = startTime.ToString("yyyy-MM-dd HH:mm:ss"); 
        //string playerName = PlayerPrefs.GetString("PlayerName"); // 1. �÷��̾� �̸��� ���������� Ȯ�� �ʿ�(�����ü��ִٸ� ��� �޼��忡 ����)
        Debug.Log(playerName);

        if (!string.IsNullOrEmpty(GamePlayTime))
        {
            string savePlayTime = PlayerPrefs.GetString("PlayTime");
            Debug.Log(savePlayTime);

            // DataUploader ��ũ��Ʈ�� PlayTimeUploadData �Լ� ȣ���Ͽ� ������ ���ε�
            dataUploader.PlayTimeUploadData(playerName, GamePlayTime); // ���ڷ� �ѱ�°� �߰�
        }
        else
        {
            Debug.Log("����� �ð��� ����");
        }
    }
    /*
    //���׷��̵�
    public void UpgradeLog()
    {
        string playerName = nameInputField.text;
        string GatCoinCount = new_coin.GatCoinCount.ToString();
        PlayerPrefs.SetString("Up", GatCoinCount);

        if (!string.IsNullOrEmpty(GatCoinCount))
        {
            string saveUpgradeCount = PlayerPrefs.GetString("Up");
            Debug.Log(saveUpgradeCount);

            // DataUploader ��ũ��Ʈ�� PlayTimeUploadData �Լ� ȣ���Ͽ� ������ ���ε�
            dataUploader.UpgradeUploadData(playerName, GatCoinCount);
        }
        else
        {
            Debug.Log("����� ���׷��̵尡 ����");
        }
    }
    //��
    public void MoneyLog()
    {
        string playerName = nameInputField.text;
        string Money = new_coin.TotalMoney.ToString();
        PlayerPrefs.SetString("capitalMoney", Money);

        if (!string.IsNullOrEmpty(Money))
        {
            string saveMoney = PlayerPrefs.GetString("capitalMoney");
            Debug.Log(saveMoney);

            // DataUploader ��ũ��Ʈ�� PlayTimeUploadData �Լ� ȣ���Ͽ� ������ ���ε�
            dataUploader.MoneyUploadData(playerName, Money);
        }
        else
        {
            Debug.Log("����� ���� ����");
        }
    }
    */



    // Update is called once per frame
    void Update()
    {

    }
}