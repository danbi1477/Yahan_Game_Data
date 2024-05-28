using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class New_Coin : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI TotalmoneyText;
    public GameObject Restart;
    public GameObject CoinFront;
    public GameObject CoinBack;
    public DataUploader dataUploader; // DataUploader 스크립트 연결
    public Name name;
    public GameObject MoneySuccess;
    public GameObject gamePlayScreen;
    public GameObject MoneyScreen;


    public int TotalMoney=1000;
    public int Coin;
    public int Upgrade;
    public int UpCoin = 100;
    public int UpgradeCount = 0;
    public int GatCoinCount=0;
    public int TotalMoney_500 =0;
    bool upgrade;
    bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        Restart.gameObject.SetActive(false);
        Coin = 100;
        MoneySuccess.gameObject.SetActive(false);
    }

    public void Front()
    {
        if (gameOver) return; // 게임 종료 시 행동 방지
        int _true = Random.Range(0, 2);
        Thread.Sleep(500);
        if (_true == 1)
        {
            upgrade = true;
            CoinFront.gameObject.SetActive(true);
            CoinBack.gameObject.SetActive(false);
        }
        else if (_true == 0) 
        {
            CoinFront.gameObject.SetActive(false);
            CoinBack.gameObject.SetActive(true);
            if (Coin <= 0)
            {
                TotalMoney -= 500;
                Coin += 100;
                TotalMoney_500 += 1;
            }
            else
            {
                Coin -= 100;
            }
            upgrade = false;
        }
    }
    public void Back()
    {
        if (gameOver) return; // 게임 종료 시 행동 방지
        int _true = Random.Range(0, 2);
        Thread.Sleep(500);
        if (_true == 1)
        {

            CoinFront.gameObject.SetActive(false);
            CoinBack.gameObject.SetActive(true);
            upgrade = true;
        }
        else if (_true == 0)
        {
            CoinFront.gameObject.SetActive(true);
            CoinBack.gameObject.SetActive(false);
            if (Coin <= 0)
            {
                TotalMoney -= 500;
                Coin += 100;
                TotalMoney_500 += 1;
            }
            else 
            {
                Coin -= 100;
            }
            upgrade = false;
        }
    }

    public void CoinGet()
    {
        if (gameOver) return; // 게임 종료 시 행동 방지
        
        if(Coin <= 0)
        {
            MoneyScreen.SetActive(true);
            TotalMoney -= 500;
            //TotalMoney_500 += 1;
        }
        else if(Coin == 100)
        {

        }else if(Coin > 100)
        {
            TotalMoney += Coin;
            GatCoinCount += 1;

        }
        UpgradeCount = 0;
        
        Coin = 100;
    }

    public void reset()
    {
        gameOver = false;
        SceneManager.LoadScene(0);

    }
    public void MoneyEnd()
    {
        MoneySuccess.SetActive(false);
        TotalMoney = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        TotalmoneyText.text = "Total Money: "+TotalMoney.ToString();
        CoinText.text = "Coin: "+Coin.ToString();

        if (upgrade)
        {
            Coin += UpCoin;
            UpgradeCount += 1;

            upgrade = false;
        }

        if(TotalMoney <= 0)
        {
            gameOver = true;
            Restart.gameObject.SetActive(true);
        }

        if(TotalMoney >= 5000)
        {
            MoneySuccess.gameObject.SetActive(true);
            Debug.Log("돈 로그 성공4");
        }
        else { }
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TotalMoney = 5000;
            Debug.Log("돈 얻음!");
        }*/
    }
}
