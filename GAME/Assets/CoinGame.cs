using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinGame : MonoBehaviour
{
    public TextMeshProUGUI capitalText;
    public Button throwButton;
    public Button headsButton; // 앞면 선택 버튼
    public Button tailsButton; // 뒷면 선택 버튼
    public Button upgradeButton; // 강화 버튼
    public Button restartButton; // 재시작 버튼
    public Image coinImage;

    public Sprite frontSprite; // 동전의 앞면 이미지
    public Sprite backSprite;  // 동전의 뒷면 이미지

    public int capital = 1000;
    public int betAmount = 100;
    public int winAmount = 200;
    public int upgradeCost = 500;
    public int upgradeCount = 0; // 강화 횟수
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        capitalText.text = "Capital: " + capital.ToString();
        throwButton.onClick.AddListener(ThrowCoin);
        headsButton.onClick.AddListener(() => SelectSide(true));
        tailsButton.onClick.AddListener(() => SelectSide(false));
        upgradeButton.onClick.AddListener(UpgradeCoin);
        restartButton.onClick.AddListener(RestartGame);
        restartButton.gameObject.SetActive(false); // 게임 시작 시 재시작 버튼 비활성화
    }

   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Input.GetKeyDown(KeyCode.W) &&
            Input.GetKeyDown(KeyCode.E) && Input.GetKeyDown(KeyCode.R))
        {
            PayEmployee();
        }
    }

    

    void ThrowCoin()
    {
        if (gameOver) return; // 게임 종료 시 동전 던지기 방지

        // 동전을 던지고 결과를 결정 (50:50 확률)
        bool result = Random.Range(0, 2) == 0 ? false : true;

        // 베팅 금액 차감
        capital -= betAmount;
        capitalText.text = "Capital: " + capital.ToString();

        // 결과에 따른 자본 변화
        if (result)
        {
            capital += winAmount;
            Debug.Log("You win! Capital: " + capital);
        }
        else
        {
            Debug.Log("You lose! Capital: " + capital);
        }

        // 동전 이미지 변경
        coinImage.sprite = result ? frontSprite : backSprite;

        // 앞뒤 맞추기 판단
        CheckGuess(result);

        // 게임 종료 확인
        CheckGameStatus();
    }

    void SelectSide(bool isHeads)
    {
        if (gameOver) return; // 게임 종료 시 선택 방지

        Debug.Log(isHeads ? "You selected Heads" : "You selected Tails");
        ThrowCoin();
    }

    void UpgradeCoin()
    {
        if (gameOver) return; // 게임 종료 시 강화 방지

        if (upgradeCount < 10 && capital >= upgradeCost * (upgradeCount + 1))
        {
            capital -= upgradeCost * (upgradeCount + 1); // 강화 횟수에 따라 비용 증가
            capitalText.text = "Capital: " + capital.ToString();
            upgradeCount++;
            Debug.Log("Coin upgraded! Upgrade Count: " + upgradeCount);

            // 강화 비용에 따라 돈 증가
            int upgradeAmount = 50 * upgradeCount;
            capital += upgradeAmount;
            Debug.Log("Capital increased by " + upgradeAmount + "! Capital: " + capital);
        }
        else
        {
            Debug.Log("Upgrade failed! Upgrade Count: " + upgradeCount);
        }

        // 게임 종료 확인
        CheckGameStatus();
    }

    void PayEmployee()
    {
        if (gameOver) return; // 게임 종료 시 알바비 지불 방지

        for (int i = 0; i < 4; i++)
        {
            capital -= Random.Range(50, 201); // 알바비는 50에서 200 사이의 랜덤한 금액
        }
        capitalText.text = "Capital: " + capital.ToString();
        Debug.Log("Employee paid! Capital: " + capital);

        // 게임 종료 확인
        CheckGameStatus();
    }

    void CheckGuess(bool result)
    {
        // 결과에 따라 판단
        if (result)
        {
            Debug.Log("You guessed correctly!");

            // 강화한 만큼 돈 증가
            int upgradeAmount = 50 * upgradeCount;
            capital += upgradeAmount;
            Debug.Log("Capital increased by " + upgradeAmount + "! Capital: " + capital);
        }
        else
        {
            Debug.Log("You guessed wrong!");
        }
    }

    void CheckGameStatus()
    {
        if (capital <= 0)
        {
            Debug.Log("Game over! Capital: " + capital);
            gameOver = true;
            restartButton.gameObject.SetActive(true); // 게임 종료 시 재시작 버튼 활성화
        }
    }
    void RestartGame()
    {
        capital = 1000;
        upgradeCount = 0;
        capitalText.text = "Capital: " + capital.ToString();
        Debug.Log("Game restarted! Capital: " + capital);

        gameOver = false;
        restartButton.gameObject.SetActive(false); // 게임 재시작 시 재시작 버튼 비활성화
    }

}